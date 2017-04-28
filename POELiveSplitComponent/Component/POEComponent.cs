using System;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace POELiveSplitComponent.Component
{
    class POEComponent : LogicComponent
    {
        public const string NAME = "POE";

        private ClientReader reader;

        private ComponentSettings settings = new ComponentSettings();

        private SettingsControl control;

        public POEComponent(LiveSplitState state)
        {
            LoadRemoverSplitter remover = new LoadRemoverSplitter(state, settings);
            reader = new ClientReader(settings);
            reader.Start(remover.HandleLoadStart, remover.HandleLoadEnd);
            control = new SettingsControl(settings);
        }

        public override string ComponentName => NAME;

        public override void Dispose()
        {
            reader.Stop();
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return settings.GetSettings(document);
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return control;
        }

        public override void SetSettings(XmlNode settings)
        {
            this.settings.SetSettings(settings);
            control.XmlRefresh();
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        { }
    }
}