namespace DVLD.Application.DetainAndReleaseApplication.DetainApplications
{
    partial class frmDetainApplication
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
            this.filterInfoLicenseCtrl1 = new DVLD.ctrls.LicenseCtrls.filterInfoLicenseCtrl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.detainInfoCtrl1 = new DVLD.ctrls.ApplicationCtrls.DetainInfoCtrl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(246, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detain License";
            // 
            // filterInfoLicenseCtrl1
            // 
            this.filterInfoLicenseCtrl1.BackColor = System.Drawing.Color.LightCyan;
            this.filterInfoLicenseCtrl1.Location = new System.Drawing.Point(4, 73);
            this.filterInfoLicenseCtrl1.Name = "filterInfoLicenseCtrl1";
            this.filterInfoLicenseCtrl1.Size = new System.Drawing.Size(752, 469);
            this.filterInfoLicenseCtrl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.lbShowLicenseInfo);
            this.panel1.Controls.Add(this.lbShowLicenseHistory);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnDetain);
            this.panel1.Controls.Add(this.detainInfoCtrl1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filterInfoLicenseCtrl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 840);
            this.panel1.TabIndex = 1;
            // 
            // lbShowLicenseInfo
            // 
            this.lbShowLicenseInfo.AutoSize = true;
            this.lbShowLicenseInfo.Enabled = false;
            this.lbShowLicenseInfo.LinkColor = System.Drawing.Color.Red;
            this.lbShowLicenseInfo.Location = new System.Drawing.Point(131, 814);
            this.lbShowLicenseInfo.Name = "lbShowLicenseInfo";
            this.lbShowLicenseInfo.Size = new System.Drawing.Size(95, 13);
            this.lbShowLicenseInfo.TabIndex = 56;
            this.lbShowLicenseInfo.TabStop = true;
            this.lbShowLicenseInfo.Text = "Show License Info";
            this.lbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseInfo_LinkClicked);
            // 
            // lbShowLicenseHistory
            // 
            this.lbShowLicenseHistory.AutoSize = true;
            this.lbShowLicenseHistory.Enabled = false;
            this.lbShowLicenseHistory.LinkColor = System.Drawing.Color.Red;
            this.lbShowLicenseHistory.Location = new System.Drawing.Point(16, 814);
            this.lbShowLicenseHistory.Name = "lbShowLicenseHistory";
            this.lbShowLicenseHistory.Size = new System.Drawing.Size(109, 13);
            this.lbShowLicenseHistory.TabIndex = 55;
            this.lbShowLicenseHistory.TabStop = true;
            this.lbShowLicenseHistory.Text = "Show License History";
            this.lbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.cross__1_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(252, 793);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.Enabled = false;
            this.btnDetain.Image = global::DVLD.Properties.Resources.hand;
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetain.Location = new System.Drawing.Point(352, 793);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(75, 40);
            this.btnDetain.TabIndex = 4;
            this.btnDetain.Text = "Detain";
            this.btnDetain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // detainInfoCtrl1
            // 
            this.detainInfoCtrl1.Enabled = false;
            this.detainInfoCtrl1.Location = new System.Drawing.Point(4, 548);
            this.detainInfoCtrl1.Name = "detainInfoCtrl1";
            this.detainInfoCtrl1.Size = new System.Drawing.Size(692, 239);
            this.detainInfoCtrl1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCyan;
            this.panel2.Location = new System.Drawing.Point(4, 540);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 247);
            this.panel2.TabIndex = 3;
            // 
            // frmDetainApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 836);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainApplication";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detain Applicaion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrls.LicenseCtrls.filterInfoLicenseCtrl filterInfoLicenseCtrl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lbShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Panel panel2;
        private ctrls.ApplicationCtrls.DetainInfoCtrl detainInfoCtrl1;
    }
}