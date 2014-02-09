using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictur
{
    class HotKeyHandler
    {
        public HotKeyFilter Filter { get; private set; }

        public HotKeyHandler()
        {
            this.Filter = new HotKeyFilter();

            this.Filter.AddHotKey(HotKey.CaptureScreen, HotKeySettings.Default.FullKey, HotKeySettings.Default.FullModifiers);
            this.Filter.AddHotKey(HotKey.CaptureWindow, HotKeySettings.Default.WindowKey, HotKeySettings.Default.WindowModifiers);
            this.Filter.AddHotKey(HotKey.CaptureBounds, HotKeySettings.Default.BoundsKey, HotKeySettings.Default.BoundsModifiers);

            Application.AddMessageFilter(this.Filter);
        }
    }
}
