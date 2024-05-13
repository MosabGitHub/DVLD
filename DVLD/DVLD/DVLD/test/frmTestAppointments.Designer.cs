namespace DVLD.test
{
    partial class frmTestAppointments
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
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbAppointments = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.applicationInfoCtrl1 = new DVLD.ctrls.ApplicationInfoCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.cmsAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMain.ForeColor = System.Drawing.Color.Red;
            this.lbMain.Location = new System.Drawing.Point(298, 87);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(24, 25);
            this.lbMain.TabIndex = 1;
            this.lbMain.Text = "?";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToResizeColumns = false;
            this.dgvAppointments.AllowUserToResizeRows = false;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmsAppointments;
            this.dgvAppointments.Location = new System.Drawing.Point(63, 528);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(742, 150);
            this.dgvAppointments.TabIndex = 3;
            // 
            // cmsAppointments
            // 
            this.cmsAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsAppointments.Name = "cmsAppointments";
            this.cmsAppointments.Size = new System.Drawing.Size(125, 56);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_config;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.history;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // lbAppointments
            // 
            this.lbAppointments.AutoSize = true;
            this.lbAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointments.Location = new System.Drawing.Point(59, 505);
            this.lbAppointments.Name = "lbAppointments";
            this.lbAppointments.Size = new System.Drawing.Size(120, 20);
            this.lbAppointments.TabIndex = 4;
            this.lbAppointments.Text = "Appointments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 697);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Records";
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecords.Location = new System.Drawing.Point(149, 697);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(15, 16);
            this.lbTotalRecords.TabIndex = 6;
            this.lbTotalRecords.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(363, 697);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.cars;
            this.pictureBox1.Location = new System.Drawing.Point(364, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Image = global::DVLD.Properties.Resources.clock;
            this.button2.Location = new System.Drawing.Point(772, 494);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 31);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnAppointment_Click);
            // 
            // applicationInfoCtrl1
            // 
            this.applicationInfoCtrl1.Location = new System.Drawing.Point(30, 129);
            this.applicationInfoCtrl1.Name = "applicationInfoCtrl1";
            this.applicationInfoCtrl1.Size = new System.Drawing.Size(832, 356);
            this.applicationInfoCtrl1.TabIndex = 0;
            // 
            // frmTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(862, 745);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAppointments);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.applicationInfoCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestAppointments";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vision Test Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmsAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrls.ApplicationInfoCtrl applicationInfoCtrl1;
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label lbAppointments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}