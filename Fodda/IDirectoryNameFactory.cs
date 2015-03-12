using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Fodda
{
    public interface IDirectoryNameFactory
    {
        String GetDirectoryName(DateTime date);
    }
}
