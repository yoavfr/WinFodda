using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Fodda
{
    class ShellCopy
    {
        protected IDebugOutput DebugOutput
        {
            get;
            set;
        }
        protected IImageDisplay ImageDisplay
        {
            get;
            set;
        }
        public string DestinationDirectory
        {
            get;
            set;
        }
        public IDirectoryNameFactory DirectoryNameFactory
        {
            get;
            set;
        }
        private TransferredItemsStore m_TransferredItems;
        public bool IgnorePreviouslyImported
        {
            get;
            set;
        }
        public string DeviceName
        {
            get;
            protected set;
        }
        protected bool Halted
        {
            get;
            set;
        }

        public string SourceDirectory
        {
            get;
            set;
        }

        public ShellCopy(IDebugOutput debugOutput, IImageDisplay imageDisplay)
        {
            DebugOutput = debugOutput;
            ImageDisplay = imageDisplay;
        }

        public void GoFromDesktop()
        {
            using (ShellDirectoryInfo desktop = new ShellDirectoryInfo(""))
            {
                foreach (ShellDirectoryInfo sub in desktop.GetDirectories())
                {
                    DebugOutput.DebugPrint(sub.FullName);
                    try
                    {
                        if (sub.FullName.Contains(SourceDirectory))
                        {
                            Go(sub);
                            break;
                        }
                    }
                    finally
                    {
                        sub.Dispose();
                    }
                }
            }
        }

        public void Go()
        {
            Halted = false;
            Go(new ShellDirectoryInfo(SourceDirectory));
        }

        private void Go(ShellDirectoryInfo directoryInfo)
        {
            ShellDirectoryInfo[] directories = directoryInfo.GetDirectories();
            DebugOutput.DebugPrint(directoryInfo.FullName);

            foreach (ShellDirectoryInfo directory in directories)
            {
                if (Halted)
                {
                    directory.Dispose();
                    return;
                }
                Go(directory);
                directory.Dispose();
            }

            foreach (ShellFileInfo file in directoryInfo.GetFiles())
            {
                if (Halted)
                {
                    file.Dispose();
                    return;
                }

                DateTime creationTime = (DateTime)file.GetCreationTime();
                String fileName = Path.GetFileName(file.FullName);
                if (!IgnorePreviouslyImported && TransferredItems.Contains(creationTime, fileName))
                {
                    DebugOutput.DebugPrint(String.Format("Skipping {0}", file.FullName));
                }
                else
                {
                    String directoryName = Path.Combine(DestinationDirectory, DirectoryNameFactory.GetDirectoryName(creationTime));
                    DebugOutput.DebugPrint(String.Format("{0} -> {1}", file.FullName, directoryName));
                    try
                    {
                        ImageDisplay.Display(file.GetThumbnail(ImageDisplay.ImageSize));
                    }
                    catch (Exception e)
                    {
                        DebugOutput.DebugPrint(string.Format("Failed to display image of {0}/{1}", directoryName, file.FullName));
                    }
                    Directory.CreateDirectory(directoryName);
                    file.CopyTo(Path.Combine(directoryName, fileName));
                    TransferredItems.Add(creationTime, fileName);
                }
                file.Dispose();
            }
            TransferredItems.Store();
        }

        public TransferredItemsStore TransferredItems
        {
            get
            {
                if (m_TransferredItems == null)
                {
                    m_TransferredItems = new TransferredItemsStore();
                    TransferredItems.Load();
                }
                return m_TransferredItems;
            }
        }

        public void Halt()
        {
            Halted = true;
        }

    }
}
