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
namespace DVLD.Application
{
    public partial class frmMangeApplicationTypes : Form
    {
        private void _resetForm(object sender, EventArgs e)
        {
            _loadData();
        }
        private void _dgvApplicationTypes_Resize()
        {
            int totalWidth = dgvApplicationTypes.Width;
            int columnCount = dgvApplicationTypes.Columns.Count;
            if (columnCount > 0)
            {
                int widthPerColumn = totalWidth / columnCount;

                foreach (DataGridViewColumn column in dgvApplicationTypes.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void _settings()
        {
            _dgvApplicationTypes_Resize();
            lbTotalRecords.Text=dgvApplicationTypes.Rows.Count.ToString();
        }
        private async void _loadData()
        {

            DataTable dataTableApplicationTypes = await clsApplicationTypeService.returnApplicationTypes();
            dgvApplicationTypes.DataSource = dataTableApplicationTypes;
            _settings();

        }
        public frmMangeApplicationTypes()
        {
            InitializeComponent();
            _loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (dgvApplicationTypes.SelectedRows.Count > 0) {

                    int rowIndex = dgvApplicationTypes.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvApplicationTypes.Rows[rowIndex];
                    try
                    {
                        if(int.TryParse(selectedRow.Cells["ID"].Value.ToString(),out int applicationTypeId))
                        {
                            frmUpdateApplicationType form = new frmUpdateApplicationType(applicationTypeId);
                            form.onAction += _resetForm;//On update request.
                            form.ShowDialog();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error:"+ex.Message,"Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
