using ApplicationServiceLib;
using MangeApplicationTypesForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testLibrary;

namespace DVLD.test
{
    public partial class frmListTestTypes : Form
    {
        private void _resetForm(object sender, EventArgs e)
        {
            _loadData();
        }
        private void _dgvApplicationTypes_Resize()
        {
            int totalWidth = dgvListTestTypes.Width;
            int columnCount = dgvListTestTypes.Columns.Count;
            if (columnCount > 0)
            {
                int widthPerColumn = totalWidth / columnCount;

                foreach (DataGridViewColumn column in dgvListTestTypes.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void _settings()
        {
            _dgvApplicationTypes_Resize();
            lbTotalRecords.Text = dgvListTestTypes.Rows.Count.ToString();
            
        }
        private async void _loadData()
        {

            DataTable dataTableApplicationTypes = await clsTestTypeService.returnTestTypes();
            dgvListTestTypes.DataSource = dataTableApplicationTypes;
            _settings();

        }
        public frmListTestTypes()
        {
            InitializeComponent();
            _loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListTestTypes.SelectedRows.Count > 0)
            {

                int rowIndex = dgvListTestTypes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvListTestTypes.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int testTypeId))
                    {
                        frmUpdateTestType form = new frmUpdateTestType(testTypeId);
                        form.OnAction += _resetForm;//if It was updated.
                        form.ShowDialog();
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
