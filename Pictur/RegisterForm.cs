using ImgurLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictur
{
    partial class RegisterForm : Form
    {
        private PicturApp app;

        public RegisterForm(PicturApp app)
        {
            this.app = app;

            this.BackgroundImage = Image.FromFile(Resources.BackgroundImagePath);
            this.InitializeComponent();
        }

        private void authorize_Click(object sender, EventArgs e)
        {
            Process.Start(Imgur.GetRegisterUrl(PicturApp.ClientID));
        }

        private void submit_Click(object sender, EventArgs e)
        {
            app.InitTokens(pinTextBox.Text);

            this.Close();
        }
    }
}
