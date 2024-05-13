namespace DVLD.ctrls.LicenseCtrls
{
    partial class filterInfoLicenseCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.driverLicenseInfoCtrl1 = new DVLD.ctrls.DriverLicenseInfoCtrl();
            this.filterLicenseCtrl1 = new DVLD.ctrls.FilterLicenseCtrl();
            this.SuspendLayout();
            // 
            // driverLicenseInfoCtrl1
            // 
            this.driverLicenseInfoCtrl1.Location = new System.Drawing.Point(12, 89);
            this.driverLicenseInfoCtrl1.Name = "driverLicenseInfoCtrl1";
            this.driverLicenseInfoCtrl1.Size = new System.Drawing.Size(720, 357);
            this.driverLicenseInfoCtrl1.TabIndex = 0;
            // 
            // filterLicenseCtrl1
            // 
            this.filterLicenseCtrl1.Location = new System.Drawing.Point(12, 3);
            this.filterLicenseCtrl1.Name = "filterLicenseCtrl1";
            this.filterLicenseCtrl1.Size = new System.Drawing.Size(628, 80);
            this.filterLicenseCtrl1.TabIndex = 1;
            // 
            // filterInfoLicenseCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filterLicenseCtrl1);
            this.Controls.Add(this.driverLicenseInfoCtrl1);
            this.Name = "filterInfoLicenseCtrl";
            this.Size = new System.Drawing.Size(740, 469);
            this.ResumeLayout(false);

        }

        #endregion

        private DriverLicenseInfoCtrl driverLicenseInfoCtrl1;
        private FilterLicenseCtrl filterLicenseCtrl1;
    }
}
