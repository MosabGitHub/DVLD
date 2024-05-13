namespace DVLD.ctrls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterCtrl));
            this.label4 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.epFilter = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddPerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Filter by";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "National No",
            "Person ID"});
            this.cbFilter.Location = new System.Drawing.Point(86, 21);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 7;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::DVLD.Properties.Resources.agent;
            this.btnSearch.Location = new System.Drawing.Point(356, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(29, 27);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(230, 21);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(100, 20);
            this.tbFilter.TabIndex = 10;
            // 
            // epFilter
            // 
            this.epFilter.ContainerControl = this;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.FlatAppearance.BorderSize = 0;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image")));
            this.btnAddPerson.Location = new System.Drawing.Point(401, 14);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(29, 27);
            this.btnAddPerson.TabIndex = 11;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // FilterCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label4);
            this.Name = "FilterCtrl";
            this.Size = new System.Drawing.Size(539, 49);
            this.Load += new System.EventHandler(this.FilterCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ErrorProvider epFilter;
        private System.Windows.Forms.Button btnAddPerson;
    }
}
