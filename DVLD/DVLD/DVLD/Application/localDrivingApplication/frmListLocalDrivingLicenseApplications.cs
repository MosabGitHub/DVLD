using AppplicationSerivceLib;

using clsUsers;
using DVLD.DTOs;
using GlobalSettings;
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
using static clsUsers.clsUserService;
using GlobalSettings;
using DVLD.test;
using clsAppointmentServiceLib;
using DVLD.Licenses;
using LicensesServiceLib;
namespace DVLD.Application.localDrivingApplication
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        bool isDataLoadedProperly = false;
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _loadData(); 
            _settings();
        }
        private void _resetVisibilityAndEventHandlers()
        {

            tbFilter.Visible = false;
            gbStatus.Visible = false;
            tbFilter.KeyPress -= tbIdFilter_KeyPress;
            tbFilter.KeyPress -= tbNationalNoFilter_KeyPress;
            tbFilter.KeyPress -= tbFullNameFilter_KeyPress;
            //cbIsActive.KeyPress -= cbIsActive_SelectedIndexChanged;

        }
        private void _settings()
        {
            tbFilter.Visible = false;
            gbStatus.Visible = false;

        }
        private void showRecords()
        {
            lbTotalRecords.Text = dgvApplications.Rows.Count.ToString();

        }
        private  void _resetForm()
        {
             _loadData();
            _settings();
        }
        private async void _loadData()
        {
            await _loadLocalApplications();
            showRecords();

        }
        private async Task _loadLocalApplications()
        {
            try
            {
                DataTable localAppDataTable = await clsApplicationService.returnLocalApplicationsInfo();
                // Now you can use userDataTable as you need, for example, setting it as a DataSource for a DataGridView.
                if (localAppDataTable.Rows.Count > 0)
                {
                    isDataLoadedProperly = true;
                }
                if (isDataLoadedProperly)
                {
                    dgvApplications.DataSource = localAppDataTable;
                    dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as appropriate.
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _loadFilterdDataTable(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
                isDataLoadedProperly = true;
            dgvApplications.DataSource = dataTable;
        }
        private  void _filterData()
        {
            _resetVisibilityAndEventHandlers();//Reset. 

            string filterType = cbFilter.SelectedItem.ToString().ToLower();

            string filterValue = tbFilter.Text.ToLower();

            switch (filterType)
            {

                case "l.d.l appid":
                    {
                        tbFilter.KeyPress += tbIdFilter_KeyPress;
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

                case "status":
                    { 
                        gbStatus.Visible = true;
                        break;
                    }
 
                default://None.
                    {
                        _resetForm();
                        break;
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
              
                    if (int.TryParse(tbFilter.Text+e.KeyChar, out int id))
                    {
                        var dataTable = await clsApplicationService.clsSearchForApplication.getAllApplicationByID(id);
                        _loadFilterdDataTable(dataTable);
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
                // Use a small delay to ensure the textbox value is updated
                e.Handled = false;
                epFilter.SetError(tbFilter, "");
                char character = e.KeyChar;
                var dataTable = await clsApplicationService.clsSearchForApplication.getAllApplicationByPersonNationalNo(tbFilter.Text.Trim().ToLower() + character);
                _loadFilterdDataTable(dataTable);

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
                e.Handled = false;
                epFilter.SetError(tbFilter, "");
                char character = e.KeyChar;
                if (character != (char)Keys.Back&&character !=(char)Keys.Space)
                {
                    var dataTable = await clsApplicationService.clsSearchForApplication.GetAllApplicationByFullName(tbFilter.Text.Trim().ToLower() + character);

                    _loadFilterdDataTable(dataTable);
                }
            }
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filterData();

        }     
        private async void handleClick(object sender, EventArgs e)
        {
           
             RadioButton button = (RadioButton)sender;
             int.TryParse( button.Tag.ToString(),out int statusID);
             DataTable appDataTable= await clsApplicationService.clsSearchForApplication.GetAllApplicationByStatusID(statusID);
            _loadFilterdDataTable(appDataTable);
           
        }
        private void _raiseEventOfAddedApplication(object sender, EventArgs e)
        {
            _resetForm();
        }
        private void _subscribeEventHandlerAddedApplication(ref frmAddEditNewLocalDrivingLicense form)
        {
            form.evLocalApplicationWasAdded += _raiseEventOfAddedApplication;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditNewLocalDrivingLicense form=new frmAddEditNewLocalDrivingLicense();
            _subscribeEventHandlerAddedApplication(ref form);
            form.ShowDialog();
        }

        private bool _ApplicationStatusCompleted(int applicationID)
        {
            return clsApplicationService.CompleteLocalApplication(applicationID);
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count > 0)
            {

                System.Media.SystemSounds.Hand.Play();
                var confirm = MessageBox.Show("Are you sure you want to cancel application", "Confirm Cancellation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (dgvApplications.SelectedCells.Count > 0)
                        {
                            List<int> selectedApplicationIDS = new List<int>();
                            foreach (DataGridViewRow selectedRow in dgvApplications.SelectedRows)
                            {
                                int localApplicationID = (int)selectedRow.Cells["LocalApplicationID"].Value;
                                selectedApplicationIDS.Add(localApplicationID);
                            }

                            if ( clsApplicationService.cancelLocalApplication(selectedApplicationIDS))
                            {
                                _resetForm();
                                MessageBox.Show("Application cancelled successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Application delete process was terminate.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(),out int localApplicationId))
                    {
                        frmTestAppointments visionForm = new frmTestAppointments(localApplicationId,
                            enTestType.Vision);
                        visionForm.ShowDialog();
                        _resetForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Choose only one application.","failed",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationID))
                    {

                        frmShowLocalApplicationDetails form = new frmShowLocalApplicationDetails(localApplicationID);
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
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationID))
                    {

                        frmAddEditNewLocalDrivingLicense form = new frmAddEditNewLocalDrivingLicense(localApplicationID);
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
        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Hand.Play();
            var confirm = MessageBox.Show("Are you sure you want to delete user(s)", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (dgvApplications.SelectedCells.Count > 0)
                    {
                        List<int> selectedApplicationIDS = new List<int>();
                        foreach (DataGridViewRow selectedRow in dgvApplications.SelectedRows)
                        {
                            int localApplicationID = (int)selectedRow.Cells["LocalApplicationID"].Value;
                            selectedApplicationIDS.Add(localApplicationID);
                        }

                        if (deleteLocalApplicaitons(selectedApplicationIDS))
                        {
                            _resetForm();
                            MessageBox.Show("Application deleted successfully.","Succeed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Application delete process was terminate.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
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
        private bool deleteLocalApplicaitons(List<int> selectedApplicationIDS)
        {
            return clsApplicationService.deleteLocalApplication(selectedApplicationIDS);
        }
        private void _resetContextMenuStripsSettings()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = false;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            sechduToolStripMenuItem.Enabled = false;
            visionTestToolStripMenuItem.Enabled = false;
            writtenTestToolStripMenuItem.Enabled = false;
            practicalTestToolStripMenuItem.Enabled = false;

            issueDrivingLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
        }
        private void cmsLocalDrivingLicense_Opened(object sender, EventArgs e)
        {
            _resetContextMenuStripsSettings();
    
            if (dgvApplications.SelectedRows.Count > 0)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationID))
                    {

                        clsLocalApplicationDTO localApplicationDTO = clsApplicationService.getLocalApplicationInfoByLocalAppID(localApplicationID);

                        if (Equals(localApplicationDTO.baseApplicationDTO.enApplicationStatus, enStatus.New))
                        {
                            showApplicationDetailsToolStripMenuItem.Enabled = true;
                            cancelApplicationToolStripMenuItem.Enabled = true;
                            sechduToolStripMenuItem.Enabled = true;
                            editApplicationToolStripMenuItem.Enabled = true;
                            deleteApplicationToolStripMenuItem.Enabled = true;
                            if (int.TryParse(selectedRow.Cells["Passed Tests"].Value.ToString(), out int passedTests))//based on passed tests so far 
                            {
                                if (passedTests == 0)
                                {
                                    visionTestToolStripMenuItem.Enabled = true;
                                }

                                else if (passedTests == 1)//open written 
                                {
                                    writtenTestToolStripMenuItem.Enabled = true;
                                }


                                else if (passedTests == 2)//open practical
                                {
                                    practicalTestToolStripMenuItem.Enabled = true;
                                }

                                else if (passedTests == 3)
                                {
                                    issueDrivingLicenseToolStripMenuItem.Enabled = true;

                                }
                            }


                        }

                        else if (Equals(localApplicationDTO.baseApplicationDTO.enApplicationStatus, enStatus.completed))
                        {
                            showApplicationDetailsToolStripMenuItem.Enabled= true;
                            showLicenseToolStripMenuItem.Enabled = true;
                            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                        }
              
                        else if (Equals(localApplicationDTO.baseApplicationDTO.enApplicationStatus, enStatus.cancelled))
                        {
                            //Keep everything  closed.
                        }
                   
                        
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
        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationId))
                    {
                        frmTestAppointments visionForm = new frmTestAppointments(localApplicationId,
                            enTestType.Written);
                        visionForm.ShowDialog();
                        _resetForm();
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
        private void practicalTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationId))
                    {
                        frmTestAppointments visionForm = new frmTestAppointments(localApplicationId,
                            enTestType.Practical);
                        visionForm.ShowDialog();
                        _resetForm();
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
        private void _triggerEventForIssueLicense(object sender, EventArgs e)
        {
             if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationId))
                    {
                        //License issue status must be completed . 
                       if( _ApplicationStatusCompleted(localApplicationId))
                        _resetForm();
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
        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationId))
                    {
                        frmIssueDrivingLicenseForFirstTime form = new frmIssueDrivingLicenseForFirstTime(localApplicationId);
                        form.evNewLicenseWasCreated += _triggerEventForIssueLicense;
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

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationId))
                    {
                    
                        frmLicenseInfo form = new frmLicenseInfo(clsLicenseService.FindAppInfo(
                               clsApplicationService.getLocalApplicationInfoByLocalAppID(localApplicationId).baseApplicationDTO.applicationID).LicenseID);

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

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 1)
            {
                int rowIndex = dgvApplications.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvApplications.Rows[rowIndex];
                try
                {
                    if (int.TryParse(selectedRow.Cells["LocalApplicationID"].Value.ToString(), out int localApplicationId))
                    {
                        frmLicenseHistory form = new frmLicenseHistory();
                        form.LoadDataInfo(clsApplicationService.getLocalApplicationInfoByLocalAppID(
                           localApplicationId).baseApplicationDTO.personID);
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
