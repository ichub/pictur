using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImgurLib;

namespace Pictur
{
    class PicturApp : IDisposable
    {
        public const string ClientID = "d2dc505559c21ed";
        public const string ClientSecret = "f6fb0405957614935e7e8d83b91b9c75e41da795";

        private TokenHandler tokenHandler;
        private HotKeyHandler hotKeyHandler;
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        private bool handlingHotKey;

        public PicturApp()
        {
            this.hotKeyHandler = new HotKeyHandler();
            this.tokenHandler = new TokenHandler();

            this.AttachHotKeyEvents();
            this.InitTray();

            if (this.tokenHandler.CurrentTokens == Tokens.Empty)
            {
                new RegisterForm(this).ShowDialog();
            }
        }

        public void Dispose()
        {
            this.trayIcon.Dispose();
        }

        public void InitTokens(string pin)
        {
            this.tokenHandler.UsePin(pin);
        }


        private void InitTray()
        {
            this.trayMenu = new ContextMenu();

            this.trayIcon = new NotifyIcon();
            this.trayIcon.Text = "Pictur";
            this.trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            this.trayIcon.Icon = new Icon(Resources.IconPath);

            this.trayIcon.ContextMenu = trayMenu;
            this.trayIcon.Visible = true;

            MenuItem exit = new MenuItem("Exit", (obj, e) =>
            {
                Application.Exit();
            });

            this.trayMenu.MenuItems.Add(exit);
        }

        private void AttachHotKeyEvents()
        {
            this.hotKeyHandler.Filter.HotKeyPress += key =>
            {
                if (!this.handlingHotKey)
                {
                    this.handlingHotKey = true;

                    Image capture = null;

                    if (key == HotKey.CaptureScreen)
                    {
                        capture = Display.Screenshot();
                    }
                    else if (key == HotKey.CaptureWindow)
                    {
                        capture = Display.WindowScreenshot(Interop.GetForegroundWindow());
                    }
                    else if (key == HotKey.CaptureBounds)
                    {
                        AreaCaptureForm areaWindow = new AreaCaptureForm();
                        Rectangle bounds = Rectangle.Empty;

                        areaWindow.SelectedBounds += area => { bounds = area; };

                        areaWindow.ShowDialog();

                        if (bounds != Rectangle.Empty)
                        {
                            capture = Display.BoundedScreenshot(bounds);
                        }
                    }

                    if (capture != null)
                    {
                        ImageDetails details = Imgur.UploadImage(this.tokenHandler.CurrentTokens, capture);

                        this.PlayShutterSound();

                        this.DisplayImageDetails(details);
                    }

                    this.handlingHotKey = false;
                }
            };
        }

        private void DisplayImageDetails(ImageDetails details)
        {
            this.trayIcon.BalloonTipTitle = "Success!";
            this.trayIcon.BalloonTipText = "Image Uploaded!";

            this.trayIcon.BalloonTipClicked += (obj, e) =>
            {
                Process.Start(details.Link);
            };

            this.trayIcon.ShowBalloonTip(1000);
        }

        private void PlayShutterSound()
        {
            using (SoundPlayer player = new SoundPlayer())
            {
                player.SoundLocation = Resources.ShutterSoundPath;
                player.Play();
            }
        }

        private void MakeRunAtStartup()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            key.SetValue("Pictur", Application.ExecutablePath);
        }
    }
}
