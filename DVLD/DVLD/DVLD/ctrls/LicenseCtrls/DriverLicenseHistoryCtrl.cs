using AppplicationSerivceLib;
using DriverServiceLib;
using DVLD.Licenses;
using LicensesServiceLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ctrls
{
    public partial class DriverLicenseHistoryCtrl : UserControl
    {
        private bool isDataLoadedProperly_localLicense = false;
       
        private bool isDataLoadedProperly_internationalLicense = false;
        public DriverLicenseHistoryCtrl()
        {
            InitializeComponent();
        }
        public void LoadDriverLicensesHistory(int driverID)
        {
            _loadLocalDrivingLicensesHistory(driverID);
            _loadInternationalDrivingLicensesHistory(driverID);
        }
        private async void _loadLocalDrivingLicensesHistory(int driverID)
        {
            try
            {
                DataTable localLicensesHistoryDataTable = await clsLicenseService.FindAllLocalLicensesByDriverID(driverID);
                // Now you can use user DataTable as you need , for example , setting it as a DataSource for a DataGridView.
                if (localLicensesHistoryDataTable.Rows.Count > 0)
                {
                    isDataLoadedProperly_localLicense = true;
                }
                if (isDataLoadedProperly_localLicense)
                {
                    dgvLocalLicenseHistory.DataSource = localLicensesHistoryDataTable;
                    dgvLocalLicenseHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    lbTotalLocalRecords.Text = localLicensesHistoryDataTable.Rows.Count.ToString();
                }
            }

            catch (Exception ex)
            {
                // Handle or log the exception as appropriate.
                MessageBox.Show($"An error occurred, due to try load the Local driver Licenses History: {ex.Message}");
            }

        }
        private async void _loadInternationalDrivingLicensesHistory(int driverID)
        {
            try
            {
                DataTable internationalLicensesHistoryDataTable = await clsLicenseService.FindAllInternationalLicensesByDriverID(driverID);
                // Now you can use user DataTable as you need , for example , setting it as a DataSource for a DataGridView.
                if (internationalLicensesHistoryDataTable.Rows.Count > 0)
                {
                    isDataLoadedProperly_internationalLicense = true;
                }
                if (isDataLoadedProperly_internationalLicense)
                {
                    dgvInternationalLicenseHistory.DataSource = internationalLicensesHistoryDataTable;
                    dgvInternationalLicenseHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    lbTotalInternationalRecords.Text = internationalLicensesHistoryDataTable.Rows.Count.ToString();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred , due to try load the International driver Licenses History: {ex.Message}");
            }
        }     
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicenseHistory.SelectedRows.Count == 1)
            {
                int rowIndex = dgvLocalLicenseHistory.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvLocalLicenseHistory.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LicenseID"].Value.ToString(), out int localLicenseID))
                    {

                        frmLicenseInfo form = new frmLicenseInfo(localLicenseID);

                        form.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Choose only one application.", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }             
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenseHistory.SelectedRows.Count == 1)
            {
                int rowIndex = dgvInternationalLicenseHistory.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvInternationalLicenseHistory.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["L.LICENSE ID"].Value.ToString(), out int localLicenseID))
                    {

                        frmLicenseInfo form = new frmLicenseInfo(localLicenseID);

                        form.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Choose only one application.", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
