using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POELiveSplitComponent.Component
{
    partial class SettingsControl : UserControl
    {
        private ComponentSettings settings;

        public SettingsControl(ComponentSettings settings)
        {
            this.settings = settings;
            InitializeComponent();
            foreach (Zone zone in Zone.ZONES)
            {
                checkedListZones.Items.Add(zone, false);
            }
            XmlRefresh();
        }

        public void XmlRefresh()
        {
            checkAutoSplit.Checked = settings.AutoSplitEnabled;
            checkLoadRemoval.Checked = settings.LoadRemovalEnabled;
            textLogLocation.Text = settings.LogLocation;

            bool isSplitByAct = true;
            bool isSplitAll = true;
            for (int i = 0; i < checkedListZones.Items.Count; i++)
            {
                Zone zone = (Zone)checkedListZones.Items[i];
                bool shouldSplit = settings.SplitZones.Contains(zone);
                if (shouldSplit != zone.IsActZone)
                {
                    isSplitByAct = false;
                }
                if (!shouldSplit)
                {
                    isSplitAll = false;
                }
                checkedListZones.SetItemChecked(i, shouldSplit);
            }
            if (isSplitByAct)
            {
                radioSplitByActs.Checked = true;
            }
            else if (isSplitAll)
            {
                radioSplitAllZones.Checked = true;
            }
            else
            {
                radioSplitCustom.Checked = true;
            }
        }

        private void HandleAutoSplitChanged(object sender, EventArgs e)
        {
            settings.AutoSplitEnabled = checkAutoSplit.Checked;
        }

        private void handleLoadRemovalChanged(object sender, EventArgs e)
        {
            settings.LoadRemovalEnabled = checkLoadRemoval.Checked;
        }

        private void handleLogLocationChanged(object sender, EventArgs e)
        {
            settings.LogLocation = textLogLocation.Text;
        }

        private void HandleTestClick(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(settings.LogLocation, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                { }
                MessageBox.Show("No problems found.", "Log File Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Log File Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleBrowseClick(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textLogLocation.Text = openFileDialog.FileName;
            }
        }

        private void LinkLoadSetupClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/brandondong/POE-LiveSplit-Component/blob/master/README.md");
        }

        private void HandleSplitByChanged(object sender, EventArgs e)
        {
            if (radioSplitAllZones.Checked)
            {
                for (int i = 0; i < checkedListZones.Items.Count; i++)
                {
                    checkedListZones.SetItemChecked(i, true);
                }
            }
            else if (radioSplitByActs.Checked)
            {
                for (int i = 0; i < checkedListZones.Items.Count; i++)
                {
                    Zone zone = (Zone)checkedListZones.Items[i];
                    checkedListZones.SetItemChecked(i, zone.IsActZone);
                }
            }
        }

        private void ZoneSelectedIndexChanged(object sender, EventArgs e)
        {
            radioSplitCustom.Checked = true;
        }

        private void HandleItemChecked(object sender, ItemCheckEventArgs e)
        {
            Zone zone = (Zone)checkedListZones.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                settings.SplitZones.Add(zone);
            }
            else
            {
                settings.SplitZones.Remove(zone);
            }
        }
    }
}
