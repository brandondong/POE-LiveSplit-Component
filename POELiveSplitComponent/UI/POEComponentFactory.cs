using LiveSplit.UI.Components;
using System;
using LiveSplit.Model;

namespace POELiveSplitComponent.UI
{
    class POEComponentFactory : IComponentFactory
    {
        public ComponentCategory Category => ComponentCategory.Timer;

        public string ComponentName => "POE";

        public string Description => "Load Time Removal and Auto Splitting for Path of Exile.";

        public string UpdateName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string UpdateURL
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Version Version
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string XMLURL
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IComponent Create(LiveSplitState state)
        {
            return new POEComponent(state);
        }
    }
}
