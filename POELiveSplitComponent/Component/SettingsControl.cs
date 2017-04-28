using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POELiveSplitComponent.Component
{
    partial class SettingsControl : Form
    {
        private ComponentSettings settings;

        public SettingsControl(ComponentSettings settings)
        {
            this.settings = settings;
            InitializeComponent();
            XmlRefresh();
        }

        public void XmlRefresh()
        {
            checkAutoSplit.Checked = settings.AutoSplitEnabled;
            checkLoadRemoval.Checked = settings.LoadRemovalEnabled;
            textLogLocation.Text = settings.LogLocation;
        }
    }
}
