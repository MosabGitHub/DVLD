namespace DVLD.ctrls.ApplicationCtrls
{
    partial class DetainInfoCtrl
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
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDetainDate = new System.Windows.Forms.Label();
            this.lbDetainID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFineFees = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDetainReason = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLicenseID = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.epTextBoxes = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTextBoxes)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 54;
            this.label7.Text = "Detain ID";
            // 
            // lbDetainDate
            // 
            this.lbDetainDate.AutoSize = true;
            this.lbDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetainDate.Location = new System.Drawing.Point(184, 74);
            this.lbDetainDate.Name = "lbDetainDate";
            this.lbDetainDate.Size = new System.Drawing.Size(23, 16);
            this.lbDetainDate.TabIndex = 58;
            this.lbDetainDate.Text = "??";
            // 
            // lbDetainID
            // 
            this.lbDetainID.AutoSize = true;
            this.lbDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetainID.ForeColor = System.Drawing.Color.Red;
            this.lbDetainID.Location = new System.Drawing.Point(184, 25);
            this.lbDetainID.Name = "lbDetainID";
            this.lbDetainID.Size = new System.Drawing.Size(23, 16);
            this.lbDetainID.TabIndex = 57;
            this.lbDetainID.Text = "??";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 55;
            this.label9.Text = "Detain  Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbFineFees);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbDetainReason);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbCreatedBy);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbLicenseID);
            this.groupBox1.Controls.Add(this.lbDetainID);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbDetainDate);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 234);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain info";
            // 
            // tbFineFees
            // 
            this.tbFineFees.ForeColor = System.Drawing.Color.Gray;
            this.tbFineFees.Location = new System.Drawing.Point(187, 128);
            this.tbFineFees.MaxLength = 6;
            this.tbFineFees.Name = "tbFineFees";
            this.tbFineFees.Size = new System.Drawing.Size(88, 20);
            this.tbFineFees.TabIndex = 80;
            this.tbFineFees.Tag = "Enter your fees...";
            this.tbFineFees.Text = "Enter your fees...";
            this.tbFineFees.TextChanged += new System.EventHandler(this.tbFineFees_TextChanged);
            this.tbFineFees.Enter += new System.EventHandler(this.tbFineFees_Enter);
            this.tbFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFineFees_KeyPress);
            this.tbFineFees.Leave += new System.EventHandler(this.tbFineFees_Leave);
            this.tbFineFees.Validated += new System.EventHandler(this.tbFineFees_Validated);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.Properties.Resources.test;
            this.pictureBox6.Location = new System.Drawing.Point(132, 174);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 22);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 79;
            this.pictureBox6.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 78;
            this.label5.Text = "Detain Reason";
            // 
            // tbDetainReason
            // 
            this.tbDetainReason.ForeColor = System.Drawing.Color.Gray;
            this.tbDetainReason.Location = new System.Drawing.Point(187, 174);
            this.tbDetainReason.Multiline = true;
            this.tbDetainReason.Name = "tbDetainReason";
            this.tbDetainReason.Size = new System.Drawing.Size(447, 54);
            this.tbDetainReason.TabIndex = 77;
            this.tbDetainReason.Tag = "Enter your detain reason...";
            this.tbDetainReason.Text = "Enter your detain reason...";
            this.tbDetainReason.TextChanged += new System.EventHandler(this.tbDetainReason_TextChanged);
            this.tbDetainReason.Enter += new System.EventHandler(this.tbFineReason_Enter);
            this.tbDetainReason.Leave += new System.EventHandler(this.tbFineReason_Leave);
            this.tbDetainReason.Validated += new System.EventHandler(this.tbDetainReason_Validated);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.Properties.Resources.info;
            this.pictureBox5.Location = new System.Drawing.Point(478, 74);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 22);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 76;
            this.pictureBox5.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(377, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 74;
            this.label3.Text = "Created By";
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(556, 74);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(23, 16);
            this.lbCreatedBy.TabIndex = 75;
            this.lbCreatedBy.Text = "??";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.id__2_;
            this.pictureBox4.Location = new System.Drawing.Point(478, 25);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 22);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 73;
            this.pictureBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 71;
            this.label2.Text = "License ID";
            // 
            // lbLicenseID
            // 
            this.lbLicenseID.AutoSize = true;
            this.lbLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseID.Location = new System.Drawing.Point(556, 25);
            this.lbLicenseID.Name = "lbLicenseID";
            this.lbLicenseID.Size = new System.Drawing.Size(23, 16);
            this.lbLicenseID.TabIndex = 72;
            this.lbLicenseID.Text = "??";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.bill__1_;
            this.pictureBox2.Location = new System.Drawing.Point(132, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 70;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.date_field__1_;
            this.pictureBox3.Location = new System.Drawing.Point(132, 74);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 69;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "Fine Fees";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.id__3_;
            this.pictureBox1.Location = new System.Drawing.Point(132, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // epTextBoxes
            // 
            this.epTextBoxes.ContainerControl = this;
            // 
            // DetainInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DetainInfoCtrl";
            this.Size = new System.Drawing.Size(687, 239);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTextBoxes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbDetainDate;
        private System.Windows.Forms.Label lbDetainID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLicenseID;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDetainReason;
        private System.Windows.Forms.TextBox tbFineFees;
        private System.Windows.Forms.ErrorProvider epTextBoxes;
    }
}
