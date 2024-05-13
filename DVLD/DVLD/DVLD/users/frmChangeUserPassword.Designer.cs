namespace DVLD.users
{
    partial class frmChangeUserPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeUserPassword));
            this.personInfoCtrl1 = new DVLD.PersonInfoCtrl();
            this.loginInfoCtrl1 = new DVLD.loginInfoCtrl();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentPassword = new System.Windows.Forms.TextBox();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.epPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // personInfoCtrl1
            // 
            this.personInfoCtrl1.Location = new System.Drawing.Point(12, 12);
            this.personInfoCtrl1.Name = "personInfoCtrl1";
            this.personInfoCtrl1.Size = new System.Drawing.Size(931, 384);
            this.personInfoCtrl1.TabIndex = 3;
            // 
            // loginInfoCtrl1
            // 
            this.loginInfoCtrl1.Location = new System.Drawing.Point(12, 402);
            this.loginInfoCtrl1.Name = "loginInfoCtrl1";
            this.loginInfoCtrl1.Size = new System.Drawing.Size(697, 80);
            this.loginInfoCtrl1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Current Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "New Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 615);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "New Password: ";
            // 
            // tbCurrentPassword
            // 
            this.tbCurrentPassword.Location = new System.Drawing.Point(189, 509);
            this.tbCurrentPassword.MaxLength = 15;
            this.tbCurrentPassword.Name = "tbCurrentPassword";
            this.tbCurrentPassword.PasswordChar = '*';
            this.tbCurrentPassword.Size = new System.Drawing.Size(115, 20);
            this.tbCurrentPassword.TabIndex = 0;
            this.tbCurrentPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbCurrentPassword.Validated += new System.EventHandler(this.currentPassword_Validated);
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(189, 613);
            this.tbConfirmPassword.MaxLength = 15;
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(115, 20);
            this.tbConfirmPassword.TabIndex = 2;
            this.tbConfirmPassword.UseSystemPasswordChar = true;
            this.tbConfirmPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbConfirmPassword.Validated += new System.EventHandler(this.tbConfirmPassword_Validated);
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbNewPassword.Location = new System.Drawing.Point(189, 559);
            this.tbNewPassword.MaxLength = 15;
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.PasswordChar = '*';
            this.tbNewPassword.Size = new System.Drawing.Size(115, 20);
            this.tbNewPassword.TabIndex = 1;
            this.tbNewPassword.UseSystemPasswordChar = true;
            this.tbNewPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbNewPassword.Validated += new System.EventHandler(this.tbNewPassword_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 561);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "New Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 615);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Confirm Password:";
            // 
            // epPassword
            // 
            this.epPassword.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(799, 653);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 31);
            this.btnClose.TabIndex = 38;
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
            this.btnSave.Location = new System.Drawing.Point(898, 653);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 31);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmChangeUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 696);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.tbCurrentPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loginInfoCtrl1);
            this.Controls.Add(this.personInfoCtrl1);
            this.Name = "frmChangeUserPassword";
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersonInfoCtrl personInfoCtrl1;
        private loginInfoCtrl loginInfoCtrl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCurrentPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epPassword;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}