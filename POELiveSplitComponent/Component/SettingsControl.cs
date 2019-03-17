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
            XmlRefresh();
        }

        public void XmlRefresh()
        {
            checkAutoSplit.Checked = settings.AutoSplitEnabled;
            checkLoadRemoval.Checked = settings.LoadRemovalEnabled;
            textLogLocation.Text = settings.LogLocation;
            checkLabyrinth.Checked = settings.LabSpeedrunningEnabled;
            bool isZoneCriteria = settings.CriteriaToSplit == ComponentSettings.SplitCriteria.Zones;
            radioZones.Checked = isZoneCriteria;
            radioLevels.Checked = !isZoneCriteria;
            checkIcons.Checked = settings.GenerateWithIcons;
            checkIcons.Visible = isZoneCriteria;

            updateCheckedList();
        }

        private void updateCheckedList()
        {
            checkedSplitList.Items.Clear();
            if (settings.CriteriaToSplit == ComponentSettings.SplitCriteria.Zones)
            {
                foreach (Zone zone in Zone.ZONES)
                {
                    checkedSplitList.Items.Add(zone, settings.SplitZones.Contains(zone));
                }
            }
            else
            {
                for (int i = 2; i <= 100; i++)
                {
                    checkedSplitList.Items.Add(i, settings.SplitLevels.Contains(i));
                }
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
            if (settings.CriteriaToSplit == ComponentSettings.SplitCriteria.Zones)
            {
                IZone zone = (IZone)checkedSplitList.Items[e.Index];
                if (e.NewValue == CheckState.Checked)
                {
                    settings.SplitZones.Add(zone);
                }
                else
                {
                    settings.SplitZones.Remove(zone);
                }
            }
            else
            {
                int level = (int)checkedSplitList.Items[e.Index];
                if (e.NewValue == CheckState.Checked)
                {
                    settings.SplitLevels.Add(level);
                }
                else
                {
                    settings.SplitLevels.Remove(level);
                }
            }
        }

        private void HandleCheckLabyrinth(object sender, EventArgs e)
        {
            settings.LabSpeedrunningEnabled = checkLabyrinth.Checked;
            checkAutoSplit.Enabled = !checkLabyrinth.Checked;
        }

        private void HandleSelectAll(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedSplitList.Items.Count; i++)
            {
                checkedSplitList.SetItemChecked(i, checkSelectAll.Checked);
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
            bool isZoneCriteria = settings.CriteriaToSplit == ComponentSettings.SplitCriteria.Zones;
            for (int i = 0; i < checkedSplitList.Items.Count; i++)
            {
                if (checkedSplitList.GetItemChecked(i))
                {
                    if (isZoneCriteria)
                    {
                        IZone zone = (IZone)checkedSplitList.Items[i];
                        Image icon = null;
                        if (settings.GenerateWithIcons)
                        {
                            icon = iconForType(Zone.ICONTYPES[zone]);
                        }
                        state.Run.AddSegment(zone.SplitName(), default(Time), default(Time), icon);
                    }
                    else
                    {
                        state.Run.AddSegment(String.Format("Level {0}", checkedSplitList.Items[i]));
                    }
                }
            }
            if (state.Run.Count == 0)
            {
                state.Run.AddSegment("");
            }
            state.Run.HasChanged = true;
            state.Form.Invalidate();
            MessageBox.Show("Splits generated successfully.\n\nDue to LiveSplit API restrictions, the Splits Editor needs to be reopened to view the updated changes.",
                "Generate Splits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Image iconForType(Zone.IconType type)
        {
            if (type == Zone.IconType.NoWp)
            {
                return Properties.Resources.NoWpIcon;
            }
            else if (type == Zone.IconType.Town)
            {
                return Properties.Resources.TownIcon;
            }
            return Properties.Resources.WpIcon;
        }

        private void HandleSplitCriteriaChanged(object sender, EventArgs e)
        {
            if (radioZones.Checked)
            {
                settings.CriteriaToSplit = ComponentSettings.SplitCriteria.Zones;
            }
            else
            {
                settings.CriteriaToSplit = ComponentSettings.SplitCriteria.Levels;
            }
            checkIcons.Visible = radioZones.Checked;
            updateCheckedList();
        }

        private void HandleIconsChecked(object sender, EventArgs e)
        {
            settings.GenerateWithIcons = checkIcons.Checked;
        }
    }
}
