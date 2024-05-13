namespace DVLD.Application
{
    partial class frmMangeApplicationTypes
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
            this.dgvApplicationTypes = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbMain = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvApplicationTypes
            // 
            this.dgvApplicationTypes.AllowUserToAddRows = false;
            this.dgvApplicationTypes.AllowUserToDeleteRows = false;
            this.dgvApplicationTypes.AllowUserToResizeColumns = false;
            this.dgvApplicationTypes.AllowUserToResizeRows = false;
            this.dgvApplicationTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApplicationTypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvApplicationTypes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvApplicationTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApplicationTypes.Location = new System.Drawing.Point(12, 211);
            this.dgvApplicationTypes.Name = "dgvApplicationTypes";
            this.dgvApplicationTypes.ReadOnly = true;
            this.dgvApplicationTypes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvApplicationTypes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvApplicationTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicationTypes.Size = new System.Drawing.Size(666, 386);
            this.dgvApplicationTypes.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            this.editApplicationTypeToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_config;
            this.editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            this.editApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.editApplicationTypeToolStripMenuItem.Text = "Edit Application Type";
            this.editApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMain.Location = new System.Drawing.Point(200, 152);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(291, 25);
            this.lbMain.TabIndex = 2;
            this.lbMain.Text = "Manage Application Types";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(26, 620);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(101, 24);
            this.lbRecords.TabIndex = 3;
            this.lbRecords.Text = "# Records:";
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecords.ForeColor = System.Drawing.Color.Black;
            this.lbTotalRecords.Location = new System.Drawing.Point(133, 624);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(0, 16);
            this.lbTotalRecords.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(306, 620);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.papers;
            this.pictureBox1.Location = new System.Drawing.Point(313, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmMangeApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 657);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvApplicationTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMangeApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mange Application Types";
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApplicationTypes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTypeToolStripMenuItem;
    }
}