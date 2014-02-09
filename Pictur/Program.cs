using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictur
{
    static class Program
    {
        public const bool Debugging = true;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PicturApp app = new PicturApp();

            Application.Run();
        }
    }
}
