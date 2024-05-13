namespace DVLD.Application
{
    partial class frmAddEditNewLocalDrivingLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditNewLocalDrivingLicense));
            this.btnNext = new System.Windows.Forms.Button();
            this.tbCtrl = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.addEditFilterCtrl = new DVLD.ctrls.addEditFilterCtrl();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.lbLicenseClass = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbApplicationFees = new System.Windows.Forms.Label();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.pbOldPassword = new System.Windows.Forms.PictureBox();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbMainHeader = new System.Windows.Forms.Label();
            this.tbCtrl.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD.Properties.Resources.arrow;
            this.btnNext.Location = new System.Drawing.Point(914, 725);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 27);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbCtrl
            // 
            this.tbCtrl.Controls.Add(this.tpPersonalInfo);
            this.tbCtrl.Controls.Add(this.tpApplicationInfo);
            this.tbCtrl.Location = new System.Drawing.Point(30, 70);
            this.tbCtrl.Name = "tbCtrl";
            this.tbCtrl.SelectedIndex = 0;
            this.tbCtrl.Size = new System.Drawing.Size(963, 649);
            this.tbCtrl.TabIndex = 2;
            this.tbCtrl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._MyTabControl_Selecting);
            this.tbCtrl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbCtrl_Selected);
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.Controls.Add(this.addEditFilterCtrl);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(955, 623);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // addEditFilterCtrl
            // 
            this.addEditFilterCtrl.Location = new System.Drawing.Point(6, 8);
            this.addEditFilterCtrl.Name = "addEditFilterCtrl";
            this.addEditFilterCtrl.Size = new System.Drawing.Size(927, 557);
            this.addEditFilterCtrl.TabIndex = 2;
            this.addEditFilterCtrl.Load += new System.EventHandler(this.addEditFilterCtrl_Load);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.lbLicenseClass);
            this.tpApplicationInfo.Controls.Add(this.lbCreatedBy);
            this.tpApplicationInfo.Controls.Add(this.lbApplicationFees);
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClasses);
            this.tpApplicationInfo.Controls.Add(this.lbApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.pbOldPassword);
            this.tpApplicationInfo.Controls.Add(this.lbApplicationID);
            this.tpApplicationInfo.Controls.Add(this.pictureBox4);
            this.tpApplicationInfo.Controls.Add(this.pictureBox3);
            this.tpApplicationInfo.Controls.Add(this.pictureBox2);
            this.tpApplicationInfo.Controls.Add(this.pictureBox1);
            this.tpApplicationInfo.Controls.Add(this.label4);
            this.tpApplicationInfo.Controls.Add(this.lbPassword);
            this.tpApplicationInfo.Controls.Add(this.tbConfirmPassword);
            this.tpApplicationInfo.Controls.Add(this.label6);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(955, 623);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // lbLicenseClass
            // 
            this.lbLicenseClass.AutoSize = true;
            this.lbLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseClass.Location = new System.Drawing.Point(104, 194);
            this.lbLicenseClass.Name = "lbLicenseClass";
            this.lbLicenseClass.Size = new System.Drawing.Size(114, 18);
            this.lbLicenseClass.TabIndex = 63;
            this.lbLicenseClass.Text = "License Class";
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCreatedBy.Location = new System.Drawing.Point(284, 316);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(35, 18);
            this.lbCreatedBy.TabIndex = 62;
            this.lbCreatedBy.Text = "???";
            // 
            // lbApplicationFees
            // 
            this.lbApplicationFees.AutoSize = true;
            this.lbApplicationFees.BackColor = System.Drawing.Color.White;
            this.lbApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationFees.ForeColor = System.Drawing.Color.Lime;
            this.lbApplicationFees.Location = new System.Drawing.Point(284, 251);
            this.lbApplicationFees.Name = "lbApplicationFees";
            this.lbApplicationFees.Size = new System.Drawing.Size(39, 20);
            this.lbApplicationFees.TabIndex = 61;
            this.lbApplicationFees.Text = "???";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(284, 194);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(205, 21);
            this.cbLicenseClasses.TabIndex = 60;
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbApplicationDate.Location = new System.Drawing.Point(284, 130);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(35, 18);
            this.lbApplicationDate.TabIndex = 59;
            this.lbApplicationDate.Text = "???";
            // 
            // pbOldPassword
            // 
            this.pbOldPassword.Image = global::DVLD.Properties.Resources.certificate;
            this.pbOldPassword.Location = new System.Drawing.Point(223, 194);
            this.pbOldPassword.Name = "pbOldPassword";
            this.pbOldPassword.Size = new System.Drawing.Size(35, 23);
            this.pbOldPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOldPassword.TabIndex = 57;
            this.pbOldPassword.TabStop = false;
            this.pbOldPassword.Visible = false;
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationID.ForeColor = System.Drawing.Color.Red;
            this.lbApplicationID.Location = new System.Drawing.Point(284, 65);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(35, 18);
            this.lbApplicationID.TabIndex = 51;
            this.lbApplicationID.Text = "???";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.salary;
            this.pictureBox4.Location = new System.Drawing.Point(223, 251);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 23);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 50;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(223, 65);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 49;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.man;
            this.pictureBox2.Location = new System.Drawing.Point(223, 316);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.date_field;
            this.pictureBox1.Location = new System.Drawing.Point(223, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 18);
            this.label4.TabIndex = 46;
            this.label4.Text = "Application Date";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(86, 251);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(132, 18);
            this.lbPassword.TabIndex = 45;
            this.lbPassword.Text = "Application Fees";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.AutoSize = true;
            this.tbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPassword.Location = new System.Drawing.Point(127, 321);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(91, 18);
            this.tbConfirmPassword.TabIndex = 44;
            this.tbConfirmPassword.Text = "Created By";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 18);
            this.label6.TabIndex = 43;
            this.label6.Text = "D.I.Application ID:";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD.Properties.Resources.diskette;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(520, 736);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.close__3_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(411, 736);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // lbMainHeader
            // 
            this.lbMainHeader.AutoSize = true;
            this.lbMainHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMainHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMainHeader.Location = new System.Drawing.Point(323, 43);
            this.lbMainHeader.Name = "lbMainHeader";
            this.lbMainHeader.Size = new System.Drawing.Size(331, 24);
            this.lbMainHeader.TabIndex = 5;
            this.lbMainHeader.Text = "New Local Driving License Application";
            // 
            // frmAddEditNewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 789);
            this.Controls.Add(this.lbMainHeader);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbCtrl);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditNewLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Local Driving License";
            this.tbCtrl.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrls.addEditFilterCtrl addEditFilterCtrl1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabControl tbCtrl;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.PictureBox pbOldPassword;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label tbConfirmPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbApplicationFees;
        private System.Windows.Forms.Label lbLicenseClass;
        private ctrls.addEditFilterCtrl addEditFilterCtrl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbMainHeader;
    }
}