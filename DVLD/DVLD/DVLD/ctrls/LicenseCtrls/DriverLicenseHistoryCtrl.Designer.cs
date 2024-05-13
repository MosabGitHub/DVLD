namespace DVLD.ctrls
{
    partial class DriverLicenseHistoryCtrl
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
            this.dgvLocalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTotalLocalRecords = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.lbTotalInternationalRecords = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmsLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInternational = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseHistory)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpLocal.SuspendLayout();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).BeginInit();
            this.cmsLocal.SuspendLayout();
            this.cmsInternational.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLocalLicenseHistory
            // 
            this.dgvLocalLicenseHistory.AllowUserToAddRows = false;
            this.dgvLocalLicenseHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicenseHistory.AllowUserToResizeColumns = false;
            this.dgvLocalLicenseHistory.AllowUserToResizeRows = false;
            this.dgvLocalLicenseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenseHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLocalLicenseHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLocalLicenseHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvLocalLicenseHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLocalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenseHistory.ContextMenuStrip = this.cmsLocal;
            this.dgvLocalLicenseHistory.Location = new System.Drawing.Point(-4, 24);
            this.dgvLocalLicenseHistory.Name = "dgvLocalLicenseHistory";
            this.dgvLocalLicenseHistory.ReadOnly = true;
            this.dgvLocalLicenseHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLocalLicenseHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLocalLicenseHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicenseHistory.Size = new System.Drawing.Size(908, 163);
            this.dgvLocalLicenseHistory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local licenses history";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "# Records";
            // 
            // lbTotalLocalRecords
            // 
            this.lbTotalLocalRecords.AutoSize = true;
            this.lbTotalLocalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalLocalRecords.Location = new System.Drawing.Point(135, 211);
            this.lbTotalLocalRecords.Name = "lbTotalLocalRecords";
            this.lbTotalLocalRecords.Size = new System.Drawing.Size(14, 16);
            this.lbTotalLocalRecords.TabIndex = 5;
            this.lbTotalLocalRecords.Text = "?";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLocal);
            this.tabControl1.Controls.Add(this.tpInternational);
            this.tabControl1.Location = new System.Drawing.Point(20, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(912, 276);
            this.tabControl1.TabIndex = 6;
            // 
            // tpLocal
            // 
            this.tpLocal.BackColor = System.Drawing.Color.Silver;
            this.tpLocal.Controls.Add(this.dgvLocalLicenseHistory);
            this.tpLocal.Controls.Add(this.lbTotalLocalRecords);
            this.tpLocal.Controls.Add(this.label1);
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Location = new System.Drawing.Point(4, 22);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(904, 250);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            // 
            // tpInternational
            // 
            this.tpInternational.BackColor = System.Drawing.Color.Silver;
            this.tpInternational.Controls.Add(this.dgvInternationalLicenseHistory);
            this.tpInternational.Controls.Add(this.lbTotalInternationalRecords);
            this.tpInternational.Controls.Add(this.label4);
            this.tpInternational.Controls.Add(this.label5);
            this.tpInternational.Location = new System.Drawing.Point(4, 22);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(904, 250);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            // 
            // dgvInternationalLicenseHistory
            // 
            this.dgvInternationalLicenseHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicenseHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenseHistory.AllowUserToResizeColumns = false;
            this.dgvInternationalLicenseHistory.AllowUserToResizeRows = false;
            this.dgvInternationalLicenseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenseHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInternationalLicenseHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvInternationalLicenseHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvInternationalLicenseHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInternationalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseHistory.ContextMenuStrip = this.cmsInternational;
            this.dgvInternationalLicenseHistory.Location = new System.Drawing.Point(0, 24);
            this.dgvInternationalLicenseHistory.Name = "dgvInternationalLicenseHistory";
            this.dgvInternationalLicenseHistory.ReadOnly = true;
            this.dgvInternationalLicenseHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInternationalLicenseHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInternationalLicenseHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicenseHistory.Size = new System.Drawing.Size(904, 163);
            this.dgvInternationalLicenseHistory.TabIndex = 6;
            // 
            // lbTotalInternationalRecords
            // 
            this.lbTotalInternationalRecords.AutoSize = true;
            this.lbTotalInternationalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalInternationalRecords.Location = new System.Drawing.Point(132, 216);
            this.lbTotalInternationalRecords.Name = "lbTotalInternationalRecords";
            this.lbTotalInternationalRecords.Size = new System.Drawing.Size(14, 16);
            this.lbTotalInternationalRecords.TabIndex = 9;
            this.lbTotalInternationalRecords.Text = "?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Internationl licenses history";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "# Records";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 302);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driving License";
            // 
            // cmsLocal
            // 
            this.cmsLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocal.Name = "contextMenuStrip1";
            this.cmsLocal.Size = new System.Drawing.Size(170, 26);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.info;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // cmsInternational
            // 
            this.cmsInternational.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsInternational.Name = "contextMenuStrip1";
            this.cmsInternational.Size = new System.Drawing.Size(170, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.info;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Show License Info";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // DriverLicenseHistoryCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DriverLicenseHistoryCtrl";
            this.Size = new System.Drawing.Size(946, 305);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseHistory)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).EndInit();
            this.cmsLocal.ResumeLayout(false);
            this.cmsInternational.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocalLicenseHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTotalLocalRecords;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseHistory;
        private System.Windows.Forms.Label lbTotalInternationalRecords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip cmsLocal;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternational;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
