namespace DVLD
{
    partial class MangePeopleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MangePeopleForm));
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.cbNationlity = new System.Windows.Forms.ComboBox();
            this.epFilter = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).BeginInit();
            this.gbGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToResizeColumns = false;
            this.dgvPeople.AllowUserToResizeRows = false;
            this.dgvPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeople.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPeople.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPeople.Location = new System.Drawing.Point(12, 165);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.Size = new System.Drawing.Size(1233, 350);
            this.dgvPeople.TabIndex = 0;
            this.dgvPeople.VirtualMode = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.sendEmailToolStripMenuItem,
            this.phoneCallToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 244);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = global::DVLD.Properties.Resources.personal_card__1_;
            this.showToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.showToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.showToolStripMenuItem.Text = "Show Details";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 38);
            this.toolStripMenuItem2.Text = " Add New Person";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.person_boy__3_;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            // 
            // phoneCallToolStripMenuItem
            // 
            this.phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            this.phoneCallToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.phoneCallToolStripMenuItem.Text = "Phone Call ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(573, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mange People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "# Records";
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(124, 532);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(17, 18);
            this.lbRecord.TabIndex = 4;
            this.lbRecord.Text = "0";
            this.lbRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Filter by";
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
            this.cbFilter.Location = new System.Drawing.Point(96, 136);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 6;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(232, 136);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(138, 20);
            this.tbFilter.TabIndex = 7;
            // 
            // cbNationlity
            // 
            this.cbNationlity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNationlity.FormattingEnabled = true;
            this.cbNationlity.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gender",
            "Phone",
            "Email"});
            this.cbNationlity.Location = new System.Drawing.Point(232, 136);
            this.cbNationlity.Name = "cbNationlity";
            this.cbNationlity.Size = new System.Drawing.Size(138, 21);
            this.cbNationlity.TabIndex = 10;
            this.cbNationlity.SelectedIndexChanged += new System.EventHandler(this.cbNationlity_SelectedIndexChanged);
            // 
            // epFilter
            // 
            this.epFilter.ContainerControl = this;
            // 
            // gbGender
            // 
            this.gbGender.Controls.Add(this.rbtnMale);
            this.gbGender.Controls.Add(this.rbtnFemale);
            this.gbGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbGender.Location = new System.Drawing.Point(319, 116);
            this.gbGender.Name = "gbGender";
            this.gbGender.Size = new System.Drawing.Size(138, 40);
            this.gbGender.TabIndex = 11;
            this.gbGender.TabStop = false;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Location = new System.Drawing.Point(70, 22);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(34, 17);
            this.rbtnMale.TabIndex = 1;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "M";
            this.rbtnMale.UseVisualStyleBackColor = true;
            this.rbtnMale.Click += new System.EventHandler(this.rbtnMale_Click);
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(6, 22);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(31, 17);
            this.rbtnFemale.TabIndex = 0;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "F";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            this.rbtnFemale.Click += new System.EventHandler(this.rbtnFemale_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.FlatAppearance.BorderSize = 0;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Image = global::DVLD.Properties.Resources.administrator;
            this.btnAddPerson.Location = new System.Drawing.Point(1143, 97);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(92, 60);
            this.btnAddPerson.TabIndex = 8;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::DVLD.Properties.Resources.clients;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.clients;
            this.pictureBox1.InitialImage = global::DVLD.Properties.Resources.clients;
            this.pictureBox1.Location = new System.Drawing.Point(616, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MangePeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.cbNationlity);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvPeople);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MangePeopleForm";
            this.Text = "MangePeopleForm";
            this.Load += new System.EventHandler(this.MangePeopleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epFilter)).EndInit();
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.ComboBox cbNationlity;
        private System.Windows.Forms.ErrorProvider epFilter;
        private System.Windows.Forms.GroupBox gbGender;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}