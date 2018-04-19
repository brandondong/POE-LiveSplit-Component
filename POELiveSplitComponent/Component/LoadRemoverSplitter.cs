using System;
using LiveSplit.Model;
using System.Collections.Generic;

namespace POELiveSplitComponent.Component
{
    class LoadRemoverSplitter
    {
        // Zone that lab runners must enter before the lab. Unique zone name.
        private static IZone LAB_ENTRANCE = Zone.Parse("Aspirants' Plaza", new HashSet<IZone>());
        private LiveSplitState state;
        private ComponentSettings settings;
        private TimerModel timer;
        private long loadTimes = 0;
        private long? startTimestamp;
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

        public void HandleLoadEnd(long timestamp, string zoneName)
        {
            if (settings.LoadRemovalEnabled)
            {
                loadTimes += timestamp - startTimestamp.GetValueOrDefault(timestamp);
                state.IsGameTimePaused = false;
                state.LoadingTimes = TimeSpan.FromMilliseconds(loadTimes);
            }
                        
            IZone zone = Zone.Parse(zoneName, encounteredZones);

            if (settings.LabSpeedrunningEnabled)
            {
                if (state.CurrentPhase == TimerPhase.NotRunning && LAB_ENTRANCE.Equals(previousZone))
                {
                    // Start the timer on the first zone of the lab.
                    timer.Start();
                }
                else
                {
                    // And split on subsequent zones.
                    timer.Split();
                }
            }
            else if (settings.AutoSplitEnabled)
            {
                if (!encounteredZones.Contains(zone) && settings.SplitZones.Contains(zone))
                {
                    timer.Split();
                }
                // Keep track of all encountered zones for part prediction.
                encounteredZones.Add(zone);
            }
            previousZone = zone;
        }

        private void HandleResetRuns(object sender, EventArgs e)
        {
            loadTimes = 0;
            startTimestamp = null;
            encounteredZones = new HashSet<IZone>();
        }
    }
}