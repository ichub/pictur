using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictur
{
    public delegate void HotKeyPress(HotKey id);

    class HotKeyFilter : IMessageFilter
    {
        public event HotKeyPress HotKeyPress;

        public void AddHotKey(HotKey id, uint vk, uint modifiers)
        {
            Interop.RegisterHotKey(IntPtr.Zero, (int)id, modifiers, vk);
        }

        public bool PreFilterMessage(ref Message message)
        {
            if (message.Msg == 0x0312) // if hot key message
            {
                if (HotKeyPress != null)
                {
                    HotKeyPress((HotKey)(int)message.WParam);
                }

                return true;
            }

            return false;
        }
    }
}
