using DVLD.ctrls;

namespace DVLD
{
    partial class frmAddEditPerson
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addEditPersonInfo2 = new DVLD.ctrls.AddEditPersonInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.Red;
            this.lbHeader.Location = new System.Drawing.Point(328, 9);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(202, 29);
            this.lbHeader.TabIndex = 2;
            this.lbHeader.Text = "Add new person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "PersonID:";
            // 
            // lbPersonID
            // 
            this.lbPersonID.AutoSize = true;
            this.lbPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPersonID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbPersonID.Location = new System.Drawing.Point(181, 67);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(35, 18);
            this.lbPersonID.TabIndex = 4;
            this.lbPersonID.Text = "N/A";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.id;
            this.pictureBox1.Location = new System.Drawing.Point(133, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // addEditPersonInfo2
            // 
            this.addEditPersonInfo2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.addEditPersonInfo2.ID = 0;
            this.addEditPersonInfo2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addEditPersonInfo2.Location = new System.Drawing.Point(16, 90);
            this.addEditPersonInfo2.Mode = DVLD.ctrls.AddEditPersonInfo.ControlMode.AddNew;
            this.addEditPersonInfo2.Name = "addEditPersonInfo2";
            this.addEditPersonInfo2.Size = new System.Drawing.Size(846, 378);
            this.addEditPersonInfo2.TabIndex = 6;
            // 
            // frmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(863, 476);
            this.Controls.Add(this.addEditPersonInfo2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbPersonID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbHeader);
            this.Name = "frmAddEditPerson";
            this.Text = "Add/Edit Person";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private AddEditPersonInfo addEditPersonInfo;
        //private AddEditPersonInfo addEditPersonInfo2;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPersonID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AddEditPersonInfo addEditPersonInfo1;
        private AddEditPersonInfo addEditPersonInfo2;
    }
}