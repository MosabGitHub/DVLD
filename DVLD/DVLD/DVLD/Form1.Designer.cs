namespace DVLD
{
    partial class Form1
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(192, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 48);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "AddNewPersonToDataBase";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Location = new System.Drawing.Point(25, 12);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(64, 44);
            this.btnFindPerson.TabIndex = 1;
            this.btnFindPerson.Text = "Delete";
            this.btnFindPerson.UseVisualStyleBackColor = true;
            // 
            // dgvPeople
            // 
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Location = new System.Drawing.Point(42, 109);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.Size = new System.Drawing.Size(1287, 315);
            this.dgvPeople.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 450);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.btnFindPerson);
            this.Controls.Add(this.btnSave);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.DataGridView dgvPeople;
    }
}

