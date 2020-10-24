using LiveSplit.UI.Components;
using System;
using LiveSplit.Model;
using POELiveSplitComponent.Component;

[assembly: ComponentFactory(typeof(POEComponentFactory))]

namespace POELiveSplitComponent.Component
{
    public class POEComponentFactory : IComponentFactory
    {
        public ComponentCategory Category => ComponentCategory.Timer;

        public string ComponentName => POEComponent.NAME;

        public string Description => "Load Time Removal and Auto Splitting for Path of Exile.";

        public string UpdateName => "Path of Exile";

        public string UpdateURL => "https://raw.githubusercontent.com/brandondong/POE-LiveSplit-Component/master/POELiveSplitComponent/Update/";

        public Version Version => Version.Parse("1.0.11");

        public string XMLURL => UpdateURL + "updates.xml";

        public IComponent Create(LiveSplitState state)
        {
            return new POEComponent(state);
        }
    }
}
