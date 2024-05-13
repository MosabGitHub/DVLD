namespace DVLD.Application.RenewApplication
{
    partial class frmRenewApplication
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
            this.lbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.reNewApplicationInfoCtrl1 = new DVLD.ctrls.ApplicationCtrls.RenewApplicationInfoCtrl();
            this.driverLicenseInfoCtrl1 = new DVLD.ctrls.DriverLicenseInfoCtrl();
            this.filterLicenseCtrl1 = new DVLD.ctrls.FilterLicenseCtrl();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.Red;
            this.lbHeader.Location = new System.Drawing.Point(189, 9);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(340, 31);
            this.lbHeader.TabIndex = 0;
            this.lbHeader.Text = "Renew License Application";
            // 
            // lbShowLicenseHistory
            // 
            this.lbShowLicenseHistory.AutoSize = true;
            this.lbShowLicenseHistory.Enabled = false;
            this.lbShowLicenseHistory.Location = new System.Drawing.Point(8, 849);
            this.lbShowLicenseHistory.Name = "lbShowLicenseHistory";
            this.lbShowLicenseHistory.Size = new System.Drawing.Size(109, 13);
            this.lbShowLicenseHistory.TabIndex = 53;
            this.lbShowLicenseHistory.TabStop = true;
            this.lbShowLicenseHistory.Text = "Show License History";
            this.lbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseHistory_LinkClicked);
            // 
            // lbShowLicenseInfo
            // 
            this.lbShowLicenseInfo.AutoSize = true;
            this.lbShowLicenseInfo.Enabled = false;
            this.lbShowLicenseInfo.Location = new System.Drawing.Point(133, 849);
            this.lbShowLicenseInfo.Name = "lbShowLicenseInfo";
            this.lbShowLicenseInfo.Size = new System.Drawing.Size(95, 13);
            this.lbShowLicenseInfo.TabIndex = 54;
            this.lbShowLicenseInfo.TabStop = true;
            this.lbShowLicenseInfo.Text = "Show License Info";
            this.lbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseInfo_LinkClicked);
            // 
            // reNewApplicationInfoCtrl1
            // 
            this.reNewApplicationInfoCtrl1.Location = new System.Drawing.Point(1, 492);
            this.reNewApplicationInfoCtrl1.Name = "reNewApplicationInfoCtrl1";
            this.reNewApplicationInfoCtrl1.Size = new System.Drawing.Size(796, 325);
            this.reNewApplicationInfoCtrl1.TabIndex = 55;
            // 
            // driverLicenseInfoCtrl1
            // 
            this.driverLicenseInfoCtrl1.Location = new System.Drawing.Point(12, 120);
            this.driverLicenseInfoCtrl1.Name = "driverLicenseInfoCtrl1";
            this.driverLicenseInfoCtrl1.Size = new System.Drawing.Size(720, 366);
            this.driverLicenseInfoCtrl1.TabIndex = 2;
            // 
            // filterLicenseCtrl1
            // 
            this.filterLicenseCtrl1.Location = new System.Drawing.Point(12, 43);
            this.filterLicenseCtrl1.Name = "filterLicenseCtrl1";
            this.filterLicenseCtrl1.Size = new System.Drawing.Size(628, 80);
            this.filterLicenseCtrl1.TabIndex = 1;
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Image = global::DVLD.Properties.Resources.global_settings;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.Location = new System.Drawing.Point(379, 823);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(79, 39);
            this.btnRenew.TabIndex = 57;
            this.btnRenew.Text = "Renew";
            this.btnRenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(289, 823);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 39);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRenewApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 867);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.reNewApplicationInfoCtrl1);
            this.Controls.Add(this.lbShowLicenseInfo);
            this.Controls.Add(this.lbShowLicenseHistory);
            this.Controls.Add(this.driverLicenseInfoCtrl1);
            this.Controls.Add(this.filterLicenseCtrl1);
            this.Controls.Add(this.lbHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRenewApplication";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Renew Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHeader;
        private ctrls.FilterLicenseCtrl filterLicenseCtrl1;
        private ctrls.DriverLicenseInfoCtrl driverLicenseInfoCtrl1;
        private System.Windows.Forms.LinkLabel lbShowLicenseHistory;
        private System.Windows.Forms.LinkLabel lbShowLicenseInfo;
        private ctrls.ApplicationCtrls.RenewApplicationInfoCtrl reNewApplicationInfoCtrl1;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnClose;
    }
}