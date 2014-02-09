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
    public partial class RegisterForm : Form
    {
        private Imgur imgur;

        public RegisterForm(Imgur imgur)
        {
            this.imgur = imgur;

            this.BackgroundImage = Image.FromFile(Resources.BackgroundImagePath);
            this.InitializeComponent();

        }

        private void authorize_Click(object sender, EventArgs e)
        {
            this.imgur.RegisterUser();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                this.imgur.RefreshTokens(this.pinTextBox.Text);
            }
            catch (WebException ex)
            {
                return;
            }

            this.Close();
        }
    }
}
