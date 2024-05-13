using DetainLicenseServiceLib;
using DVLD.Application.DetainAndReleaseApplication.DetainApplications;
using DVLD.Application.DetainAndReleaseApplication.ReleaseApplication;
using GlobalSettings;
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

namespace DVLD.Application.DetainAndReleaseApplication
{
    public partial class frmListDetainLicenses : Form
    {


        private bool _isDataLoadedProperly = false;
        public frmListDetainLicenses()
        {
            InitializeComponent();
            _loadData();
        }

        private void _resetVisibilityAndEventHandlers()
        {
            tbFilter.Visible = false;
            rbtnRelease.Visible = false;
            rbtnDetained.Visible = false;
            tbFilter.KeyPress -= tbIdFilter_KeyPress;
            tbFilter.KeyPress -= tbNameFilter_KeyPress;
        }
        private void _resetForm()
        {
            _settings();
            _loadData();
        }
        private void _loadFilteredData(DataTable FilterDataTable)
        {

            if (FilterDataTable != null && FilterDataTable.Rows.Count > 0)
            {
                _isDataLoadedProperly = true;

            }
            dgvListDetainedLicenses.DataSource = FilterDataTable;

        }
        private void _settings()
        {
            tbFilter.Visible = false;
            cbFilter.SelectedIndex = 0;
        }
        private void _showRecords()
        {
            lbRecords.Text = dgvListDetainedLicenses.Rows.Count.ToString();

        }
        private async void _loadData()
        {
            await _loadDetainedDrivingLicenses();
            _showRecords();

        }
        private async Task _loadDetainedDrivingLicenses()
        {
            try
            {
                DataTable DetainedLicensesDataTable = await clsDetainLicenseService.GetAllDetainedLicensesInfo();
                // Now you can use userDataTable as you need, for example, setting it as a DataSource for a DataGridView.
                if (DetainedLicensesDataTable.Rows.Count > 0)
                {
                    _isDataLoadedProperly = true;
                }
                if (_isDataLoadedProperly)
                {
                    dgvListDetainedLicenses.DataSource = DetainedLicensesDataTable;
                    dgvListDetainedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception was thrown  ,while loading detained licenses data\n: {ex.Message}");
            }
        }
        private void _filterData()
        {
            _resetVisibilityAndEventHandlers();//Reset. 

            switch (cbFilter.SelectedIndex)
            {
                case 1://Detain id 
                    {
                        tbFilter.KeyPress += tbIdFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }

                case 2://Is released
                    {
                        rbtnDetained.Visible = true;
                        rbtnRelease.Visible = true;
                        break;
                    }
                case 3://National no
                    {
                        tbFilter.KeyPress += tbNameFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                case 4://Full name
                    {
                        tbFilter.KeyPress += tbNameFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }

                case 5://Release app Id 
                    {
                        tbFilter.KeyPress += tbIdFilter_KeyPress;
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

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filterData();

        }
        private enDetainLicenseListFilters _returnFilterModeBaseOnComboBoxIndex()
        {
            switch (cbFilter.SelectedIndex)
            {

                case 0:
                    {
                        return enDetainLicenseListFilters.None;
                    }
                case 1:
                    {
                        return enDetainLicenseListFilters.DetainID;
                    }
                case 2:
                    {
                        return enDetainLicenseListFilters.IsReleased;
                    }
                case 3:
                    {
                        return enDetainLicenseListFilters.NationalNo;
                    }
                case 4:
                    {
                        return enDetainLicenseListFilters.FullName;
                    }
                case 5:
                    {
                        return enDetainLicenseListFilters.ReleaseApplicationID;
                    }
                default:
                    {
                        return enDetainLicenseListFilters.None;
                    }
            }
        }
        private async void tbIdFilter_KeyPress(object sender, KeyPressEventArgs e)
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
                    enDetainLicenseListFilters DetainedFilterMode = _returnFilterModeBaseOnComboBoxIndex();
                    if (DetainedFilterMode == enDetainLicenseListFilters.None)
                    {
                        MessageBox.Show("filter has a problem with combo box values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _resetForm();
                    }
                    else
                    {
                        var dataTable = await clsDetainLicenseService.GetFilteredDetainedLicensesInfo(DetainedFilterMode, id.ToString());
                        _loadFilteredData(dataTable);
                    }
                }

            }

        }
        private async void tbNameFilter_KeyPress(object sender, KeyPressEventArgs e)
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
                enDetainLicenseListFilters DetainedFilterMode = _returnFilterModeBaseOnComboBoxIndex();
                var dataTable = await clsDetainLicenseService.GetFilteredDetainedLicensesInfo(DetainedFilterMode, value);
                _loadFilteredData(dataTable);

            }

        }

        private async void radioButton_checkedChange(object sender, EventArgs e)
        {

            RadioButton radioButton = (RadioButton)sender;

            if (radioButton != null && radioButton.Checked)
            {


                if (radioButton == rbtnDetained)
                {
                    _loadFilteredData(await clsDetainLicenseService.GetFilteredDetainedLicensesInfo(_returnFilterModeBaseOnComboBoxIndex(), "0"));

                }
                else if (radioButton == rbtnRelease)
                {
                    _loadFilteredData(await clsDetainLicenseService.GetFilteredDetainedLicensesInfo(_returnFilterModeBaseOnComboBoxIndex(), "1"));

                }
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainApplication form=new frmDetainApplication();
            form.ShowDialog();
            _resetForm();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleasedApplication form= new frmReleasedApplication();
            form.ShowDialog();
            _resetForm();

        }
    }
}