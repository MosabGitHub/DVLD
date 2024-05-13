namespace DVLD.Application.localDrivingApplication
{
    partial class frmListLocalDrivingLicenseApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListLocalDrivingLicenseApplications));
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.cmsLocalDrivingLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sechduToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practicalTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbMain = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.epFilter = new System.Windows.Forms.ErrorProvider(this.components);
            this.rbtnNew = new System.Windows.Forms.RadioButton();
            this.rbtnCompleted = new System.Windows.Forms.RadioButton();
            this.rbtnCancelled = new System.Windows.Forms.RadioButton();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.cmsLocalDrivingLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).BeginInit();
            this.gbStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvApplications
            // 
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.AllowUserToResizeColumns = false;
            this.dgvApplications.AllowUserToResizeRows = false;
            this.dgvApplications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApplications.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvApplications.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvApplications.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.ContextMenuStrip = this.cmsLocalDrivingLicense;
            this.dgvApplications.Location = new System.Drawing.Point(46, 223);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvApplications.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplications.Size = new System.Drawing.Size(1098, 488);
            this.dgvApplications.TabIndex = 1;
            // 
            // cmsLocalDrivingLicense
            // 
            this.cmsLocalDrivingLicense.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsLocalDrivingLicense.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cmsLocalDrivingLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripSeparator3,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripSeparator4,
            this.sechduToolStripMenuItem,
            this.toolStripSeparator5,
            this.issueDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator6,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator7,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsLocalDrivingLicense.Name = "cmsLocalDrivingLicense";
            this.cmsLocalDrivingLicense.Size = new System.Drawing.Size(256, 334);
            this.cmsLocalDrivingLicense.Opened += new System.EventHandler(this.cmsLocalDrivingLicense_Opened);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(252, 6);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.list;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(255, 36);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(252, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_config;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(255, 36);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.cross__1_;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(255, 36);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(252, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.cancel;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(255, 36);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(252, 6);
            // 
            // sechduToolStripMenuItem
            // 
            this.sechduToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.writtenTestToolStripMenuItem,
            this.practicalTestToolStripMenuItem});
            this.sechduToolStripMenuItem.Image = global::DVLD.Properties.Resources.title;
            this.sechduToolStripMenuItem.Name = "sechduToolStripMenuItem";
            this.sechduToolStripMenuItem.Size = new System.Drawing.Size(255, 36);
            this.sechduToolStripMenuItem.Text = "Sechdule tests";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Enabled = false;
            this.visionTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visionTestToolStripMenuItem.Image")));
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.visionTestToolStripMenuItem.Text = "Vision Test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // writtenTestToolStripMenuItem
            // 
            this.writtenTestToolStripMenuItem.Enabled = false;
            this.writtenTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.essay;
            this.writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            this.writtenTestToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.writtenTestToolStripMenuItem.Text = "Written Test";
            this.writtenTestToolStripMenuItem.Click += new System.EventHandler(this.writtenTestToolStripMenuItem_Click);
            // 
            // practicalTestToolStripMenuItem
            // 
            this.practicalTestToolStripMenuItem.Enabled = false;
            this.practicalTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.british_car;
            this.practicalTestToolStripMenuItem.Name = "practicalTestToolStripMenuItem";
            this.practicalTestToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.practicalTestToolStripMenuItem.Text = "Practical Test";
            this.practicalTestToolStripMenuItem.Click += new System.EventHandler(this.practicalTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(252, 6);
            // 
            // issueDrivingLicenseToolStripMenuItem
            // 
            this.issueDrivingLicenseToolStripMenuItem.Enabled = false;
            this.issueDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.id1;
            this.issueDrivingLicenseToolStripMenuItem.Name = "issueDrivingLicenseToolStripMenuItem";
            this.issueDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(255, 36);
            this.issueDrivingLicenseToolStripMenuItem.Text = "Issue Driving License (first time)";
            this.issueDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(252, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.training__1_;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(255, 36);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(252, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.history;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(255, 36);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMain.Location = new System.Drawing.Point(412, 109);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(375, 25);
            this.lbMain.TabIndex = 3;
            this.lbMain.Text = "Local Driving License Applications";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Filter by";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(124, 193);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 9;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(257, 194);
            this.tbFilter.MaxLength = 50;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(169, 20);
            this.tbFilter.TabIndex = 11;
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecords.ForeColor = System.Drawing.Color.Black;
            this.lbTotalRecords.Location = new System.Drawing.Point(154, 759);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(0, 16);
            this.lbTotalRecords.TabIndex = 13;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(27, 751);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(101, 24);
            this.lbRecords.TabIndex = 12;
            this.lbRecords.Text = "# Records:";
            // 
            // epFilter
            // 
            this.epFilter.ContainerControl = this;
            // 
            // rbtnNew
            // 
            this.rbtnNew.AutoSize = true;
            this.rbtnNew.Location = new System.Drawing.Point(100, 19);
            this.rbtnNew.Name = "rbtnNew";
            this.rbtnNew.Size = new System.Drawing.Size(47, 17);
            this.rbtnNew.TabIndex = 15;
            this.rbtnNew.TabStop = true;
            this.rbtnNew.Tag = "3";
            this.rbtnNew.Text = "New";
            this.rbtnNew.UseVisualStyleBackColor = true;
            this.rbtnNew.Click += new System.EventHandler(this.handleClick);
            // 
            // rbtnCompleted
            // 
            this.rbtnCompleted.AutoSize = true;
            this.rbtnCompleted.Location = new System.Drawing.Point(6, 19);
            this.rbtnCompleted.Name = "rbtnCompleted";
            this.rbtnCompleted.Size = new System.Drawing.Size(75, 17);
            this.rbtnCompleted.TabIndex = 16;
            this.rbtnCompleted.TabStop = true;
            this.rbtnCompleted.Tag = "1";
            this.rbtnCompleted.Text = "Completed";
            this.rbtnCompleted.UseVisualStyleBackColor = true;
            this.rbtnCompleted.Click += new System.EventHandler(this.handleClick);
            // 
            // rbtnCancelled
            // 
            this.rbtnCancelled.AutoSize = true;
            this.rbtnCancelled.Location = new System.Drawing.Point(6, 42);
            this.rbtnCancelled.Name = "rbtnCancelled";
            this.rbtnCancelled.Size = new System.Drawing.Size(72, 17);
            this.rbtnCancelled.TabIndex = 17;
            this.rbtnCancelled.TabStop = true;
            this.rbtnCancelled.Tag = "2";
            this.rbtnCancelled.Text = "Cancelled";
            this.rbtnCancelled.UseVisualStyleBackColor = true;
            this.rbtnCancelled.Click += new System.EventHandler(this.handleClick);
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.rbtnCompleted);
            this.gbStatus.Controls.Add(this.rbtnCancelled);
            this.gbStatus.Controls.Add(this.rbtnNew);
            this.gbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbStatus.Location = new System.Drawing.Point(251, 158);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(200, 59);
            this.gbStatus.TabIndex = 18;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::DVLD.Properties.Resources.application_list__1_;
            this.btnAdd.Location = new System.Drawing.Point(1050, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 74);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(531, 751);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 25);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.application_list;
            this.pictureBox1.Location = new System.Drawing.Point(531, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1179, 809);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.dgvApplications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Local Driving License Applications";
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.cmsLocalDrivingLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).EndInit();
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.ErrorProvider epFilter;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.RadioButton rbtnCompleted;
        private System.Windows.Forms.RadioButton rbtnCancelled;
        private System.Windows.Forms.RadioButton rbtnNew;
        private System.Windows.Forms.ContextMenuStrip cmsLocalDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem sechduToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practicalTestToolStripMenuItem;
    }
}