namespace Pictur
{
    partial class RegisterForm
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
            this.pinTextBox = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.authorize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pinTextBox
            // 
            this.pinTextBox.Location = new System.Drawing.Point(12, 42);
            this.pinTextBox.Name = "pinTextBox";
            this.pinTextBox.Size = new System.Drawing.Size(179, 20);
            this.pinTextBox.TabIndex = 0;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(197, 40);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 1;
            this.submit.Text = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // authorize
            // 
            this.authorize.Location = new System.Drawing.Point(12, 13);
            this.authorize.Name = "authorize";
            this.authorize.Size = new System.Drawing.Size(260, 23);
            this.authorize.TabIndex = 2;
            this.authorize.Text = "Authorize Imgur Account!";
            this.authorize.UseVisualStyleBackColor = true;
            this.authorize.Click += new System.EventHandler(this.authorize_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.authorize);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.pinTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pinTextBox;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button authorize;
    }
}