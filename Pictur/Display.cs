using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Pictur
{
    static class Display
    {
        private static readonly Size screenSize;

        static Display()
        {
            screenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        public static Image BoundedScreenshot(Rectangle bounds)
        {
            Bitmap screenShotBMP = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

            Graphics screenShotGraphics = Graphics.FromImage(screenShotBMP);

            screenShotGraphics.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);

            screenShotGraphics.Dispose();

            return screenShotBMP;
        }

        public static Image WindowScreenshot(IntPtr windowHandle)
        {
            Rectangle bounds = Interop.GetWindowBounds(windowHandle);

            return Display.BoundedScreenshot(bounds);
        }

        public static Image Screenshot()
        {
            return Display.BoundedScreenshot(new Rectangle(Point.Empty, screenSize));
        }

        public static string ToBase64(this Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }
}
