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
            this.radioSplitCustom = new System.Windows.Forms.RadioButton();
            this.radioSplitAllZones = new System.Windows.Forms.RadioButton();
            this.radioSplitByActs = new System.Windows.Forms.RadioButton();
            this.checkedListZones = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkAutoSplit = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLoadSetup = new System.Windows.Forms.LinkLabel();
            this.checkLoadRemoval = new System.Windows.Forms.CheckBox();
            this.testButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.textLogLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.autoSplitToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.loadRemovalToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.clientLocationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkLabyrinth = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkLabyrinth);
            this.groupBox1.Controls.Add(this.radioSplitCustom);
            this.groupBox1.Controls.Add(this.radioSplitAllZones);
            this.groupBox1.Controls.Add(this.radioSplitByActs);
            this.groupBox1.Controls.Add(this.checkedListZones);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkAutoSplit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Split";
            // 
            // radioSplitCustom
            // 
            this.radioSplitCustom.AutoSize = true;
            this.radioSplitCustom.Location = new System.Drawing.Point(187, 48);
            this.radioSplitCustom.Name = "radioSplitCustom";
            this.radioSplitCustom.Size = new System.Drawing.Size(60, 17);
            this.radioSplitCustom.TabIndex = 8;
            this.radioSplitCustom.Text = "Custom";
            this.radioSplitCustom.UseVisualStyleBackColor = true;
            this.radioSplitCustom.CheckedChanged += new System.EventHandler(this.HandleSplitByChanged);
            // 
            // radioSplitAllZones
            // 
            this.radioSplitAllZones.AutoSize = true;
            this.radioSplitAllZones.Location = new System.Drawing.Point(112, 48);
            this.radioSplitAllZones.Name = "radioSplitAllZones";
            this.radioSplitAllZones.Size = new System.Drawing.Size(69, 17);
            this.radioSplitAllZones.TabIndex = 7;
            this.radioSplitAllZones.Text = "All Zones";
            this.radioSplitAllZones.UseVisualStyleBackColor = true;
            this.radioSplitAllZones.CheckedChanged += new System.EventHandler(this.HandleSplitByChanged);
            // 
            // radioSplitByActs
            // 
            this.radioSplitByActs.AutoSize = true;
            this.radioSplitByActs.Checked = true;
            this.radioSplitByActs.Location = new System.Drawing.Point(60, 48);
            this.radioSplitByActs.Name = "radioSplitByActs";
            this.radioSplitByActs.Size = new System.Drawing.Size(46, 17);
            this.radioSplitByActs.TabIndex = 6;
            this.radioSplitByActs.TabStop = true;
            this.radioSplitByActs.Text = "Acts";
            this.radioSplitByActs.UseVisualStyleBackColor = true;
            this.radioSplitByActs.CheckedChanged += new System.EventHandler(this.HandleSplitByChanged);
            // 
            // checkedListZones
            // 
            this.checkedListZones.CheckOnClick = true;
            this.checkedListZones.FormattingEnabled = true;
            this.checkedListZones.Location = new System.Drawing.Point(12, 71);
            this.checkedListZones.Name = "checkedListZones";
            this.checkedListZones.Size = new System.Drawing.Size(266, 109);
            this.checkedListZones.TabIndex = 5;
            this.checkedListZones.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.HandleItemChecked);
            this.checkedListZones.SelectedIndexChanged += new System.EventHandler(this.ZoneSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Split on:";
            // 
            // checkAutoSplit
            // 
            this.checkAutoSplit.AutoSize = true;
            this.checkAutoSplit.Checked = true;
            this.checkAutoSplit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoSplit.Location = new System.Drawing.Point(12, 19);
            this.checkAutoSplit.Name = "checkAutoSplit";
            this.checkAutoSplit.Size = new System.Drawing.Size(124, 17);
            this.checkAutoSplit.TabIndex = 0;
            this.checkAutoSplit.Text = "Enable Auto Splitting";
            this.autoSplitToolTip.SetToolTip(this.checkAutoSplit, "Performs a split when the player enters a specific zone for the first time.");
            this.checkAutoSplit.UseVisualStyleBackColor = true;
            this.checkAutoSplit.CheckedChanged += new System.EventHandler(this.HandleAutoSplitChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLoadSetup);
            this.groupBox2.Controls.Add(this.checkLoadRemoval);
            this.groupBox2.Location = new System.Drawing.Point(12, 248);
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
            this.checkLoadRemoval.Checked = true;
            this.checkLoadRemoval.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLoadRemoval.Location = new System.Drawing.Point(12, 19);
            this.checkLoadRemoval.Name = "checkLoadRemoval";
            this.checkLoadRemoval.Size = new System.Drawing.Size(131, 17);
            this.checkLoadRemoval.TabIndex = 0;
            this.checkLoadRemoval.Text = "Enable Load Removal";
            this.loadRemovalToolTip.SetToolTip(this.checkLoadRemoval, "Removes load times from the run.");
            this.checkLoadRemoval.UseVisualStyleBackColor = true;
            this.checkLoadRemoval.CheckedChanged += new System.EventHandler(this.handleLoadRemovalChanged);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(24, 395);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.HandleTestClick);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(296, 369);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.HandleBrowseClick);
            // 
            // textLogLocation
            // 
            this.textLogLocation.Location = new System.Drawing.Point(24, 369);
            this.textLogLocation.Name = "textLogLocation";
            this.textLogLocation.Size = new System.Drawing.Size(266, 20);
            this.textLogLocation.TabIndex = 2;
            this.clientLocationToolTip.SetToolTip(this.textLogLocation, "Used to detect load screen durations and zone locations.");
            this.textLogLocation.TextChanged += new System.EventHandler(this.handleLogLocationChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client log file location:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Text files|*.txt";
            // 
            // checkLabyrinth
            // 
            this.checkLabyrinth.AutoSize = true;
            this.checkLabyrinth.Location = new System.Drawing.Point(12, 186);
            this.checkLabyrinth.Name = "checkLabyrinth";
            this.checkLabyrinth.Size = new System.Drawing.Size(140, 17);
            this.checkLabyrinth.TabIndex = 9;
            this.checkLabyrinth.Text = "Split on Labyrinth Zones";
            this.checkLabyrinth.UseVisualStyleBackColor = true;
            this.checkLabyrinth.CheckedChanged += new System.EventHandler(this.HandleCheckLabyrinth);
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
            this.Size = new System.Drawing.Size(476, 436);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkAutoSplit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox textLogLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkLoadRemoval;
        private System.Windows.Forms.ToolTip autoSplitToolTip;
        private System.Windows.Forms.ToolTip loadRemovalToolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.ToolTip clientLocationToolTip;
        private System.Windows.Forms.LinkLabel linkLoadSetup;
        private System.Windows.Forms.CheckedListBox checkedListZones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioSplitCustom;
        private System.Windows.Forms.RadioButton radioSplitAllZones;
        private System.Windows.Forms.RadioButton radioSplitByActs;
        private System.Windows.Forms.CheckBox checkLabyrinth;
    }
}

