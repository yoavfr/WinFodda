using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fodda
{
    public partial class DebugWindow : Form, IDebugOutput
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        public void DebugPrint(object str)
        {
            if (str == null)
            {
                return;
            }
            this.SafeInvoke(() =>
                {
                    if (Handle == null)
                    {
                        debugListBox.Items.Add(str);
                    }
                    else
                    {
                        debugListBox.Items.Add(str);
                        debugListBox.SelectedIndex = debugListBox.Items.Count - 1;
                        debugListBox.SelectedIndex = -1;
                    }
                });
        }

        public void DebugPrint(string str, params object[] parameters)
        {
            if (str == null)
            {
                return;
            }
            this.SafeInvoke(() =>
                {
                    if (Handle == null)
                    {
                        debugListBox.Items.Add(String.Format(str, parameters));
                    }
                    else
                    {
                        debugListBox.Items.Add(String.Format(str, parameters));
                        debugListBox.SelectedIndex = debugListBox.Items.Count - 1;
                        debugListBox.SelectedIndex = -1;
                    }
                });
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copySelectedDebugListBox();
        }

        private void copySelectedDebugListBox()
        {
            StringBuilder builder = new StringBuilder();
            foreach (object item in debugListBox.SelectedItems)
            {
                builder.Append(String.Format("{0}", item));
                builder.Append("\n");
            }
            Clipboard.SetText(builder.ToString());
        }


        private void debugListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                // CTRL-A
                case (char)1:
                    for (int i = 0; i < debugListBox.Items.Count; i++)
                    {
                        debugListBox.SetSelected(i, true);
                    }
                    break;
                //CTRL-C
                case (char)3:
                    copySelectedDebugListBox();
                    break;
            }
        }

        private void DebugWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }

    }
}
