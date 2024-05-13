namespace DVLD.test
{
    partial class frmListTestTypes
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
            this.dgvListTestTypes = new System.Windows.Forms.DataGridView();
            this.lbMain = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTestTypes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListTestTypes
            // 
            this.dgvListTestTypes.AllowUserToAddRows = false;
            this.dgvListTestTypes.AllowUserToDeleteRows = false;
            this.dgvListTestTypes.AllowUserToResizeRows = false;
            this.dgvListTestTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvListTestTypes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvListTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListTestTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListTestTypes.Location = new System.Drawing.Point(38, 148);
            this.dgvListTestTypes.MultiSelect = false;
            this.dgvListTestTypes.Name = "dgvListTestTypes";
            this.dgvListTestTypes.ReadOnly = true;
            this.dgvListTestTypes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvListTestTypes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListTestTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListTestTypes.Size = new System.Drawing.Size(705, 347);
            this.dgvListTestTypes.TabIndex = 0;
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMain.ForeColor = System.Drawing.Color.Red;
            this.lbMain.Location = new System.Drawing.Point(277, 74);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(227, 29);
            this.lbMain.TabIndex = 1;
            this.lbMain.Text = "Manage Test Types";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.Black;
            this.lbRecords.Location = new System.Drawing.Point(35, 538);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(96, 20);
            this.lbRecords.TabIndex = 2;
            this.lbRecords.Text = "# Records:";
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Location = new System.Drawing.Point(156, 543);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(0, 13);
            this.lbTotalRecords.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(349, 527);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 26);
            // 
            // editTestTypeToolStripMenuItem
            // 
            this.editTestTypeToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_config;
            this.editTestTypeToolStripMenuItem.Name = "editTestTypeToolStripMenuItem";
            this.editTestTypeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editTestTypeToolStripMenuItem.Text = "Edit test type";
            this.editTestTypeToolStripMenuItem.Click += new System.EventHandler(this.editTestTypeToolStripMenuItem_Click);
            // 
            // frmListTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 575);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.dgvListTestTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListTestTypes";
            this.Text = "List Test Types";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTestTypes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListTestTypes;
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editTestTypeToolStripMenuItem;
    }
}