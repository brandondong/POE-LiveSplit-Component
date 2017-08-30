using System;
using LiveSplit.Model;
using System.Collections.Generic;

namespace POELiveSplitComponent.Component
{
    class LoadRemoverSplitter
    {
        private static LabyrinthZone LAB_ENTRANCE = new LabyrinthZone("Labyrinth_Airlock");
        private LiveSplitState state;
        private ComponentSettings settings;
        private TimerModel timer;
        private long loadTimes = 0;
        private long? startTimestamp;
        private string zoneName;
        private HashSet<IZone> encounteredZones = new HashSet<IZone>();
        private IZone previousZone;

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

            if (zoneName != null)
            {
                IZone zone = Zone.Parse(zoneName, location);

                if (settings.LabSpeedrunningEnabled && zone.Type() == ZoneType.LABYRINTH)
                {
                    if (state.CurrentPhase == TimerPhase.NotRunning && LAB_ENTRANCE.Equals(previousZone))
                    {
                        timer.Start();
                    }
                    else if (!encounteredZones.Contains(zone))
                    {
                        timer.Split();
                        encounteredZones.Add(zone);
                    }
                }
                if (settings.AutoSplitEnabled)
                {
                    if (!encounteredZones.Contains(zone) && settings.SplitZones.Contains(zone))
                    {
                        timer.Split();
                        encounteredZones.Add(zone);
                    }
                }
                previousZone = zone;
            }
        }

        private void HandleResetRuns(object sender, EventArgs e)
        {
            loadTimes = 0;
            startTimestamp = null;
            zoneName = null;
            encounteredZones = new HashSet<IZone>();
        }
    }
}