using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fodda
{
    public interface IDebugOutput
    {
        void DebugPrint (object str);
        void DebugPrint (string format, params object[] parameters);
    }
}
