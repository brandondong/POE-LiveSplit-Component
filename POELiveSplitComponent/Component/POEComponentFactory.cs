using LiveSplit.UI.Components;
using System;
using LiveSplit.Model;

namespace POELiveSplitComponent.Component
{
    class POEComponentFactory : IComponentFactory
    {
        public ComponentCategory Category => ComponentCategory.Timer;

        public string ComponentName => POEComponent.NAME;

        public string Description => "Load Time Removal and Auto Splitting for Path of Exile.";

        public string UpdateName => POEComponent.NAME;

        public string UpdateURL
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Version Version => Version.Parse("1.0.0");

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
