namespace DVLD.Licenses
{
    partial class frmLicenseInfo
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
            this.lbHeader = new System.Windows.Forms.Label();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.driverLicenseInfoCtrl1 = new DVLD.ctrls.DriverLicenseInfoCtrl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.IndianRed;
            this.lbHeader.Location = new System.Drawing.Point(258, 87);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(231, 29);
            this.lbHeader.TabIndex = 6;
            this.lbHeader.Text = "Driver License Info";
            // 
            // pbHeader
            // 
            this.pbHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbHeader.Image = global::DVLD.Properties.Resources.id__2_;
            this.pbHeader.Location = new System.Drawing.Point(344, 12);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(72, 72);
            this.pbHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbHeader.TabIndex = 8;
            this.pbHeader.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(334, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // driverLicenseInfoCtrl1
            // 
            this.driverLicenseInfoCtrl1.BackColor = System.Drawing.Color.White;
            this.driverLicenseInfoCtrl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.driverLicenseInfoCtrl1.Location = new System.Drawing.Point(28, 119);
            this.driverLicenseInfoCtrl1.Name = "driverLicenseInfoCtrl1";
            this.driverLicenseInfoCtrl1.Size = new System.Drawing.Size(720, 442);
            this.driverLicenseInfoCtrl1.TabIndex = 7;
            this.driverLicenseInfoCtrl1.Load += new System.EventHandler(this.driverLicenseInfoCtrl1_Load);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 635);
            this.panel1.TabIndex = 9;
            // 
            // frmLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 635);
            this.Controls.Add(this.pbHeader);
            this.Controls.Add(this.driverLicenseInfoCtrl1);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicenseInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License Info";
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbHeader;
        private ctrls.DriverLicenseInfoCtrl driverLicenseInfoCtrl1;
        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.Panel panel1;
    }
}