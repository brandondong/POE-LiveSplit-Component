namespace POELiveSplitComponent.Component
{
    partial class SettingsControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelSplitList = new System.Windows.Forms.Panel();
            this.checkedSplitList = new System.Windows.Forms.CheckedListBox();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.checkIcons = new System.Windows.Forms.CheckBox();
            this.createSplitsButton = new System.Windows.Forms.Button();
            this.groupBoxLab = new System.Windows.Forms.GroupBox();
            this.radioAspirant = new System.Windows.Forms.RadioButton();
            this.labelLabDescription = new System.Windows.Forms.Label();
            this.radioAllLab = new System.Windows.Forms.RadioButton();
            this.radioLab = new System.Windows.Forms.RadioButton();
            this.checkAutoSplit = new System.Windows.Forms.CheckBox();
            this.radioLevels = new System.Windows.Forms.RadioButton();
            this.radioZones = new System.Windows.Forms.RadioButton();
            this.labelSplitOn = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLoadSetup = new System.Windows.Forms.LinkLabel();
            this.checkLoadRemoval = new System.Windows.Forms.CheckBox();
            this.testButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.textLogLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.panelSplitList.SuspendLayout();
            this.groupBoxLab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxLab);
            this.groupBox1.Controls.Add(this.radioLab);
            this.groupBox1.Controls.Add(this.checkAutoSplit);
            this.groupBox1.Controls.Add(this.radioLevels);
            this.groupBox1.Controls.Add(this.radioZones);
            this.groupBox1.Controls.Add(this.labelSplitOn);
            this.groupBox1.Controls.Add(this.panelSplitList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 352);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Split";
            // 
            // panelSplitList
            // 
            this.panelSplitList.Controls.Add(this.checkedSplitList);
            this.panelSplitList.Controls.Add(this.checkSelectAll);
            this.panelSplitList.Controls.Add(this.checkIcons);
            this.panelSplitList.Controls.Add(this.createSplitsButton);
            this.panelSplitList.Location = new System.Drawing.Point(12, 88);
            this.panelSplitList.Name = "panelSplitList";
            this.panelSplitList.Size = new System.Drawing.Size(402, 258);
            this.panelSplitList.TabIndex = 5;
            // 
            // checkedSplitList
            // 
            this.checkedSplitList.CheckOnClick = true;
            this.checkedSplitList.FormattingEnabled = true;
            this.checkedSplitList.Location = new System.Drawing.Point(0, 3);
            this.checkedSplitList.Name = "checkedSplitList";
            this.checkedSplitList.Size = new System.Drawing.Size(266, 214);
            this.checkedSplitList.TabIndex = 5;
            this.checkedSplitList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.HandleItemChecked);
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(272, 200);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(117, 17);
            this.checkSelectAll.TabIndex = 10;
            this.checkSelectAll.Text = "Select/Deselect All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.HandleSelectAll);
            // 
            // checkIcons
            // 
            this.checkIcons.AutoSize = true;
            this.checkIcons.Checked = true;
            this.checkIcons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIcons.Location = new System.Drawing.Point(113, 228);
            this.checkIcons.Name = "checkIcons";
            this.checkIcons.Size = new System.Drawing.Size(77, 17);
            this.checkIcons.TabIndex = 15;
            this.checkIcons.Text = "With Icons";
            this.checkIcons.UseVisualStyleBackColor = true;
            this.checkIcons.CheckedChanged += new System.EventHandler(this.HandleIconsChecked);
            // 
            // createSplitsButton
            // 
            this.createSplitsButton.Location = new System.Drawing.Point(0, 223);
            this.createSplitsButton.Name = "createSplitsButton";
            this.createSplitsButton.Size = new System.Drawing.Size(106, 23);
            this.createSplitsButton.TabIndex = 11;
            this.createSplitsButton.Text = "Generate Splits";
            this.createSplitsButton.UseVisualStyleBackColor = true;
            this.createSplitsButton.Click += new System.EventHandler(this.HandleGenerateSplits);
            // 
            // groupBoxLab
            // 
            this.groupBoxLab.Controls.Add(this.radioAspirant);
            this.groupBoxLab.Controls.Add(this.labelLabDescription);
            this.groupBoxLab.Controls.Add(this.radioAllLab);
            this.groupBoxLab.Location = new System.Drawing.Point(12, 88);
            this.groupBoxLab.Name = "groupBoxLab";
            this.groupBoxLab.Size = new System.Drawing.Size(415, 60);
            this.groupBoxLab.TabIndex = 5;
            this.groupBoxLab.TabStop = false;
            // 
            // radioAspirant
            // 
            this.radioAspirant.AutoSize = true;
            this.radioAspirant.Location = new System.Drawing.Point(89, 33);
            this.radioAspirant.Name = "radioAspirant";
            this.radioAspirant.Size = new System.Drawing.Size(124, 17);
            this.radioAspirant.TabIndex = 12;
            this.radioAspirant.Text = "Aspirant\'s Trial zones";
            this.radioAspirant.UseVisualStyleBackColor = true;
            this.radioAspirant.CheckedChanged += new System.EventHandler(this.HandleLabTypeChanged);
            // 
            // labelLabDescription
            // 
            this.labelLabDescription.AutoSize = true;
            this.labelLabDescription.Location = new System.Drawing.Point(6, 16);
            this.labelLabDescription.MaximumSize = new System.Drawing.Size(420, 0);
            this.labelLabDescription.Name = "labelLabDescription";
            this.labelLabDescription.Size = new System.Drawing.Size(396, 13);
            this.labelLabDescription.TabIndex = 10;
            this.labelLabDescription.Text = "Starts the timer upon using the labyrinth activation device. Splits on all subseq" +
    "uent:";
            // 
            // radioAllLab
            // 
            this.radioAllLab.AutoSize = true;
            this.radioAllLab.Checked = true;
            this.radioAllLab.Location = new System.Drawing.Point(9, 33);
            this.radioAllLab.Name = "radioAllLab";
            this.radioAllLab.Size = new System.Drawing.Size(74, 17);
            this.radioAllLab.TabIndex = 11;
            this.radioAllLab.TabStop = true;
            this.radioAllLab.Text = "Lab zones";
            this.radioAllLab.UseVisualStyleBackColor = true;
            this.radioAllLab.CheckedChanged += new System.EventHandler(this.HandleLabTypeChanged);
            // 
            // radioLab
            // 
            this.radioLab.AutoSize = true;
            this.radioLab.Location = new System.Drawing.Point(136, 65);
            this.radioLab.Name = "radioLab";
            this.radioLab.Size = new System.Drawing.Size(68, 17);
            this.radioLab.TabIndex = 16;
            this.radioLab.TabStop = true;
            this.radioLab.Text = "Labyrinth";
            this.radioLab.UseVisualStyleBackColor = true;
            this.radioLab.CheckedChanged += new System.EventHandler(this.HandleSplitCriteriaChanged);
            // 
            // checkAutoSplit
            // 
            this.checkAutoSplit.AutoSize = true;
            this.checkAutoSplit.Checked = true;
            this.checkAutoSplit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoSplit.Location = new System.Drawing.Point(12, 20);
            this.checkAutoSplit.Name = "checkAutoSplit";
            this.checkAutoSplit.Size = new System.Drawing.Size(124, 17);
            this.checkAutoSplit.TabIndex = 14;
            this.checkAutoSplit.Text = "Enable Auto Splitting";
            this.checkAutoSplit.UseVisualStyleBackColor = true;
            this.checkAutoSplit.CheckedChanged += new System.EventHandler(this.HandleAutoSplitChanged);
            // 
            // radioLevels
            // 
            this.radioLevels.AutoSize = true;
            this.radioLevels.Location = new System.Drawing.Point(73, 65);
            this.radioLevels.Name = "radioLevels";
            this.radioLevels.Size = new System.Drawing.Size(56, 17);
            this.radioLevels.TabIndex = 13;
            this.radioLevels.Text = "Levels";
            this.toolTip.SetToolTip(this.radioLevels, "Performs a split when the player reaches a specific level.");
            this.radioLevels.UseVisualStyleBackColor = true;
            this.radioLevels.CheckedChanged += new System.EventHandler(this.HandleSplitCriteriaChanged);
            // 
            // radioZones
            // 
            this.radioZones.AutoSize = true;
            this.radioZones.Checked = true;
            this.radioZones.Location = new System.Drawing.Point(12, 65);
            this.radioZones.Name = "radioZones";
            this.radioZones.Size = new System.Drawing.Size(55, 17);
            this.radioZones.TabIndex = 12;
            this.radioZones.TabStop = true;
            this.radioZones.Text = "Zones";
            this.toolTip.SetToolTip(this.radioZones, "Performs a split when the player enters a specific zone for the first time.");
            this.radioZones.UseVisualStyleBackColor = true;
            this.radioZones.CheckedChanged += new System.EventHandler(this.HandleSplitCriteriaChanged);
            // 
            // labelSplitOn
            // 
            this.labelSplitOn.AutoSize = true;
            this.labelSplitOn.Location = new System.Drawing.Point(9, 49);
            this.labelSplitOn.Name = "labelSplitOn";
            this.labelSplitOn.Size = new System.Drawing.Size(45, 13);
            this.labelSplitOn.TabIndex = 1;
            this.labelSplitOn.Text = "Split on:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLoadSetup);
            this.groupBox2.Controls.Add(this.checkLoadRemoval);
            this.groupBox2.Location = new System.Drawing.Point(12, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Load Removal";
            // 
            // linkLoadSetup
            // 
            this.linkLoadSetup.AutoSize = true;
            this.linkLoadSetup.LinkArea = new System.Windows.Forms.LinkArea(132, 4);
            this.linkLoadSetup.Location = new System.Drawing.Point(12, 39);
            this.linkLoadSetup.MaximumSize = new System.Drawing.Size(420, 0);
            this.linkLoadSetup.Name = "linkLoadSetup";
            this.linkLoadSetup.Size = new System.Drawing.Size(415, 30);
            this.linkLoadSetup.TabIndex = 2;
            this.linkLoadSetup.TabStop = true;
            this.linkLoadSetup.Text = "Note that a timer operating on Game Time must be used to display the subtracted l" +
    "oad times. Setup information for that can be found here.";
            this.linkLoadSetup.UseCompatibleTextRendering = true;
            this.linkLoadSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLoadSetupClicked);
            // 
            // checkLoadRemoval
            // 
            this.checkLoadRemoval.AutoSize = true;
            this.checkLoadRemoval.Location = new System.Drawing.Point(12, 19);
            this.checkLoadRemoval.Name = "checkLoadRemoval";
            this.checkLoadRemoval.Size = new System.Drawing.Size(131, 17);
            this.checkLoadRemoval.TabIndex = 0;
            this.checkLoadRemoval.Text = "Enable Load Removal";
            this.toolTip.SetToolTip(this.checkLoadRemoval, "Removes load times from the run.");
            this.checkLoadRemoval.UseVisualStyleBackColor = true;
            this.checkLoadRemoval.CheckedChanged += new System.EventHandler(this.handleLoadRemovalChanged);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(377, 476);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.HandleTestClick);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(296, 476);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.HandleBrowseClick);
            // 
            // textLogLocation
            // 
            this.textLogLocation.Location = new System.Drawing.Point(24, 476);
            this.textLogLocation.Name = "textLogLocation";
            this.textLogLocation.Size = new System.Drawing.Size(266, 20);
            this.textLogLocation.TabIndex = 2;
            this.toolTip.SetToolTip(this.textLogLocation, "Used to detect load screen durations and zone locations.");
            this.textLogLocation.TextChanged += new System.EventHandler(this.handleLogLocationChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client log file location:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Client.txt";
            this.openFileDialog.Filter = "Text files|*.txt";
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textLogLocation);
            this.Controls.Add(this.label1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(476, 512);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelSplitList.ResumeLayout(false);
            this.panelSplitList.PerformLayout();
            this.groupBoxLab.ResumeLayout(false);
            this.groupBoxLab.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox textLogLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkLoadRemoval;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.LinkLabel linkLoadSetup;
        private System.Windows.Forms.CheckedListBox checkedSplitList;
        private System.Windows.Forms.Label labelSplitOn;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.Button createSplitsButton;
        private System.Windows.Forms.RadioButton radioLevels;
        private System.Windows.Forms.RadioButton radioZones;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkAutoSplit;
        private System.Windows.Forms.CheckBox checkIcons;
        private System.Windows.Forms.Label labelLabDescription;
        private System.Windows.Forms.RadioButton radioAllLab;
        private System.Windows.Forms.RadioButton radioAspirant;
        private System.Windows.Forms.RadioButton radioLab;
        private System.Windows.Forms.GroupBox groupBoxLab;
        private System.Windows.Forms.Panel panelSplitList;
    }
}

