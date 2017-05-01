using System;
using LiveSplit.Model;
using System.Collections.Generic;

namespace POELiveSplitComponent.Component
{
    class LoadRemoverSplitter
    {   private LiveSplitState state;
        private ComponentSettings settings;
        private TimerModel timer;
        private long loadTimes = 0;
        private long? startTimestamp;
        private string zoneName;
        private HashSet<Zone> encounteredZones = new HashSet<Zone>();

        public LoadRemoverSplitter(LiveSplitState state, ComponentSettings settings)
        {
            this.state = state;
            this.settings = settings;
            timer = new TimerModel();
            timer.CurrentState = state;
            state.OnStart += HandleResetRuns;
        }
        
        public void HandleLoadStart(long timestamp)
        {
            if (settings.LoadRemovalEnabled)
            {
                state.IsGameTimePaused = true;
                startTimestamp = timestamp;
            }
        }

        public void HandleZoneName(string zoneName)
        {
            this.zoneName = zoneName;
        }

        public void HandleLoadEnd(long timestamp, string location)
        {
            if (settings.LoadRemovalEnabled)
            {
                loadTimes += timestamp - startTimestamp.GetValueOrDefault(timestamp);
                state.IsGameTimePaused = false;
                state.LoadingTimes = TimeSpan.FromMilliseconds(loadTimes);
            }

            if (settings.AutoSplitEnabled)
            {
                if (zoneName != null)
                {
                    Zone zone = Zone.create(zoneName, Zone.ParseDifficulty(location));
                    if (!encounteredZones.Contains(zone) && settings.SplitZones.ContainsKey(zone) && settings.SplitZones[zone])
                    {
                        timer.Split();
                        encounteredZones.Add(zone);
                    }
                }
            }
        }

        private void HandleResetRuns(object sender, EventArgs e)
        {
            loadTimes = 0;
            startTimestamp = null;
            zoneName = null;
            encounteredZones = new HashSet<Zone>();
        }
    }
}