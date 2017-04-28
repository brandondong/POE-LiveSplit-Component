using System;
using LiveSplit.Model;

namespace POELiveSplitComponent.Component
{
    class LoadRemoverSplitter
    {
        private LiveSplitState state;
        private ComponentSettings settings;
        private TimerModel timer;
        private long loadTimes = 0;
        private long? startTimestamp;

        public LoadRemoverSplitter(LiveSplitState state, ComponentSettings settings)
        {
            this.state = state;
            this.settings = settings;
            timer = new TimerModel();
            timer.CurrentState = state;
            timer.OnStart += HandleLoadReset;
        }

        private void HandleLoadReset(object sender, EventArgs e)
        {
            loadTimes = 0;
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
            if (settings.LoadRemovalEnabled)
            {
                loadTimes += timestamp - startTimestamp.GetValueOrDefault(timestamp);
                state.IsGameTimePaused = false;
                state.LoadingTimes = TimeSpan.FromMilliseconds(loadTimes);
            }
            if (settings.AutoSplitEnabled)
            {

            }
        }
    }
}