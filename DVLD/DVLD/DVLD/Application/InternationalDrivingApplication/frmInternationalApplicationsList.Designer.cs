namespace DVLD.Application.InternationalDrivingApplication
{
    partial class frmInternationalApplicationsList
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
            this.lbMain = new System.Windows.Forms.Label();
            this.dgvListInternationalLicensesApplication = new System.Windows.Forms.DataGridView();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.epFilter = new System.Windows.Forms.ErrorProvider(this.components);
            this.rbtnActive = new System.Windows.Forms.RadioButton();
            this.rbtnNotActive = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListInternationalLicensesApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMain.ForeColor = System.Drawing.Color.Red;
            this.lbMain.Location = new System.Drawing.Point(347, 9);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(383, 29);
            this.lbMain.TabIndex = 8;
            this.lbMain.Text = "International Licenses Applications";
            // 
            // dgvListInternationalLicensesApplication
            // 
            this.dgvListInternationalLicensesApplication.AllowUserToAddRows = false;
            this.dgvListInternationalLicensesApplication.AllowUserToDeleteRows = false;
            this.dgvListInternationalLicensesApplication.AllowUserToResizeRows = false;
            this.dgvListInternationalLicensesApplication.BackgroundColor = System.Drawing.Color.White;
            this.dgvListInternationalLicensesApplication.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvListInternationalLicensesApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListInternationalLicensesApplication.Location = new System.Drawing.Point(24, 112);
            this.dgvListInternationalLicensesApplication.MultiSelect = false;
            this.dgvListInternationalLicensesApplication.Name = "dgvListInternationalLicensesApplication";
            this.dgvListInternationalLicensesApplication.ReadOnly = true;
            this.dgvListInternationalLicensesApplication.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvListInternationalLicensesApplication.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListInternationalLicensesApplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListInternationalLicensesApplication.Size = new System.Drawing.Size(1047, 455);
            this.dgvListInternationalLicensesApplication.TabIndex = 9;
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(243, 86);
            this.tbFilter.MaxLength = 50;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(191, 20);
            this.tbFilter.TabIndex = 15;
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "International Driving License ID ",
            "Application ID",
            "Driver ID",
            "Is Active"});
            this.cbFilter.Location = new System.Drawing.Point(101, 87);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 14;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Filter by";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.Black;
            this.lbRecords.Location = new System.Drawing.Point(137, 584);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(19, 20);
            this.lbRecords.TabIndex = 18;
            this.lbRecords.Text = "0";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label124.ForeColor = System.Drawing.Color.Black;
            this.label124.Location = new System.Drawing.Point(35, 584);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(96, 20);
            this.label124.TabIndex = 17;
            this.label124.Text = "# Records:";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(493, 581);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 29);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // epFilter
            // 
            this.epFilter.ContainerControl = this;
            // 
            // rbtnActive
            // 
            this.rbtnActive.AutoSize = true;
            this.rbtnActive.Location = new System.Drawing.Point(243, 87);
            this.rbtnActive.Name = "rbtnActive";
            this.rbtnActive.Size = new System.Drawing.Size(55, 17);
            this.rbtnActive.TabIndex = 19;
            this.rbtnActive.TabStop = true;
            this.rbtnActive.Text = "Active";
            this.rbtnActive.UseVisualStyleBackColor = true;
            this.rbtnActive.Visible = false;
            this.rbtnActive.Click += new System.EventHandler(this.rbtnActive_Click);
            // 
            // rbtnNotActive
            // 
            this.rbtnNotActive.AutoSize = true;
            this.rbtnNotActive.Location = new System.Drawing.Point(339, 87);
            this.rbtnNotActive.Name = "rbtnNotActive";
            this.rbtnNotActive.Size = new System.Drawing.Size(75, 17);
            this.rbtnNotActive.TabIndex = 20;
            this.rbtnNotActive.TabStop = true;
            this.rbtnNotActive.Text = "Not Active";
            this.rbtnNotActive.UseVisualStyleBackColor = true;
            this.rbtnNotActive.Visible = false;
            this.rbtnNotActive.Click += new System.EventHandler(this.rbtnNotActive_Click);
            // 
            // frmInternationalApplicationsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 637);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.rbtnNotActive);
            this.Controls.Add(this.rbtnActive);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label124);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvListInternationalLicensesApplication);
            this.Controls.Add(this.lbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInternationalApplicationsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmInternationalApplicationsList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListInternationalLicensesApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.DataGridView dgvListInternationalLicensesApplication;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider epFilter;
        private System.Windows.Forms.RadioButton rbtnNotActive;
        private System.Windows.Forms.RadioButton rbtnActive;
    }
}