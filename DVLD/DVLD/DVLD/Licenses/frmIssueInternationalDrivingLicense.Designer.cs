namespace DVLD.Licenses
{
    partial class frmIssueInternationalDrivingLicense
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
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.driverLicenseInfoCtrl1 = new DVLD.ctrls.DriverLicenseInfoCtrl();
            this.internationalLocalApplicationInfoCTRL1 = new DVLD.ctrls.InternationalLocalApplicationInfoCTRL();
            this.filterLicenseCtrl1 = new DVLD.ctrls.FilterLicenseCtrl();
            this.lbHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIssue
            // 
            this.btnIssue.Image = global::DVLD.Properties.Resources.global_settings;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(388, 811);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(75, 39);
            this.btnIssue.TabIndex = 51;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(297, 811);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 39);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbShowLicenseHistory
            // 
            this.lbShowLicenseHistory.AutoSize = true;
            this.lbShowLicenseHistory.Enabled = false;
            this.lbShowLicenseHistory.Location = new System.Drawing.Point(13, 837);
            this.lbShowLicenseHistory.Name = "lbShowLicenseHistory";
            this.lbShowLicenseHistory.Size = new System.Drawing.Size(109, 13);
            this.lbShowLicenseHistory.TabIndex = 52;
            this.lbShowLicenseHistory.TabStop = true;
            this.lbShowLicenseHistory.Text = "Show License History";
            this.lbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseHistory_LinkClicked);
            // 
            // lbShowLicenseInfo
            // 
            this.lbShowLicenseInfo.AutoSize = true;
            this.lbShowLicenseInfo.Enabled = false;
            this.lbShowLicenseInfo.Location = new System.Drawing.Point(143, 837);
            this.lbShowLicenseInfo.Name = "lbShowLicenseInfo";
            this.lbShowLicenseInfo.Size = new System.Drawing.Size(95, 13);
            this.lbShowLicenseInfo.TabIndex = 53;
            this.lbShowLicenseInfo.TabStop = true;
            this.lbShowLicenseInfo.Text = "Show License Info";
            this.lbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseInfo_LinkClicked);
            // 
            // driverLicenseInfoCtrl1
            // 
            this.driverLicenseInfoCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.driverLicenseInfoCtrl1.Location = new System.Drawing.Point(12, 121);
            this.driverLicenseInfoCtrl1.Name = "driverLicenseInfoCtrl1";
            this.driverLicenseInfoCtrl1.Size = new System.Drawing.Size(720, 386);
            this.driverLicenseInfoCtrl1.TabIndex = 2;
            // 
            // internationalLocalApplicationInfoCTRL1
            // 
            this.internationalLocalApplicationInfoCTRL1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.internationalLocalApplicationInfoCTRL1.Location = new System.Drawing.Point(12, 513);
            this.internationalLocalApplicationInfoCTRL1.Name = "internationalLocalApplicationInfoCTRL1";
            this.internationalLocalApplicationInfoCTRL1.Size = new System.Drawing.Size(803, 261);
            this.internationalLocalApplicationInfoCTRL1.TabIndex = 1;
            // 
            // filterLicenseCtrl1
            // 
            this.filterLicenseCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filterLicenseCtrl1.Location = new System.Drawing.Point(12, 45);
            this.filterLicenseCtrl1.Name = "filterLicenseCtrl1";
            this.filterLicenseCtrl1.Size = new System.Drawing.Size(628, 70);
            this.filterLicenseCtrl1.TabIndex = 0;
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.Red;
            this.lbHeader.Location = new System.Drawing.Point(218, 13);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(359, 29);
            this.lbHeader.TabIndex = 54;
            this.lbHeader.Text = "International License Application";
            // 
            // frmIssueInternationalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(818, 862);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.lbShowLicenseInfo);
            this.Controls.Add(this.lbShowLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.driverLicenseInfoCtrl1);
            this.Controls.Add(this.internationalLocalApplicationInfoCTRL1);
            this.Controls.Add(this.filterLicenseCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueInternationalDrivingLicense";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue International Driving License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrls.FilterLicenseCtrl filterLicenseCtrl1;
        private ctrls.InternationalLocalApplicationInfoCTRL internationalLocalApplicationInfoCTRL1;
        private ctrls.DriverLicenseInfoCtrl driverLicenseInfoCtrl1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lbShowLicenseHistory;
        private System.Windows.Forms.LinkLabel lbShowLicenseInfo;
        private System.Windows.Forms.Label lbHeader;
    }
}