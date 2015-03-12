using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Fodda
{
    class CanonStyleDirectoryNameFactory : IDirectoryNameFactory
    {
        private IDebugOutput DebugOutput { get; set; }
        public CanonStyleDirectoryNameFactory(IDebugOutput debugOutput)
        {
            DebugOutput = debugOutput;
        }

        public string GetDirectoryName(DateTime date)
        {
            String year = date.Year.ToString("D4");
            String month = date.Month.ToString("D2");
            String day = date.Day.ToString("D2");
            return Path.Combine(year, Path.Combine(String.Format("{0}_{1}", year, month), String.Format("{0}_{1}_{2}", year, month, day)));
        }
    }
}
