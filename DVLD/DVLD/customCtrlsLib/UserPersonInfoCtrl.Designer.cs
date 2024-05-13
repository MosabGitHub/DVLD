namespace customCtrlsLib
{
    partial class UserPersonInfoCtrl
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
            this.filterCtrl1 = new customCtrlsLib.FilterCtrl();
            this.SuspendLayout();
            // 
            // filterCtrl1
            // 
            this.filterCtrl1.Location = new System.Drawing.Point(25, 27);
            this.filterCtrl1.Name = "filterCtrl1";
            this.filterCtrl1.Size = new System.Drawing.Size(642, 83);
            this.filterCtrl1.TabIndex = 0;
            // 
            // UserPersonInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filterCtrl1);
            this.Name = "UserPersonInfoCtrl";
            this.Size = new System.Drawing.Size(1009, 537);
            this.ResumeLayout(false);

        }

        #endregion

        private FilterCtrl filterCtrl1;
    }
}
