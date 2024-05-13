namespace DVLD.Application.localDrivingApplication
{
    partial class frmShowLocalApplicationDetails
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbLocalAppInfoText = new System.Windows.Forms.Label();
            this.applicationInfoCtrl1 = new DVLD.ctrls.ApplicationInfoCtrl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Image = global::DVLD.Properties.Resources.close__2_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(340, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbLocalAppInfoText
            // 
            this.lbLocalAppInfoText.AutoSize = true;
            this.lbLocalAppInfoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalAppInfoText.ForeColor = System.Drawing.Color.Red;
            this.lbLocalAppInfoText.Location = new System.Drawing.Point(266, 69);
            this.lbLocalAppInfoText.Name = "lbLocalAppInfoText";
            this.lbLocalAppInfoText.Size = new System.Drawing.Size(231, 25);
            this.lbLocalAppInfoText.TabIndex = 2;
            this.lbLocalAppInfoText.Text = "Application Details Info";
            // 
            // applicationInfoCtrl1
            // 
            this.applicationInfoCtrl1.Location = new System.Drawing.Point(1, 97);
            this.applicationInfoCtrl1.Name = "applicationInfoCtrl1";
            this.applicationInfoCtrl1.Size = new System.Drawing.Size(797, 376);
            this.applicationInfoCtrl1.TabIndex = 1;
            // 
            // frmShowLocalApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.lbLocalAppInfoText);
            this.Controls.Add(this.applicationInfoCtrl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowLocalApplicationDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Application Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ctrls.ApplicationInfoCtrl applicationInfoCtrl1;
        private System.Windows.Forms.Label lbLocalAppInfoText;
    }
}