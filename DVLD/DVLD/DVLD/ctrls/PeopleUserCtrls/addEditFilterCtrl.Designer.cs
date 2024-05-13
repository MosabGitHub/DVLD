namespace DVLD.ctrls
{
    partial class addEditFilterCtrl
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
            this.filterCtrl1 = new DVLD.ctrls.FilterCtrl();
            this.personInfoCtrl1 = new DVLD.PersonInfoCtrl();
            this.SuspendLayout();
            // 
            // filterCtrl1
            // 
            this.filterCtrl1.Location = new System.Drawing.Point(19, 53);
            this.filterCtrl1.Name = "filterCtrl1";
            this.filterCtrl1.Size = new System.Drawing.Size(543, 49);
            this.filterCtrl1.TabIndex = 1;
            // 
            // personInfoCtrl1
            // 
            this.personInfoCtrl1.Location = new System.Drawing.Point(19, 141);
            this.personInfoCtrl1.Name = "personInfoCtrl1";
            this.personInfoCtrl1.Size = new System.Drawing.Size(892, 384);
            this.personInfoCtrl1.TabIndex = 2;
            // 
            // addEditFilterCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.personInfoCtrl1);
            this.Controls.Add(this.filterCtrl1);
            this.Name = "addEditFilterCtrl";
            this.Size = new System.Drawing.Size(927, 554);
            this.ResumeLayout(false);

        }

        #endregion
        private FilterCtrl filterCtrl1;
        private PersonInfoCtrl personInfoCtrl1;
    }
}
