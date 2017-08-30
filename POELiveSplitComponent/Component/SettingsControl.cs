using LiveSplit.Model;
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

        private LiveSplitState state;

        public SettingsControl(ComponentSettings settings, LiveSplitState state)
        {
            this.settings = settings;
            this.state = state;
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
            checkLabyrinth.Checked = settings.LabSpeedrunningEnabled;

            for (int i = 0; i < checkedListZones.Items.Count; i++)
            {
                Zone zone = (Zone)checkedListZones.Items[i];
                bool shouldSplit = settings.SplitZones.Contains(zone);
                checkedListZones.SetItemChecked(i, shouldSplit);
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

        private void HandleCheckLabyrinth(object sender, EventArgs e)
        {
            settings.LabSpeedrunningEnabled = checkLabyrinth.Checked;
        }

        private void HandleSelectAll(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListZones.Items.Count; i++)
            {
                checkedListZones.SetItemChecked(i, checkSelectAll.Checked);
            }
        }

        private void HandleGenerateSplits(object sender, EventArgs e)
        {
            if (state.CurrentPhase != TimerPhase.NotRunning)
            {
                MessageBox.Show("Splits cannot be changed while the timer is running or has not been reset.",
                    "Generate Splits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Your current split segments will be overwritten.\nAre you sure you want to proceed?",
                "Confirm Generate Splits", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            state.Run.Clear();
            for (int i = 0; i < checkedListZones.Items.Count; i++)
            {
                if (checkedListZones.GetItemChecked(i))
                {
                    state.Run.AddSegment(checkedListZones.Items[i].ToString());
                }
            }
            if (state.Run.Count == 0)
            {
                state.Run.AddSegment("");
            }
            state.Form.Invalidate();
            MessageBox.Show("Splits generated successfully.\n\nDue to LiveSplit API restrictions, the Splits Editor needs to be reopened to view the updated changes.",
                "Generate Splits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
