using System;
using LiveSplit.Model;

namespace POELiveSplitComponent.Component
{
    class LoadRemoverSplitter
    {
        private LiveSplitState state;
        private ComponentSettings settings;
        private TimerModel timer;

        public LoadRemoverSplitter(LiveSplitState state, ComponentSettings settings)
        {
            this.state = state;
            this.settings = settings;
            timer = new TimerModel();
            timer.CurrentState = state;
            timer.OnReset += HandleTimerReset;
        }

        private void HandleTimerReset(object sender, TimerPhase value)
        {
            throw new NotImplementedException();
        }

        public void HandleLoadStart()
        {

        }

        public void HandleLoadEnd()
        {

        }
    }
}