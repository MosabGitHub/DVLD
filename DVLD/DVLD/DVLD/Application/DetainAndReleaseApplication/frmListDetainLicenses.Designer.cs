namespace DVLD.Application.DetainAndReleaseApplication
{
    partial class frmListDetainLicenses
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
            this.dgvListDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.rbtnDetained = new System.Windows.Forms.RadioButton();
            this.rbtnRelease = new System.Windows.Forms.RadioButton();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.lbMain = new System.Windows.Forms.Label();
            this.epFilter = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDetainedLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListDetainedLicenses
            // 
            this.dgvListDetainedLicenses.AllowUserToAddRows = false;
            this.dgvListDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvListDetainedLicenses.AllowUserToResizeRows = false;
            this.dgvListDetainedLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvListDetainedLicenses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvListDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListDetainedLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListDetainedLicenses.Location = new System.Drawing.Point(18, 235);
            this.dgvListDetainedLicenses.MultiSelect = false;
            this.dgvListDetainedLicenses.Name = "dgvListDetainedLicenses";
            this.dgvListDetainedLicenses.ReadOnly = true;
            this.dgvListDetainedLicenses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvListDetainedLicenses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListDetainedLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListDetainedLicenses.Size = new System.Drawing.Size(1241, 524);
            this.dgvListDetainedLicenses.TabIndex = 10;
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(242, 206);
            this.tbFilter.MaxLength = 50;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(191, 20);
            this.tbFilter.TabIndex = 23;
            // 
            // rbtnDetained
            // 
            this.rbtnDetained.AutoSize = true;
            this.rbtnDetained.Location = new System.Drawing.Point(358, 209);
            this.rbtnDetained.Name = "rbtnDetained";
            this.rbtnDetained.Size = new System.Drawing.Size(68, 17);
            this.rbtnDetained.TabIndex = 25;
            this.rbtnDetained.TabStop = true;
            this.rbtnDetained.Text = "Detained";
            this.rbtnDetained.UseVisualStyleBackColor = true;
            this.rbtnDetained.Visible = false;
            this.rbtnDetained.CheckedChanged += new System.EventHandler(this.radioButton_checkedChange);
            // 
            // rbtnRelease
            // 
            this.rbtnRelease.AutoSize = true;
            this.rbtnRelease.Location = new System.Drawing.Point(242, 210);
            this.rbtnRelease.Name = "rbtnRelease";
            this.rbtnRelease.Size = new System.Drawing.Size(64, 17);
            this.rbtnRelease.TabIndex = 24;
            this.rbtnRelease.TabStop = true;
            this.rbtnRelease.Text = "Release";
            this.rbtnRelease.UseVisualStyleBackColor = true;
            this.rbtnRelease.Visible = false;
            this.rbtnRelease.CheckedChanged += new System.EventHandler(this.radioButton_checkedChange);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "Full Name",
            "Release Application ID "});
            this.cbFilter.Location = new System.Drawing.Point(100, 210);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 22;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Filter by";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.Black;
            this.lbRecords.Location = new System.Drawing.Point(116, 784);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(19, 20);
            this.lbRecords.TabIndex = 28;
            this.lbRecords.Text = "0";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label124.ForeColor = System.Drawing.Color.Black;
            this.label124.Location = new System.Drawing.Point(14, 784);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(96, 20);
            this.label124.TabIndex = 27;
            this.label124.Text = "# Records:";
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMain.ForeColor = System.Drawing.Color.Red;
            this.lbMain.Location = new System.Drawing.Point(512, 121);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(255, 29);
            this.lbMain.TabIndex = 29;
            this.lbMain.Text = "List Detained Licenses";
            // 
            // epFilter
            // 
            this.epFilter.ContainerControl = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 100);
            // 
            // btnRelease
            // 
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Image = global::DVLD.Properties.Resources.hand_next;
            this.btnRelease.Location = new System.Drawing.Point(1092, 166);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 65);
            this.btnRelease.TabIndex = 31;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetain.Image = global::DVLD.Properties.Resources.hand__2_;
            this.btnDetain.Location = new System.Drawing.Point(1184, 166);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(75, 65);
            this.btnDetain.TabIndex = 30;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(606, 781);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 29);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.hand__2_;
            this.pictureBox1.Location = new System.Drawing.Point(544, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.administrator_zoom;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(229, 32);
            this.showPersonDetailsToolStripMenuItem.Text = "Show person details";
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.id__4_;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(229, 32);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show license details";
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.id__5_;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(229, 32);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show person license history";
            // 
            // frmListDetainLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 832);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label124);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.rbtnDetained);
            this.Controls.Add(this.rbtnRelease);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvListDetainedLicenses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDetainLicenses";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Detain Licenses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDetainedLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListDetainedLicenses;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.RadioButton rbtnDetained;
        private System.Windows.Forms.RadioButton rbtnRelease;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.ErrorProvider epFilter;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}