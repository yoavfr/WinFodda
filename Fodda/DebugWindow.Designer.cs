namespace Fodda
{
    partial class DebugWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWindow));
            this.debugListBox = new System.Windows.Forms.ListBox();
            this.debugMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // debugListBox
            // 
            this.debugListBox.ContextMenuStrip = this.debugMenuStrip1;
            this.debugListBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.debugListBox.FormattingEnabled = true;
            this.debugListBox.HorizontalScrollbar = true;
            this.debugListBox.Location = new System.Drawing.Point(12, 12);
            this.debugListBox.Name = "debugListBox";
            this.debugListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.debugListBox.Size = new System.Drawing.Size(699, 277);
            this.debugListBox.TabIndex = 1;
            this.debugListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.debugListBox_KeyPress);
            // 
            // debugMenuStrip1
            // 
            this.debugMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.debugMenuStrip1.Name = "debugMenuStrip1";
            this.debugMenuStrip1.Size = new System.Drawing.Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 308);
            this.Controls.Add(this.debugListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebugWindow";
            this.Text = "Messages";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugWindow_FormClosing);
            this.debugMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox debugListBox;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip debugMenuStrip1;
    }
}