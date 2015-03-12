namespace Fodda
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.DestinationTextBox = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.BrowseSourceButton = new System.Windows.Forms.Button();
            this.BrowseDestinationButton = new System.Windows.Forms.Button();
            this.IgnorePreviouslyImportedCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConnectDeviceButton = new System.Windows.Forms.Button();
            this.DeviceTextBox = new System.Windows.Forms.TextBox();
            this.DeviceRadioButton = new System.Windows.Forms.RadioButton();
            this.DirectoryRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HaltButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_DebugTextBox = new System.Windows.Forms.TextBox();
            this.m_PictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.MessagesToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Enabled = false;
            this.SourceTextBox.Location = new System.Drawing.Point(79, 19);
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.Size = new System.Drawing.Size(194, 20);
            this.SourceTextBox.TabIndex = 2;
            this.SourceTextBox.TextChanged += new System.EventHandler(this.SourceTextBox_TextChanged);
            // 
            // DestinationTextBox
            // 
            this.DestinationTextBox.Location = new System.Drawing.Point(77, 19);
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.Size = new System.Drawing.Size(194, 20);
            this.DestinationTextBox.TabIndex = 3;
            this.DestinationTextBox.Text = "C:\\Users\\Yoav\\Pictures";
            this.DestinationTextBox.TextChanged += new System.EventHandler(this.DestinationTextBox_TextChanged);
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(10, 19);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(77, 23);
            this.GoButton.TabIndex = 6;
            this.GoButton.Text = "Start";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // BrowseSourceButton
            // 
            this.BrowseSourceButton.Enabled = false;
            this.BrowseSourceButton.Location = new System.Drawing.Point(279, 17);
            this.BrowseSourceButton.Name = "BrowseSourceButton";
            this.BrowseSourceButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseSourceButton.TabIndex = 7;
            this.BrowseSourceButton.Text = "Browse";
            this.BrowseSourceButton.UseVisualStyleBackColor = true;
            this.BrowseSourceButton.Click += new System.EventHandler(this.BrowseSourceButton_Click);
            // 
            // BrowseDestinationButton
            // 
            this.BrowseDestinationButton.Location = new System.Drawing.Point(279, 17);
            this.BrowseDestinationButton.Name = "BrowseDestinationButton";
            this.BrowseDestinationButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseDestinationButton.TabIndex = 8;
            this.BrowseDestinationButton.Text = "Browse";
            this.BrowseDestinationButton.UseVisualStyleBackColor = true;
            this.BrowseDestinationButton.Click += new System.EventHandler(this.BrowseDestinationButton_Click);
            // 
            // IgnorePreviouslyImportedCheckBox
            // 
            this.IgnorePreviouslyImportedCheckBox.AutoSize = true;
            this.IgnorePreviouslyImportedCheckBox.Location = new System.Drawing.Point(79, 85);
            this.IgnorePreviouslyImportedCheckBox.Name = "IgnorePreviouslyImportedCheckBox";
            this.IgnorePreviouslyImportedCheckBox.Size = new System.Drawing.Size(149, 17);
            this.IgnorePreviouslyImportedCheckBox.TabIndex = 9;
            this.IgnorePreviouslyImportedCheckBox.Text = "Ignore previously imported";
            this.IgnorePreviouslyImportedCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConnectDeviceButton);
            this.groupBox1.Controls.Add(this.DeviceTextBox);
            this.groupBox1.Controls.Add(this.DeviceRadioButton);
            this.groupBox1.Controls.Add(this.DirectoryRadioButton);
            this.groupBox1.Controls.Add(this.SourceTextBox);
            this.groupBox1.Controls.Add(this.IgnorePreviouslyImportedCheckBox);
            this.groupBox1.Controls.Add(this.BrowseSourceButton);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // ConnectDeviceButton
            // 
            this.ConnectDeviceButton.Location = new System.Drawing.Point(279, 42);
            this.ConnectDeviceButton.Name = "ConnectDeviceButton";
            this.ConnectDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectDeviceButton.TabIndex = 13;
            this.ConnectDeviceButton.Text = "Connect";
            this.ConnectDeviceButton.UseVisualStyleBackColor = true;
            this.ConnectDeviceButton.Click += new System.EventHandler(this.ConnectDeviceButton_Click);
            // 
            // DeviceTextBox
            // 
            this.DeviceTextBox.Enabled = false;
            this.DeviceTextBox.Location = new System.Drawing.Point(79, 44);
            this.DeviceTextBox.Name = "DeviceTextBox";
            this.DeviceTextBox.Size = new System.Drawing.Size(194, 20);
            this.DeviceTextBox.TabIndex = 12;
            // 
            // DeviceRadioButton
            // 
            this.DeviceRadioButton.AutoSize = true;
            this.DeviceRadioButton.Checked = true;
            this.DeviceRadioButton.Location = new System.Drawing.Point(6, 45);
            this.DeviceRadioButton.Name = "DeviceRadioButton";
            this.DeviceRadioButton.Size = new System.Drawing.Size(59, 17);
            this.DeviceRadioButton.TabIndex = 11;
            this.DeviceRadioButton.TabStop = true;
            this.DeviceRadioButton.Text = "Device";
            this.DeviceRadioButton.UseVisualStyleBackColor = true;
            // 
            // DirectoryRadioButton
            // 
            this.DirectoryRadioButton.AutoSize = true;
            this.DirectoryRadioButton.Location = new System.Drawing.Point(6, 20);
            this.DirectoryRadioButton.Name = "DirectoryRadioButton";
            this.DirectoryRadioButton.Size = new System.Drawing.Size(67, 17);
            this.DirectoryRadioButton.TabIndex = 10;
            this.DirectoryRadioButton.Text = "Directory";
            this.DirectoryRadioButton.UseVisualStyleBackColor = true;
            this.DirectoryRadioButton.CheckedChanged += new System.EventHandler(this.DirectoryRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DestinationTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.BrowseDestinationButton);
            this.groupBox2.Location = new System.Drawing.Point(15, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 56);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Directory";
            // 
            // HaltButton
            // 
            this.HaltButton.Enabled = false;
            this.HaltButton.Location = new System.Drawing.Point(93, 19);
            this.HaltButton.Name = "HaltButton";
            this.HaltButton.Size = new System.Drawing.Size(77, 23);
            this.HaltButton.TabIndex = 12;
            this.HaltButton.Text = "Cancel";
            this.HaltButton.UseVisualStyleBackColor = true;
            this.HaltButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_DebugTextBox);
            this.groupBox3.Controls.Add(this.HaltButton);
            this.groupBox3.Controls.Add(this.GoButton);
            this.groupBox3.Location = new System.Drawing.Point(15, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(629, 54);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transfer Images and Video";
            // 
            // m_DebugTextBox
            // 
            this.m_DebugTextBox.Location = new System.Drawing.Point(177, 20);
            this.m_DebugTextBox.Name = "m_DebugTextBox";
            this.m_DebugTextBox.ReadOnly = true;
            this.m_DebugTextBox.Size = new System.Drawing.Size(446, 20);
            this.m_DebugTextBox.TabIndex = 13;
            this.MessagesToolTip.SetToolTip(this.m_DebugTextBox, "Use Ctrl-D to display all messages");
            // 
            // m_PictureBox
            // 
            this.m_PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PictureBox.Location = new System.Drawing.Point(6, 17);
            this.m_PictureBox.Name = "m_PictureBox";
            this.m_PictureBox.Size = new System.Drawing.Size(188, 148);
            this.m_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_PictureBox.TabIndex = 14;
            this.m_PictureBox.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_PictureBox);
            this.groupBox4.Location = new System.Drawing.Point(437, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 171);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Preview";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 253);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Fodda";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Leave += new System.EventHandler(this.MainForm_Leave);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox SourceTextBox;
        private System.Windows.Forms.TextBox DestinationTextBox;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Button BrowseSourceButton;
        private System.Windows.Forms.Button BrowseDestinationButton;
        private System.Windows.Forms.CheckBox IgnorePreviouslyImportedCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DeviceTextBox;
        private System.Windows.Forms.RadioButton DeviceRadioButton;
        private System.Windows.Forms.RadioButton DirectoryRadioButton;
        private System.Windows.Forms.Button ConnectDeviceButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button HaltButton;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.PictureBox m_PictureBox;
        private System.Windows.Forms.TextBox m_DebugTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolTip MessagesToolTip;

    }
}

