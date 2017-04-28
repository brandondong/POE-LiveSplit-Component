using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace POELiveSplitComponent.UI
{
    internal class POEComponent : LogicComponent
    {
        private LiveSplitState state;

        public POEComponent(LiveSplitState state)
        {
            this.state = state;
        }

        public override string ComponentName => "POE";

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            throw new NotImplementedException();
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            throw new NotImplementedException();
        }

        public override void SetSettings(XmlNode settings)
        {
            throw new NotImplementedException();
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        { }
    }
}