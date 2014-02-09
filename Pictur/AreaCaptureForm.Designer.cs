namespace Pictur
{
    partial class AreaCaptureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).BeginInit();
            this.SuspendLayout();
            // 
            // drawBox
            // 
            this.drawBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.drawBox.Location = new System.Drawing.Point(12, 12);
            this.drawBox.Name = "drawBox";
            this.drawBox.Size = new System.Drawing.Size(131, 93);
            this.drawBox.TabIndex = 0;
            this.drawBox.TabStop = false;
            this.drawBox.Visible = false;
            // 
            // AreaCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.drawBox);
            this.Name = "AreaCapture";
            this.Text = "AreaCapture";
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawBox;

    }
}