using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using System.Drawing.Drawing2D;

namespace Fodda
{
    public partial class MainForm : Form, IDebugOutput, IImageDisplay
    {
        ShellCopy m_ShellCopy;
        DebugWindow m_DebugWindow;
        RegistryKey m_RegistryKey;

        private const string DestinationDirectoryRegistryKey = "DestinationDirectory";
        private const string SourceDirectoryRegistryKey = "SourceDirectory";
        private const string DeviceTypeRegistryKey = "DeviceType";

        public MainForm()
        {
            InitializeComponent();
            IDirectoryNameFactory nameFactory = new CanonStyleDirectoryNameFactory(this);
            m_ShellCopy = new ShellCopy(this, this) { DirectoryNameFactory = nameFactory };
            m_DebugWindow = new DebugWindow();
            m_DebugWindow.Visible = false;
            GoButton.Enabled = false;

            m_RegistryKey = Registry.CurrentUser;
            m_RegistryKey = m_RegistryKey.OpenSubKey("Software", true);
            m_RegistryKey = m_RegistryKey.CreateSubKey("Fodda");
            object last = m_RegistryKey.GetValue(DestinationDirectoryRegistryKey);
            if (last != null)
            {
                DestinationTextBox.Text = last.ToString();
            }

            last = m_RegistryKey.GetValue(SourceDirectoryRegistryKey);
            if (last != null)
            {
                SourceTextBox.Text = last.ToString();
            }

            last = m_RegistryKey.GetValue(DeviceTypeRegistryKey);
            if (last != null)
            {
                DirectoryRadioButton.Checked = Convert.ToBoolean(last);
            }
        }

        public void DebugPrint(object str)
        {
            if (str == null)
            {
                return;
            }
            this.Invoke((MethodInvoker) delegate
            {
                m_DebugTextBox.Text=String.Format("{0}",str);
            });
            m_DebugWindow.DebugPrint(str);
        
        }

        public void DebugPrint(string str, params object[] parameters)
        {
            if (str == null)
            {
                return;
            }
            this.Invoke((MethodInvoker)delegate
            {
                m_DebugTextBox.Text = String.Format(str, parameters);
            });
            m_DebugWindow.DebugPrint(str, parameters);
        }


        private void GoButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(DestinationTextBox.Text.Trim()))
            {
                DebugPrint("No destination directory is set");
                return;
            }
            GoButton.Enabled = false;
            HaltButton.Enabled = true;

            m_ShellCopy.IgnorePreviouslyImported = IgnorePreviouslyImportedCheckBox.Checked;
            m_ShellCopy.DestinationDirectory = DestinationTextBox.Text.Trim();

            // can't use ThreadPool for this see http://drdobbs.com/184406096
            Thread thread = new Thread((ThreadStart)delegate
            {
                String error = null;
                try
                {
                    if (DirectoryRadioButton.Checked)
                    {
                        m_ShellCopy.SourceDirectory = SourceTextBox.Text;
                        m_ShellCopy.Go();
                    }
                    else
                    {
                        m_ShellCopy.SourceDirectory = DeviceTextBox.Text;
                        m_ShellCopy.GoFromDesktop();
                    }
                    
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
                this.Invoke((MethodInvoker) delegate
                {
                    if (error != null)
                    {
                        DebugPrint(error);
                    }
                    HaltButton.Enabled = false;
                    GoButton.Enabled = true;
                    DebugPrint("Done");
                });
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void BrowseSourceButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.SelectedPath = SourceTextBox.Text;
            openFolderDialog.Description = "Source Folder";
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                SourceTextBox.Text = openFolderDialog.SelectedPath;
            }
        }

        private void BrowseDestinationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.SelectedPath = DestinationTextBox.Text;
            openFolderDialog.Description = "Destination Folder";
            {
            if (openFolderDialog.ShowDialog(this) == DialogResult.OK)
                DestinationTextBox.Text = openFolderDialog.SelectedPath;
            }

        }

        private void DirectoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_RegistryKey.SetValue(DeviceTypeRegistryKey, DirectoryRadioButton.Checked);
            if (DirectoryRadioButton.Checked)
            {
                SourceTextBox.Enabled = true;
                BrowseSourceButton.Enabled = true;
                if (!String.IsNullOrEmpty(SourceTextBox.Text))
                {
                    GoButton.Enabled = true;
                }
                ConnectDeviceButton.Enabled = false;
            }
            else
            {
                SourceTextBox.Enabled = false;
                BrowseSourceButton.Enabled = false;

                ConnectDeviceButton.Enabled = true;
                GoButton.Enabled = false;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DebugPrint("Ready");
            Hotkey hotkey = new Hotkey(Keys.D,false,true,false,false);
            hotkey.Pressed += delegate
            {
                m_DebugWindow.Visible = !m_DebugWindow.Visible;
            };
            hotkey.Register(this);

        }

        private void ConnectDeviceButton_Click(object sender, EventArgs e)
        {
            WiaDevices wiaDevices = new WiaDevices(this);
            String deviceName = wiaDevices.ConnectDevice();
            DeviceTextBox.Text = deviceName;
            if (deviceName != null)
            {
                GoButton.Enabled = true;
                DebugPrint("Ready");
            }
            else
            {
                GoButton.Enabled = false;
            }
        }

        private void DestinationTextBox_TextChanged(object sender, EventArgs e)
        {
            m_RegistryKey.SetValue(DestinationDirectoryRegistryKey, DestinationTextBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_ShellCopy.Halt();
        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            m_RegistryKey.Close();
            m_ShellCopy.Halt();
        }

        private void SourceTextBox_TextChanged(object sender, EventArgs e)
        {
            m_ShellCopy.SourceDirectory = SourceTextBox.Text;
            m_RegistryKey.SetValue(SourceDirectoryRegistryKey, SourceTextBox.Text);

            GoButton.Enabled = !String.IsNullOrEmpty(SourceTextBox.Text);

        }


        public void Display(Image image)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Image old = m_PictureBox.Image;
                m_PictureBox.Image = resizeImage(image, m_PictureBox.Size);
                if (old != null)
                {
                    old.Dispose();
                }
            });
        }

        public Size ImageSize
        {
            get
            {
                return m_PictureBox.Size;
            }
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

    }
}
