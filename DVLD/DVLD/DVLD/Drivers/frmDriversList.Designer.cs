namespace DVLD.Drivers
{
    partial class frmDriversList
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
            this.dgvListDrivers = new System.Windows.Forms.DataGridView();
            this.label124 = new System.Windows.Forms.Label();
            this.lbMain = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.epFilter = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbRecords = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListDrivers
            // 
            this.dgvListDrivers.AllowUserToAddRows = false;
            this.dgvListDrivers.AllowUserToDeleteRows = false;
            this.dgvListDrivers.AllowUserToResizeRows = false;
            this.dgvListDrivers.BackgroundColor = System.Drawing.Color.White;
            this.dgvListDrivers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvListDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListDrivers.Location = new System.Drawing.Point(26, 178);
            this.dgvListDrivers.MultiSelect = false;
            this.dgvListDrivers.Name = "dgvListDrivers";
            this.dgvListDrivers.ReadOnly = true;
            this.dgvListDrivers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvListDrivers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListDrivers.Size = new System.Drawing.Size(1047, 455);
            this.dgvListDrivers.TabIndex = 1;
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label124.ForeColor = System.Drawing.Color.Black;
            this.label124.Location = new System.Drawing.Point(26, 657);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(96, 20);
            this.label124.TabIndex = 6;
            this.label124.Text = "# Records:";
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMain.ForeColor = System.Drawing.Color.Red;
            this.lbMain.Location = new System.Drawing.Point(456, 8);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(188, 29);
            this.lbMain.TabIndex = 7;
            this.lbMain.Text = "Manage Drivers ";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Person ID",
            "National No",
            "Full Name"});
            this.cbFilter.Location = new System.Drawing.Point(101, 151);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 11;
            this.cbFilter.SelectedValueChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filter by";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(247, 151);
            this.tbFilter.MaxLength = 50;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(169, 20);
            this.tbFilter.TabIndex = 12;
            // 
            // epFilter
            // 
            this.epFilter.ContainerControl = this;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.Black;
            this.lbRecords.Location = new System.Drawing.Point(128, 657);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(19, 20);
            this.lbRecords.TabIndex = 13;
            this.lbRecords.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.driver;
            this.pictureBox1.Location = new System.Drawing.Point(504, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(504, 657);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDriversList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1103, 698);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.label124);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvListDrivers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDriversList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Drivers List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListDrivers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ErrorProvider epFilter;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}