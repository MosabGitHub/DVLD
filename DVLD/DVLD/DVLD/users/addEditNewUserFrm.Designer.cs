namespace DVLD
{
    partial class addEditNewUserFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addEditNewUserFrm));
            this.lbMain = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.filterCtrl1 = new DVLD.ctrls.FilterCtrl();
            this.personInfoCtrl1 = new DVLD.PersonInfoCtrl();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.tbOldPassword = new System.Windows.Forms.TextBox();
            this.pbOldPassword = new System.Windows.Forms.PictureBox();
            this.lbOldPassword = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.tbConfirmPassowrd = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMain.ForeColor = System.Drawing.Color.Turquoise;
            this.lbMain.Location = new System.Drawing.Point(408, 16);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(201, 31);
            this.lbMain.TabIndex = 1;
            this.lbMain.Text = "Add New User";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPersonalInfo);
            this.tabControl1.Controls.Add(this.tpLoginInfo);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tabControl1.Location = new System.Drawing.Point(38, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(990, 550);
            this.tabControl1.TabIndex = 39;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackColor = System.Drawing.Color.DarkCyan;
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Controls.Add(this.filterCtrl1);
            this.tpPersonalInfo.Controls.Add(this.personInfoCtrl1);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(982, 524);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Information";
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.Image = global::DVLD.Properties.Resources.arrow;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(904, 484);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 26);
            this.btnNext.TabIndex = 40;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // filterCtrl1
            // 
            this.filterCtrl1.Location = new System.Drawing.Point(28, 39);
            this.filterCtrl1.Name = "filterCtrl1";
            this.filterCtrl1.Size = new System.Drawing.Size(539, 49);
            this.filterCtrl1.TabIndex = 1;
            // 
            // personInfoCtrl1
            // 
            this.personInfoCtrl1.Location = new System.Drawing.Point(18, 94);
            this.personInfoCtrl1.Name = "personInfoCtrl1";
            this.personInfoCtrl1.Size = new System.Drawing.Size(931, 384);
            this.personInfoCtrl1.TabIndex = 0;
            this.personInfoCtrl1.Load += new System.EventHandler(this.personInfoCtrl1_Load);
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tpLoginInfo.Controls.Add(this.tbOldPassword);
            this.tpLoginInfo.Controls.Add(this.pbOldPassword);
            this.tpLoginInfo.Controls.Add(this.lbOldPassword);
            this.tpLoginInfo.Controls.Add(this.btnChangePassword);
            this.tpLoginInfo.Controls.Add(this.cbIsActive);
            this.tpLoginInfo.Controls.Add(this.tbConfirmPassowrd);
            this.tpLoginInfo.Controls.Add(this.tbPassword);
            this.tpLoginInfo.Controls.Add(this.tbUserName);
            this.tpLoginInfo.Controls.Add(this.lbID);
            this.tpLoginInfo.Controls.Add(this.pictureBox4);
            this.tpLoginInfo.Controls.Add(this.pictureBox3);
            this.tpLoginInfo.Controls.Add(this.pictureBox2);
            this.tpLoginInfo.Controls.Add(this.pictureBox1);
            this.tpLoginInfo.Controls.Add(this.label4);
            this.tpLoginInfo.Controls.Add(this.lbPassword);
            this.tpLoginInfo.Controls.Add(this.tbConfirmPassword);
            this.tpLoginInfo.Controls.Add(this.label6);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(982, 524);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Login Info";
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Location = new System.Drawing.Point(237, 204);
            this.tbOldPassword.MaxLength = 15;
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.PasswordChar = '*';
            this.tbOldPassword.Size = new System.Drawing.Size(117, 20);
            this.tbOldPassword.TabIndex = 42;
            this.tbOldPassword.Visible = false;
            this.tbOldPassword.Validated += new System.EventHandler(this.tbOldPassword_Validated);
            // 
            // pbOldPassword
            // 
            this.pbOldPassword.Image = ((System.Drawing.Image)(resources.GetObject("pbOldPassword.Image")));
            this.pbOldPassword.Location = new System.Drawing.Point(174, 206);
            this.pbOldPassword.Name = "pbOldPassword";
            this.pbOldPassword.Size = new System.Drawing.Size(35, 23);
            this.pbOldPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOldPassword.TabIndex = 41;
            this.pbOldPassword.TabStop = false;
            this.pbOldPassword.Visible = false;
            // 
            // lbOldPassword
            // 
            this.lbOldPassword.AutoSize = true;
            this.lbOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOldPassword.Location = new System.Drawing.Point(47, 206);
            this.lbOldPassword.Name = "lbOldPassword";
            this.lbOldPassword.Size = new System.Drawing.Size(112, 18);
            this.lbOldPassword.TabIndex = 40;
            this.lbOldPassword.Text = "Old password";
            this.lbOldPassword.Visible = false;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(18, 486);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(110, 32);
            this.btnChangePassword.TabIndex = 39;
            this.btnChangePassword.Text = "change password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Visible = false;
            this.btnChangePassword.Click += new System.EventHandler(this.changePassword_Click_1);
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(237, 384);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(67, 17);
            this.cbIsActive.TabIndex = 38;
            this.cbIsActive.Text = "Is Active";
            this.cbIsActive.UseVisualStyleBackColor = true;
            this.cbIsActive.TextChanged += new System.EventHandler(this.cbIsActive_TextChanged);
            // 
            // tbConfirmPassowrd
            // 
            this.tbConfirmPassowrd.Location = new System.Drawing.Point(237, 331);
            this.tbConfirmPassowrd.MaxLength = 15;
            this.tbConfirmPassowrd.Name = "tbConfirmPassowrd";
            this.tbConfirmPassowrd.PasswordChar = '*';
            this.tbConfirmPassowrd.Size = new System.Drawing.Size(117, 20);
            this.tbConfirmPassowrd.TabIndex = 37;
            this.tbConfirmPassowrd.Validated += new System.EventHandler(this.tbConfirmPassowrd_Validated);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(237, 264);
            this.tbPassword.MaxLength = 15;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(117, 20);
            this.tbPassword.TabIndex = 36;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.Validated += new System.EventHandler(this.tbPassword_Validated);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(237, 140);
            this.tbUserName.MaxLength = 15;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(117, 20);
            this.tbUserName.TabIndex = 35;
            this.tbUserName.TextChanged += new System.EventHandler(this.tbUserName_TextChanged);
            this.tbUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUserName_KeyPress);
            this.tbUserName.Validating += new System.ComponentModel.CancelEventHandler(this.tbUserName_Validating);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.ForeColor = System.Drawing.Color.Red;
            this.lbID.Location = new System.Drawing.Point(237, 72);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(35, 18);
            this.lbID.TabIndex = 34;
            this.lbID.Text = "???";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(174, 263);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 23);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(172, 72);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(174, 328);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(174, 142);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "UserName";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(57, 263);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(83, 18);
            this.lbPassword.TabIndex = 28;
            this.lbPassword.Text = "Password";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.AutoSize = true;
            this.tbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPassword.Location = new System.Drawing.Point(15, 328);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(148, 18);
            this.tbConfirmPassword.TabIndex = 27;
            this.tbConfirmPassword.Text = "Confirm Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "UserID";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(850, 686);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 31);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(949, 686);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 31);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // addEditNewUserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 729);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbMain);
            this.Name = "addEditNewUserFrm";
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.addEditNewUserFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private PersonInfoCtrl personInfoCtrl1;
        private ctrls.FilterCtrl filterCtrl1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.TextBox tbConfirmPassowrd;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label tbConfirmPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox tbOldPassword;
        private System.Windows.Forms.PictureBox pbOldPassword;
        private System.Windows.Forms.Label lbOldPassword;
    }
}