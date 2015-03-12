using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Fodda
{
    class WiaDevices
    {
        IDebugOutput DebugOutput
        {
            get;
            set;
        }

        public WiaDevices(IDebugOutput debugOutput)
        {
            DebugOutput = debugOutput;
        }

        public String ConnectDevice()
        {
            DeviceManager deviceManager = new DeviceManagerClass();
            if (deviceManager.DeviceInfos.Count < 1)
            {
                DebugOutput.DebugPrint("No devices connected");
                return null;
            }
            CommonDialogClass dialog = new CommonDialogClass();

            Device device = dialog.ShowSelectDevice(WiaDeviceType.UnspecifiedDeviceType, true, false);
            if (device != null)
            {
                foreach (IProperty property in device.Properties)
                {
                    if (property.PropertyID == 4)
                    {
                        return property.get_Value().ToString();
                    }
                }
            }
            return null;
        }
    }
}
