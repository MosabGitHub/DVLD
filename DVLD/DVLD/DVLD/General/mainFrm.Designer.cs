namespace DVLD
{
    partial class mainFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicenseServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.replacemntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.relaesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.relaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(80, 80);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 88);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicenseServiceToolStripMenuItem,
            this.toolStripMenuItem1,
            this.detainLicenseToolStripMenuItem,
            this.manageAppToolStripMenuItem,
            this.manageToolStripMenuItem});
            this.applicationsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.apps;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(208, 84);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // drivingLicenseServiceToolStripMenuItem
            // 
            this.drivingLicenseServiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator2,
            this.replacemntToolStripMenuItem,
            this.toolStripSeparator3,
            this.relaesToolStripMenuItem});
            this.drivingLicenseServiceToolStripMenuItem.Image = global::DVLD.Properties.Resources.cars;
            this.drivingLicenseServiceToolStripMenuItem.Name = "drivingLicenseServiceToolStripMenuItem";
            this.drivingLicenseServiceToolStripMenuItem.Size = new System.Drawing.Size(370, 86);
            this.drivingLicenseServiceToolStripMenuItem.Text = "Driving License Services";
            this.drivingLicenseServiceToolStripMenuItem.Click += new System.EventHandler(this.drivingLicenseServiceToolStripMenuItem_Click);
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.application_list__1_;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(425, 86);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License ";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.local_network;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(323, 86);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.world;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(323, 86);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.brand;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(425, 86);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(422, 6);
            // 
            // replacemntToolStripMenuItem
            // 
            this.replacemntToolStripMenuItem.Image = global::DVLD.Properties.Resources.brand__1_;
            this.replacemntToolStripMenuItem.Name = "replacemntToolStripMenuItem";
            this.replacemntToolStripMenuItem.Size = new System.Drawing.Size(425, 86);
            this.replacemntToolStripMenuItem.Text = "Replacement for lost or Damage";
            this.replacemntToolStripMenuItem.Click += new System.EventHandler(this.replacementToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(422, 6);
            // 
            // relaesToolStripMenuItem
            // 
            this.relaesToolStripMenuItem.Image = global::DVLD.Properties.Resources.release_lock__1_;
            this.relaesToolStripMenuItem.Name = "relaesToolStripMenuItem";
            this.relaesToolStripMenuItem.Size = new System.Drawing.Size(425, 86);
            this.relaesToolStripMenuItem.Text = "Release Detained Driving License";
            this.relaesToolStripMenuItem.Click += new System.EventHandler(this.relaesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.application_list;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(370, 86);
            this.toolStripMenuItem1.Text = "Mange Applications";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::DVLD.Properties.Resources.local_network;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(426, 86);
            this.toolStripMenuItem2.Text = "Local Driving License Application";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::DVLD.Properties.Resources.world;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(426, 86);
            this.toolStripMenuItem5.Text = "International License Application";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainLicensesToolStripMenuItem,
            this.detainLicenseToolStripMenuItem1,
            this.relaseToolStripMenuItem});
            this.detainLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.hand__2_;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(370, 86);
            this.detainLicenseToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainLicensesToolStripMenuItem
            // 
            this.manageDetainLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.hand__2_;
            this.manageDetainLicensesToolStripMenuItem.Name = "manageDetainLicensesToolStripMenuItem";
            this.manageDetainLicensesToolStripMenuItem.Size = new System.Drawing.Size(289, 30);
            this.manageDetainLicensesToolStripMenuItem.Text = "Manage detain licenses";
            this.manageDetainLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainLicensesToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem1
            // 
            this.detainLicenseToolStripMenuItem1.Image = global::DVLD.Properties.Resources.hand__2_;
            this.detainLicenseToolStripMenuItem1.Name = "detainLicenseToolStripMenuItem1";
            this.detainLicenseToolStripMenuItem1.Size = new System.Drawing.Size(289, 30);
            this.detainLicenseToolStripMenuItem1.Text = "Detain license";
            this.detainLicenseToolStripMenuItem1.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem1_Click);
            // 
            // relaseToolStripMenuItem
            // 
            this.relaseToolStripMenuItem.Image = global::DVLD.Properties.Resources.hand_next;
            this.relaseToolStripMenuItem.Name = "relaseToolStripMenuItem";
            this.relaseToolStripMenuItem.Size = new System.Drawing.Size(289, 30);
            this.relaseToolStripMenuItem.Text = "Release detained license";
            this.relaseToolStripMenuItem.Click += new System.EventHandler(this.relaseToolStripMenuItem_Click);
            // 
            // manageAppToolStripMenuItem
            // 
            this.manageAppToolStripMenuItem.Image = global::DVLD.Properties.Resources.morphing;
            this.manageAppToolStripMenuItem.Name = "manageAppToolStripMenuItem";
            this.manageAppToolStripMenuItem.Size = new System.Drawing.Size(370, 86);
            this.manageAppToolStripMenuItem.Text = "Manage Application Types";
            this.manageAppToolStripMenuItem.Click += new System.EventHandler(this.manageAppToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Image = global::DVLD.Properties.Resources.test__1_;
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(370, 86);
            this.manageToolStripMenuItem.Text = "Manage Test Types";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driversToolStripMenuItem.Image = global::DVLD.Properties.Resources.users__2_;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(163, 84);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peopleToolStripMenuItem.Image = global::DVLD.Properties.Resources.users__1_;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(161, 84);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersToolStripMenuItem.Image = global::DVLD.Properties.Resources.users;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(150, 84);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.signOutToolStripMenuItem});
            this.accountSettingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountSettingsToolStripMenuItem.Image = global::DVLD.Properties.Resources.settings;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(245, 84);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentUserInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.info__1_;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordToolStripMenuItem.Image = global::DVLD.Properties.Resources.convert_to_text;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.changePasswordToolStripMenuItem.Text = "change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutToolStripMenuItem.Image = global::DVLD.Properties.Resources.sign_out;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicenseServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem replacemntToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem relaesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem relaseToolStripMenuItem;
    }
}