namespace DVLD.users
{
    partial class frmShowUserDetails
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
            this.personInfoCtrl1 = new DVLD.PersonInfoCtrl();
            this.loginInfoCtrl1 = new DVLD.loginInfoCtrl();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personInfoCtrl1
            // 
            this.personInfoCtrl1.Location = new System.Drawing.Point(12, 0);
            this.personInfoCtrl1.Name = "personInfoCtrl1";
            this.personInfoCtrl1.Size = new System.Drawing.Size(931, 384);
            this.personInfoCtrl1.TabIndex = 0;
            // 
            // loginInfoCtrl1
            // 
            this.loginInfoCtrl1.Location = new System.Drawing.Point(30, 390);
            this.loginInfoCtrl1.Name = "loginInfoCtrl1";
            this.loginInfoCtrl1.Size = new System.Drawing.Size(697, 80);
            this.loginInfoCtrl1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.cross__1_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(928, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DVLD.Properties.Resources.cross__1_;
            this.btnExit.Location = new System.Drawing.Point(1012, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(21, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmShowUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1033, 504);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.loginInfoCtrl1);
            this.Controls.Add(this.personInfoCtrl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowUserDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private PersonInfoCtrl personInfoCtrl1;
        private loginInfoCtrl loginInfoCtrl1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClose;
    }
}