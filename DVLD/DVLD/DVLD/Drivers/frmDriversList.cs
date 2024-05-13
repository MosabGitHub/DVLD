using AppplicationSerivceLib;
using DetainLicenseServiceLib;
using DriverServiceLib;
using GlobalSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Drivers
{
    public partial class frmDriversList : Form
    {
        bool isDataLoadedProperly = false;
        public frmDriversList()
        {
            InitializeComponent();
            _loadData();
            _settings();
        }
        private void _resetVisibilityAndEventHandlers()
        {

            tbFilter.Visible = false;
            tbFilter.KeyPress -= tbDriverIdFilter_KeyPress;
            tbFilter.KeyPress -= tbPersonIdFilter_KeyPress;
            tbFilter.KeyPress -= tbNationalNoFilter_KeyPress;
            tbFilter.KeyPress -= tbFullNameFilter_KeyPress;
            //cbIsActive.KeyPress -= cbIsActive_SelectedIndexChanged;

        }
        private void _showRecords()
        {
            lbRecords.Text = dgvListDrivers.Rows.Count.ToString();

        }
        private void _settings()
        {
            tbFilter.Visible = false;
        }
        private async void _loadData()
        {
            await _loadDrivers();
            _showRecords();

        }
        private async Task _loadDrivers()
        {
            try
            {
                DataTable DriverDataTable = await clsDriverService.Find();
                // Now you can use userDataTable as you need, for example, setting it as a DataSource for a DataGridView.
                if (DriverDataTable.Rows.Count > 0)
                {
                    isDataLoadedProperly = true;
                }
                if (isDataLoadedProperly)
                {
                    dgvListDrivers.DataSource = DriverDataTable;
                    dgvListDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as appropriate.
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void _resetForm()
        {
            _loadData();
            _settings();
        }
        private void _loadFilteredData(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
                isDataLoadedProperly = true;
            dgvListDrivers.DataSource = dataTable;
        }
        private void _filterData()
        {
            _resetVisibilityAndEventHandlers();//Reset. 

            string filterType = cbFilter.SelectedItem.ToString().ToLower();

            string filterValue = tbFilter.Text.ToLower();

            switch (filterType)
            {

                case "driver id":
                    {
                        tbFilter.KeyPress += tbDriverIdFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                
                case "person id":
                    {
                        tbFilter.KeyPress += tbPersonIdFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                case "national no":
                    {
                        tbFilter.KeyPress += tbNationalNoFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                case "full name":
                    {
                        tbFilter.KeyPress += tbFullNameFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }


                default://None.
                    {
                        _resetForm();
                        break;
                    }

            }

        }
        private async void tbDriverIdFilter_KeyPress(object sender, KeyPressEventArgs e)
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
                string value = "";
                if (e.KeyChar == '\b' && tbFilter.Text.Length > 0)
                {
                    // Remove the last character
                    value = tbFilter.Text.Remove(tbFilter.Text.Length - 1);

                }
                else if (e.KeyChar != '\b')
                {
                    value = tbFilter.Text + e.KeyChar;
                }
                if (int.TryParse(value, out int id))
                {
                    var dataTable = await clsDriverService.getDriversInfoByID(id);
                    _loadFilteredData(dataTable);
                }
            }
        

        }
        private async void tbPersonIdFilter_KeyPress(object sender, KeyPressEventArgs e)
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
                string value = "";
                if (e.KeyChar == '\b' && tbFilter.Text.Length > 0)
                {
                    // Remove the last character
                    value = tbFilter.Text.Remove(tbFilter.Text.Length - 1);

                }
                else if (e.KeyChar != '\b')
                {
                    value = tbFilter.Text + e.KeyChar;
                }

                if (int.TryParse(value, out int id))
                {
                    var dataTable = await clsDriverService.getDriversInfoByPersonID(id);
                    _loadFilteredData(dataTable);
                }
            }

         

        }
        private async void tbNationalNoFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidNationalNoCharater(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }
            else
            {
                string value = "";
                if (e.KeyChar == '\b' && tbFilter.Text.Length > 0)
                {
                    // Remove the last character
                    value = tbFilter.Text.Remove(tbFilter.Text.Length - 1);

                }
                else if (e.KeyChar != '\b')
                {
                    value = tbFilter.Text + e.KeyChar;
                }
                var dataTable = await clsDriverService.getDriversInfoByNationalNo(value);
                _loadFilteredData(dataTable);
            }
         
        }
        private async void tbFullNameFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidNameCharacter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }
            else
            {
                string value = "";
                if (e.KeyChar == '\b' && tbFilter.Text.Length > 0)
                {
                    // Remove the last character
                    value = tbFilter.Text.Remove(tbFilter.Text.Length - 1);

                }
                else if (e.KeyChar != '\b')
                {
                    value = tbFilter.Text + e.KeyChar;
                }
                var dataTable = await clsDriverService.getDriversInfoByFullName(value);
                _loadFilteredData(dataTable);
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

    }
}
