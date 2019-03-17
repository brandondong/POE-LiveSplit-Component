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
            this.checkAutoSplit = new System.Windows.Forms.CheckBox();
            this.radioLevels = new System.Windows.Forms.RadioButton();
            this.radioZones = new System.Windows.Forms.RadioButton();
            this.createSplitsButton = new System.Windows.Forms.Button();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.checkedSplitList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkLabyrinth = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLoadSetup = new System.Windows.Forms.LinkLabel();
            this.checkLoadRemoval = new System.Windows.Forms.CheckBox();
            this.testButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.textLogLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkIcons = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkIcons);
            this.groupBox1.Controls.Add(this.checkAutoSplit);
            this.groupBox1.Controls.Add(this.radioLevels);
            this.groupBox1.Controls.Add(this.radioZones);
            this.groupBox1.Controls.Add(this.createSplitsButton);
            this.groupBox1.Controls.Add(this.checkSelectAll);
            this.groupBox1.Controls.Add(this.checkedSplitList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 272);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Split";
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
            this.radioLevels.Location = new System.Drawing.Point(73, 56);
            this.radioLevels.Name = "radioLevels";
            this.radioLevels.Size = new System.Drawing.Size(56, 17);
            this.radioLevels.TabIndex = 13;
            this.radioLevels.Text = "Levels";
            this.toolTip.SetToolTip(this.radioLevels, "Performs a split when the player reaches a specific level.");
            this.radioLevels.UseVisualStyleBackColor = true;
            // 
            // radioZones
            // 
            this.radioZones.AutoSize = true;
            this.radioZones.Checked = true;
            this.radioZones.Location = new System.Drawing.Point(12, 56);
            this.radioZones.Name = "radioZones";
            this.radioZones.Size = new System.Drawing.Size(55, 17);
            this.radioZones.TabIndex = 12;
            this.radioZones.TabStop = true;
            this.radioZones.Text = "Zones";
            this.toolTip.SetToolTip(this.radioZones, "Performs a split when the player enters a specific zone for the first time.");
            this.radioZones.UseVisualStyleBackColor = true;
            this.radioZones.CheckedChanged += new System.EventHandler(this.HandleSplitCriteriaChanged);
            // 
            // createSplitsButton
            // 
            this.createSplitsButton.Location = new System.Drawing.Point(12, 239);
            this.createSplitsButton.Name = "createSplitsButton";
            this.createSplitsButton.Size = new System.Drawing.Size(106, 23);
            this.createSplitsButton.TabIndex = 11;
            this.createSplitsButton.Text = "Generate Splits";
            this.createSplitsButton.UseVisualStyleBackColor = true;
            this.createSplitsButton.Click += new System.EventHandler(this.HandleGenerateSplits);
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(284, 216);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(117, 17);
            this.checkSelectAll.TabIndex = 10;
            this.checkSelectAll.Text = "Select/Deselect All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.HandleSelectAll);
            // 
            // checkedSplitList
            // 
            this.checkedSplitList.CheckOnClick = true;
            this.checkedSplitList.FormattingEnabled = true;
            this.checkedSplitList.Location = new System.Drawing.Point(12, 79);
            this.checkedSplitList.Name = "checkedSplitList";
            this.checkedSplitList.Size = new System.Drawing.Size(266, 154);
            this.checkedSplitList.TabIndex = 5;
            this.checkedSplitList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.HandleItemChecked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Split on:";
            // 
            // checkLabyrinth
            // 
            this.checkLabyrinth.AutoSize = true;
            this.checkLabyrinth.Location = new System.Drawing.Point(12, 19);
            this.checkLabyrinth.Name = "checkLabyrinth";
            this.checkLabyrinth.Size = new System.Drawing.Size(149, 17);
            this.checkLabyrinth.TabIndex = 9;
            this.checkLabyrinth.Text = "Enable Lab Speedrunning";
            this.checkLabyrinth.UseVisualStyleBackColor = true;
            this.checkLabyrinth.CheckedChanged += new System.EventHandler(this.HandleCheckLabyrinth);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLoadSetup);
            this.groupBox2.Controls.Add(this.checkLoadRemoval);
            this.groupBox2.Location = new System.Drawing.Point(12, 290);
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
            this.testButton.Location = new System.Drawing.Point(377, 469);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.HandleTestClick);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(296, 469);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.HandleBrowseClick);
            // 
            // textLogLocation
            // 
            this.textLogLocation.Location = new System.Drawing.Point(24, 469);
            this.textLogLocation.Name = "textLogLocation";
            this.textLogLocation.Size = new System.Drawing.Size(266, 20);
            this.textLogLocation.TabIndex = 2;
            this.toolTip.SetToolTip(this.textLogLocation, "Used to detect load screen durations and zone locations.");
            this.textLogLocation.TextChanged += new System.EventHandler(this.handleLogLocationChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 452);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.checkLabyrinth);
            this.groupBox3.Location = new System.Drawing.Point(12, 382);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 67);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lab Speedrunning";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 39);
            this.label3.MaximumSize = new System.Drawing.Size(420, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(407, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Starts the timer on the first labyrinth zone entered and splits on subsequent lab" +
    " zones.";
            // 
            // checkIcons
            // 
            this.checkIcons.AutoSize = true;
            this.checkIcons.Checked = true;
            this.checkIcons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIcons.Location = new System.Drawing.Point(125, 244);
            this.checkIcons.Name = "checkIcons";
            this.checkIcons.Size = new System.Drawing.Size(77, 17);
            this.checkIcons.TabIndex = 15;
            this.checkIcons.Text = "With Icons";
            this.checkIcons.UseVisualStyleBackColor = true;
            this.checkIcons.CheckedChanged += new System.EventHandler(this.HandleIconsChecked);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textLogLocation);
            this.Controls.Add(this.label1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(476, 500);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkLabyrinth;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.Button createSplitsButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioLevels;
        private System.Windows.Forms.RadioButton radioZones;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkAutoSplit;
        private System.Windows.Forms.CheckBox checkIcons;
    }
}

