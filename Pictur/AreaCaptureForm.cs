using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictur
{
    public delegate void OnSelectedBounds(Rectangle bounds);

    public partial class AreaCaptureForm : Form
    {
        public event OnSelectedBounds SelectedBounds;

        private Nullable<Point> start;

        private Rectangle selectRect
        {
            get
            {
                return Rectangle.FromLTRB(this.start.Value.X, this.start.Value.Y, MousePosition.X, MousePosition.Y);
            }
        }

        public AreaCaptureForm()
        {
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Top = 0;
            this.Left = 0;
            this.WindowState = FormWindowState.Maximized;

            this.InitializeComponent();

            this.MouseDown += AreaCapture_MouseDown;
            this.MouseUp += AreaCapture_MouseUp;
            this.MouseMove += AreaCapture_MouseMove;

            this.Opacity = 0.5;

            this.TopMost = true;
            this.ShowInTaskbar = false;

            this.KeyDown += AreaCapture_KeyDown;
        }

        void AreaCapture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        void AreaCapture_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.start.HasValue)
            {
                this.SetSelectRectangle(this.selectRect);
            }
        }

        void AreaCapture_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.start != null)
            {
                if (this.SelectedBounds != null)
                {
                    this.SelectedBounds(this.selectRect);
                }

                this.Close();
            }
        }

        void AreaCapture_MouseDown(object sender, MouseEventArgs e)
        {
            this.start = new Point(MousePosition.X, MousePosition.Y);
            this.SetSelectRectangle(this.selectRect);
        }

        private void SetSelectRectangle(Rectangle rectangle)
        {
            this.drawBox.Visible = true;
            this.drawBox.Location = new Point(rectangle.Left, rectangle.Top);
            this.drawBox.Size = rectangle.Size;
            this.drawBox.BackColor = Color.White;
        }
    }
}
