using System;
using LiveSplit.Model;

namespace POELiveSplitComponent.Component
{
    class LoadRemoverSplitter
    {
        private static readonly string[] ZONES = new string[] { "1_2_1", "1_3_1", "1_4_1", "2_1_1", "2_2_1", "2_3_1", "2_4_1", "3_1_1", "3_2_1", "3_3_1", "3_4_1" };

        private LiveSplitState state;
        private ComponentSettings settings;
        private TimerModel timer;
        private long loadTimes = 0;
        private long? startTimestamp;
        private int lookingForZoneIndex = 0;

        public LoadRemoverSplitter(LiveSplitState state, ComponentSettings settings)
        {
            this.state = state;
            this.settings = settings;
            timer = new TimerModel();
            timer.CurrentState = state;
        }

        public void HandleLoadStart(long timestamp)
        {
            if (settings.LoadRemovalEnabled)
            {
                state.IsGameTimePaused = true;
                startTimestamp = timestamp;
            }
        }

        public void HandleLoadEnd(long timestamp, string location)
        {
            HandleResetRuns();
            if (settings.LoadRemovalEnabled)
            {
                loadTimes += timestamp - startTimestamp.GetValueOrDefault(timestamp);
                state.IsGameTimePaused = false;
                state.LoadingTimes = TimeSpan.FromMilliseconds(loadTimes);
            } else
            {
                // Just to set the flag so that the next time we don't reset our run info
                state.LoadingTimes = TimeSpan.FromMilliseconds(0);
            }

            if (settings.AutoSplitEnabled)
            {
                if (lookingForZoneIndex < ZONES.Length && location.Equals(ZONES[lookingForZoneIndex]))
                {
                    timer.Split();
                    lookingForZoneIndex++;
                }
            }
        }

        private void HandleResetRuns()
        {
            if (!state.IsGameTimeInitialized)
            {
                // Timer got reset; throw away the previous run's load times and reset zone progression
                loadTimes = 0;
                lookingForZoneIndex = 0;
            }
        }
    }
}