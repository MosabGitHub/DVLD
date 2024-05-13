namespace DVLD.Licenses
{
    partial class frmLicenseHistory
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.driverLicenseHistoryCtrl1 = new DVLD.ctrls.DriverLicenseHistoryCtrl();
            this.personInfoCtrl4 = new DVLD.PersonInfoCtrl();
            this.filterCtrl4 = new DVLD.ctrls.FilterCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.Red;
            this.lbHeader.Location = new System.Drawing.Point(407, 9);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(250, 37);
            this.lbHeader.TabIndex = 3;
            this.lbHeader.Text = "Licenses History";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.driver_down;
            this.pictureBox3.Location = new System.Drawing.Point(949, 127);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(75, 76);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.cross__1_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(960, 728);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 42);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // driverLicenseHistoryCtrl1
            // 
            this.driverLicenseHistoryCtrl1.Location = new System.Drawing.Point(12, 468);
            this.driverLicenseHistoryCtrl1.Name = "driverLicenseHistoryCtrl1";
            this.driverLicenseHistoryCtrl1.Size = new System.Drawing.Size(951, 333);
            this.driverLicenseHistoryCtrl1.TabIndex = 2;
            // 
            // personInfoCtrl4
            // 
            this.personInfoCtrl4.Location = new System.Drawing.Point(12, 85);
            this.personInfoCtrl4.Name = "personInfoCtrl4";
            this.personInfoCtrl4.Size = new System.Drawing.Size(931, 384);
            this.personInfoCtrl4.TabIndex = 1;
            // 
            // filterCtrl4
            // 
            this.filterCtrl4.Enabled = false;
            this.filterCtrl4.Location = new System.Drawing.Point(12, 61);
            this.filterCtrl4.Name = "filterCtrl4";
            this.filterCtrl4.Size = new System.Drawing.Size(539, 49);
            this.filterCtrl4.TabIndex = 0;
            // 
            // frmLicenseHistory
            // 
            this.ClientSize = new System.Drawing.Size(1040, 782);
            this.Controls.Add(this.filterCtrl4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.personInfoCtrl4);
            this.Controls.Add(this.driverLicenseHistoryCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrls.FilterCtrl filterCtrl1;
        private ctrls.FilterCtrl filterCtrl2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ctrls.FilterCtrl filterCtrl3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private ctrls.FilterCtrl filterCtrl4;
        private PersonInfoCtrl personInfoCtrl4;
        private ctrls.DriverLicenseHistoryCtrl driverLicenseHistoryCtrl1;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnClose;
    }
}