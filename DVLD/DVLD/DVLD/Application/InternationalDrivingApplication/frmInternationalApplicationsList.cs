using DriverServiceLib;
using DVLD.Drivers;
using DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppplicationSerivceLib;
using LicensesServiceLib;

namespace DVLD.Application.InternationalDrivingApplication
{
    public partial class frmInternationalApplicationsList : Form
    {
        bool isDataLoadedProperly = false;
        public frmInternationalApplicationsList()
        {

            InitializeComponent();
            _loadData();
            _settings();

        }
        private void _resetVisibilityAndEventHandlers()
        {

            tbFilter.Visible = false;
            tbFilter.KeyPress -= tbInternationalLicenseIdFilter_KeyPress;
            tbFilter.KeyPress -= tbApplicationIDFilter_KeyPress;
            tbFilter.KeyPress -= tbDriverIDFilter_KeyPress;
            //tbFilter.KeyPress -= tbFullNameFilter_KeyPress;
            //cbIsActive.KeyPress -= cbIsActive_SelectedIndexChanged;

        }
        private void _resetForm()
        {
            _loadData();
            _settings();
        }
        private void _loadFilteredData(DataTable FilterDataTable)
        {
            if (FilterDataTable.Rows.Count > 0)
                isDataLoadedProperly = true;
            dgvListInternationalLicensesApplication.DataSource = FilterDataTable;
        }
        private void _settings()
        {
            tbFilter.Visible = false;
        }
        private void _showRecords()
        {
            lbRecords.Text = dgvListInternationalLicensesApplication.Rows.Count.ToString();

        }
        private async void _loadData()
        {
            await _loadInternationalDrivingLicenseApplications();
            _showRecords();

        }
        private async Task _loadInternationalDrivingLicenseApplications()
        {
            try
            {
                DataTable DriverDataTable = await clsInternationalLicenseService.GetAllInternationalDrivingLicenseApplications();
                // Now you can use userDataTable as you need, for example, setting it as a DataSource for a DataGridView.
                if (DriverDataTable.Rows.Count > 0)
                {
                    isDataLoadedProperly = true;
                }
                if (isDataLoadedProperly)
                {
                    dgvListInternationalLicensesApplication.DataSource = DriverDataTable;
                    dgvListInternationalLicensesApplication.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as appropriate.
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void _filterData()
        {
            _resetVisibilityAndEventHandlers();//Reset. 

            string filterType = cbFilter.SelectedItem.ToString().Trim();
        
            string filterValue = tbFilter.Text.ToLower();

            switch (filterType)
            {
                case "International Driving License ID":
                    {
                        tbFilter.KeyPress += tbInternationalLicenseIdFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }

                case "Application ID":
                    {
                        tbFilter.KeyPress += tbApplicationIDFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                case "Driver ID":
                    {
                        tbFilter.KeyPress += tbDriverIDFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                case "Is Active":
                    {
                        rbtnActive.Visible = true;
                        rbtnNotActive.Visible= true;
                        break;
                    }


                default://None.
                    {
                        _resetForm();
                        break;
                    }

            }

        }
        private async void tbInternationalLicenseIdFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidIDCharachter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }

            else
            {
                if (e.KeyChar == '\b' && tbFilter.Text.Length > 0)
                {
                    // Remove the last character
                    tbFilter.Text.Remove(tbFilter.Text.Length - 1);

                }

                if (int.TryParse(tbFilter.Text + e.KeyChar, out int InternationalLicenseID))
                {
                    var dataTable = await clsInternationalLicenseService.
                        GetAllInternationalDrivingLicenseApplicationsByInternationalLicenseID(InternationalLicenseID);
                    _loadFilteredData(dataTable);
                }

            }

        }
        private async void tbApplicationIDFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidIDCharachter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }

            else
            {
                if (e.KeyChar == '\b' && tbFilter.Text.Length > 0)
                {
                    // Remove the last character
                    tbFilter.Text.Remove(tbFilter.Text.Length - 1);

                }

                if (int.TryParse(tbFilter.Text + e.KeyChar, out int InternationalApplicationID))
                {
                    var dataTable = await clsInternationalLicenseService.
                        GetAllInternationalDrivingLicenAppByIntAppID(InternationalApplicationID);
                    _loadFilteredData(dataTable);
                }

            }

        }
        private async void tbDriverIDFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidIDCharachter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }

            else
            {
                if (e.KeyChar == '\b' && tbFilter.Text.Length > 0)
                {
                    // Remove the last character
                    tbFilter.Text.Remove(tbFilter.Text.Length - 1);

                }

                if (int.TryParse(tbFilter.Text + e.KeyChar, out int DriverID))
                {
                    var dataTable = await clsInternationalLicenseService.GetAllInternationalDrivingLicenAppByDriverID(DriverID);
                    _loadFilteredData(dataTable);
                }

            }

        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filterData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void rbtnNotActive_Click(object sender, EventArgs e)
        {
            var dataTable = await clsInternationalLicenseService.GetAllActiveInternationalDrivingLicenAppByActive(false);
            _loadFilteredData(dataTable);

        }

        private async void rbtnActive_Click(object sender, EventArgs e)
        {
            var dataTable = await clsInternationalLicenseService.GetAllActiveInternationalDrivingLicenAppByActive(true);
            _loadFilteredData(dataTable);

        }
    }

}

