namespace DVLD.Application.DetainAndReleaseApplication.ReleaseApplication
{
    partial class frmReleasedApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.releaseInfoCtrl1 = new DVLD.ctrls.ApplicationCtrls.ReleaseInfoCtrl();
            this.filterInfoLicenseCtrl1 = new DVLD.ctrls.LicenseCtrls.filterInfoLicenseCtrl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(195, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Release detain license";
            // 
            // lbShowLicenseInfo
            // 
            this.lbShowLicenseInfo.AutoSize = true;
            this.lbShowLicenseInfo.Enabled = false;
            this.lbShowLicenseInfo.LinkColor = System.Drawing.Color.Red;
            this.lbShowLicenseInfo.Location = new System.Drawing.Point(120, 814);
            this.lbShowLicenseInfo.Name = "lbShowLicenseInfo";
            this.lbShowLicenseInfo.Size = new System.Drawing.Size(95, 13);
            this.lbShowLicenseInfo.TabIndex = 60;
            this.lbShowLicenseInfo.TabStop = true;
            this.lbShowLicenseInfo.Text = "Show License Info";
            this.lbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lbShowLicenseInfo_LinkClicked);
            // 
            // lbShowLicenseHistory
            // 
            this.lbShowLicenseHistory.AutoSize = true;
            this.lbShowLicenseHistory.Enabled = false;
            this.lbShowLicenseHistory.LinkColor = System.Drawing.Color.Red;
            this.lbShowLicenseHistory.Location = new System.Drawing.Point(5, 814);
            this.lbShowLicenseHistory.Name = "lbShowLicenseHistory";
            this.lbShowLicenseHistory.Size = new System.Drawing.Size(109, 13);
            this.lbShowLicenseHistory.TabIndex = 59;
            this.lbShowLicenseHistory.TabStop = true;
            this.lbShowLicenseHistory.Text = "Show License History";
            this.lbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lbShowLicenseHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.cross__1_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(241, 789);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 40);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Enabled = false;
            this.btnRelease.Image = global::DVLD.Properties.Resources.hand__1_;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelease.Location = new System.Drawing.Point(335, 789);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(88, 40);
            this.btnRelease.TabIndex = 57;
            this.btnRelease.Text = "Release";
            this.btnRelease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // releaseInfoCtrl1
            // 
            this.releaseInfoCtrl1.Enabled = false;
            this.releaseInfoCtrl1.Location = new System.Drawing.Point(12, 520);
            this.releaseInfoCtrl1.Name = "releaseInfoCtrl1";
            this.releaseInfoCtrl1.Size = new System.Drawing.Size(728, 263);
            this.releaseInfoCtrl1.TabIndex = 3;
            // 
            // filterInfoLicenseCtrl1
            // 
            this.filterInfoLicenseCtrl1.Location = new System.Drawing.Point(0, 59);
            this.filterInfoLicenseCtrl1.Name = "filterInfoLicenseCtrl1";
            this.filterInfoLicenseCtrl1.Size = new System.Drawing.Size(752, 455);
            this.filterInfoLicenseCtrl1.TabIndex = 0;
            // 
            // frmReleasedApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 836);
            this.Controls.Add(this.lbShowLicenseInfo);
            this.Controls.Add(this.lbShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.releaseInfoCtrl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterInfoLicenseCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReleasedApplication";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Released Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrls.LicenseCtrls.filterInfoLicenseCtrl filterInfoLicenseCtrl1;
        private System.Windows.Forms.Label label1;
        private ctrls.ApplicationCtrls.ReleaseInfoCtrl releaseInfoCtrl1;
        private System.Windows.Forms.LinkLabel lbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lbShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;
    }
}