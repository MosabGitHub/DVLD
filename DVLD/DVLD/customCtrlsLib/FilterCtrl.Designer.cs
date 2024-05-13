namespace customCtrlsLib
{
    partial class FilterCtrl
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.epFilter = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Filter by";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(247, 29);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(137, 20);
            this.tbFilter.TabIndex = 7;
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "National No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gender",
            "Phone",
            "Email"});
            this.cbFilter.Location = new System.Drawing.Point(100, 29);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(411, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // FilterCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.label4);
            this.Name = "FilterCtrl";
            this.Size = new System.Drawing.Size(642, 83);
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ErrorProvider epFilter;
        private System.Windows.Forms.Button btnSearch;
    }
}
