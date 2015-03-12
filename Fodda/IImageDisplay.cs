using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Fodda
{
    interface IImageDisplay
    {
        void Display(Image image);
        Size ImageSize
        {
            get;
        }
    }
}
