namespace DVLD.Application.Replacement_application
{
    partial class frmReplacementApplication
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
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbtnLostLicense = new System.Windows.Forms.RadioButton();
            this.rbtnDamagedLicense = new System.Windows.Forms.RadioButton();
            this.lbHeader = new System.Windows.Forms.Label();
            this.lbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.applicationInfoForLicenseReplacementCtrl1 = new DVLD.ctrls.ApplicationCtrls.ApplicationInfoForLicenseReplacementCtrl();
            this.driverLicenseInfoCtrl1 = new DVLD.ctrls.DriverLicenseInfoCtrl();
            this.filterLicenseCtrl1 = new DVLD.ctrls.FilterLicenseCtrl();
            this.gbReplacementFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbtnLostLicense);
            this.gbReplacementFor.Controls.Add(this.rbtnDamagedLicense);
            this.gbReplacementFor.Location = new System.Drawing.Point(665, 77);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(156, 100);
            this.gbReplacementFor.TabIndex = 2;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For";
            // 
            // rbtnLostLicense
            // 
            this.rbtnLostLicense.AutoSize = true;
            this.rbtnLostLicense.Location = new System.Drawing.Point(18, 66);
            this.rbtnLostLicense.Name = "rbtnLostLicense";
            this.rbtnLostLicense.Size = new System.Drawing.Size(85, 17);
            this.rbtnLostLicense.TabIndex = 1;
            this.rbtnLostLicense.TabStop = true;
            this.rbtnLostLicense.Text = "Lost License";
            this.rbtnLostLicense.UseVisualStyleBackColor = true;
            this.rbtnLostLicense.CheckedChanged += new System.EventHandler(this.rbtnLostLicense_CheckedChanged);
            // 
            // rbtnDamagedLicense
            // 
            this.rbtnDamagedLicense.AutoSize = true;
            this.rbtnDamagedLicense.Location = new System.Drawing.Point(18, 33);
            this.rbtnDamagedLicense.Name = "rbtnDamagedLicense";
            this.rbtnDamagedLicense.Size = new System.Drawing.Size(111, 17);
            this.rbtnDamagedLicense.TabIndex = 0;
            this.rbtnDamagedLicense.TabStop = true;
            this.rbtnDamagedLicense.Text = "Damaged License";
            this.rbtnDamagedLicense.UseVisualStyleBackColor = true;
            this.rbtnDamagedLicense.CheckedChanged += new System.EventHandler(this.rbtnDamagedLicense_CheckedChanged);
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbHeader.Location = new System.Drawing.Point(136, 9);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(482, 33);
            this.lbHeader.TabIndex = 3;
            this.lbHeader.Text = "Replacement For Damaged License";
            // 
            // lbShowLicenseInfo
            // 
            this.lbShowLicenseInfo.AutoSize = true;
            this.lbShowLicenseInfo.Enabled = false;
            this.lbShowLicenseInfo.Location = new System.Drawing.Point(139, 837);
            this.lbShowLicenseInfo.Name = "lbShowLicenseInfo";
            this.lbShowLicenseInfo.Size = new System.Drawing.Size(120, 13);
            this.lbShowLicenseInfo.TabIndex = 57;
            this.lbShowLicenseInfo.TabStop = true;
            this.lbShowLicenseInfo.Text = "Show New License Info";
            this.lbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseInfo_LinkClicked);
            // 
            // lbShowLicenseHistory
            // 
            this.lbShowLicenseHistory.AutoSize = true;
            this.lbShowLicenseHistory.Enabled = false;
            this.lbShowLicenseHistory.Location = new System.Drawing.Point(9, 838);
            this.lbShowLicenseHistory.Name = "lbShowLicenseHistory";
            this.lbShowLicenseHistory.Size = new System.Drawing.Size(109, 13);
            this.lbShowLicenseHistory.TabIndex = 56;
            this.lbShowLicenseHistory.TabStop = true;
            this.lbShowLicenseHistory.Text = "Show License History";
            this.lbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseHistory_LinkClicked);
            // 
            // btnIssue
            // 
            this.btnIssue.Image = global::DVLD.Properties.Resources.global_settings;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(403, 811);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(75, 39);
            this.btnIssue.TabIndex = 55;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(312, 811);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 39);
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // applicationInfoForLicenseReplacementCtrl1
            // 
            this.applicationInfoForLicenseReplacementCtrl1.Location = new System.Drawing.Point(12, 559);
            this.applicationInfoForLicenseReplacementCtrl1.Name = "applicationInfoForLicenseReplacementCtrl1";
            this.applicationInfoForLicenseReplacementCtrl1.Size = new System.Drawing.Size(796, 253);
            this.applicationInfoForLicenseReplacementCtrl1.TabIndex = 4;
            // 
            // driverLicenseInfoCtrl1
            // 
            this.driverLicenseInfoCtrl1.Location = new System.Drawing.Point(12, 194);
            this.driverLicenseInfoCtrl1.Name = "driverLicenseInfoCtrl1";
            this.driverLicenseInfoCtrl1.Size = new System.Drawing.Size(720, 368);
            this.driverLicenseInfoCtrl1.TabIndex = 1;
            // 
            // filterLicenseCtrl1
            // 
            this.filterLicenseCtrl1.Location = new System.Drawing.Point(12, 97);
            this.filterLicenseCtrl1.Name = "filterLicenseCtrl1";
            this.filterLicenseCtrl1.Size = new System.Drawing.Size(628, 80);
            this.filterLicenseCtrl1.TabIndex = 0;
            // 
            // frmReplacementApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(827, 860);
            this.Controls.Add(this.lbShowLicenseInfo);
            this.Controls.Add(this.lbShowLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.applicationInfoForLicenseReplacementCtrl1);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.driverLicenseInfoCtrl1);
            this.Controls.Add(this.filterLicenseCtrl1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplacementApplication";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replacement Licenses Application";
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrls.FilterLicenseCtrl filterLicenseCtrl1;
        private ctrls.DriverLicenseInfoCtrl driverLicenseInfoCtrl1;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbtnLostLicense;
        private System.Windows.Forms.RadioButton rbtnDamagedLicense;
        private System.Windows.Forms.Label lbHeader;
        private ctrls.ApplicationCtrls.ApplicationInfoForLicenseReplacementCtrl applicationInfoForLicenseReplacementCtrl1;
        private System.Windows.Forms.LinkLabel lbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lbShowLicenseHistory;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
    }
}