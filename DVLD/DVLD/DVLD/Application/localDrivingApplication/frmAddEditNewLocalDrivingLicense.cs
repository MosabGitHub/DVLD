using AppplicationSerivceLib;
using DVLD.ctrls;
using GlobalSettings;
using LicensesServiceLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.DTOs;
using clsUsers;
using System.Security;
using ApplicationServiceLib;
namespace DVLD.Application
{
    public partial class frmAddEditNewLocalDrivingLicense : Form
    {
        private clsUserService _clsUserService = new clsUserService();
 
        public enum enFormMode
        {
            AddNew,
            Update
        }

        public delegate void eventHandlerApplcation(object sender, EventArgs e);

        public eventHandlerApplcation evLocalApplicationWasAdded;

        private clsLocalApplicationDTO _localApplicationDTO = null;
        private enFormMode _mode;
        int _personID = -1;
        private void _settings(int localApplicationID = -1)
        {

            if (_mode == enFormMode.AddNew)
            {
                addEditFilterCtrl.evPersonIsFounded += enableNextBtnAndAssignPersonID;
                btnSave.Enabled = btnNext.Enabled = false;
                lbMainHeader.Text = "New Local Driving License Application";
            }
            else if (_mode == enFormMode.Update)
            {
                lbMainHeader.Text = "Update Local Driving License Application";
                addEditFilterCtrl.Enabled = false;
                btnSave.Enabled = btnNext.Enabled = true;
            }

        }
        private void _fillPersonDetails()
        {
            if (_mode == enFormMode.Update)
            {
                addEditFilterCtrl.loadPersonInfo(_localApplicationDTO.baseApplicationDTO.personID);
            }
        }
        private bool _assignLocalApplicationInfo(int localApplicationID)
        {

            _localApplicationDTO = clsApplicationService.getLocalApplicationInfoByLocalAppID(localApplicationID);
            if (_localApplicationDTO != null)
                return true;

            else return false;
        }
        public frmAddEditNewLocalDrivingLicense()
        {
            _mode = enFormMode.AddNew;
            InitializeComponent();
            _settings();
        }
        public frmAddEditNewLocalDrivingLicense(int localApplicationID)
        {
            _mode = enFormMode.Update;
            InitializeComponent();
            if (!_assignLocalApplicationInfo(localApplicationID))
                throw new Exception("Couldn't access to local application info in order to edit/updates it, (Add/edit form)");
            _settings(localApplicationID);
            _fillDataLabels();

        }
        private void enableNextBtnAndAssignPersonID(object sender, clsCustomEventArgs e)
        {
            this._personID = e.PersonID;
            if (_personID != -1)
            {
                btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("Couldn't find such a person", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _fillApplicationID()
        {
            if (_mode == enFormMode.Update && _localApplicationDTO != null)
                lbApplicationID.Text = _localApplicationDTO.localApplicationID.ToString();
        }
        //fill the tap application info   
        private void _fillDate()
        {
            DateTime date = DateTime.Now;
            if (_mode == enFormMode.AddNew)
            {
                lbApplicationDate.Text = date.ToString();
            }

            else if (_mode == enFormMode.Update)
            {
                lbApplicationDate.Text = _localApplicationDTO.baseApplicationDTO.applicationDate.ToString();
            }

        }
        private void _fillLicenseClasses()
        {
            if (_mode == enFormMode.AddNew)
            {
                DataTable dataTableLicenseClassesInfo = clsLoadRandomDataLibrary.AccessData.GetAllLicenseClassesIDAndTitle();
                cbLicenseClasses.DataSource = dataTableLicenseClassesInfo;
                cbLicenseClasses.DisplayMember = "Title";
                cbLicenseClasses.ValueMember = "ClassID";
                cbLicenseClasses.SelectedItem = 1;
            }

            else if (_mode == enFormMode.Update)
            {
                DataTable dataTableLicenseClassesInfo = clsLoadRandomDataLibrary.AccessData.GetAllLicenseClassesIDAndTitle();
                cbLicenseClasses.DisplayMember = "Title";
                cbLicenseClasses.ValueMember = "ClassID";
                cbLicenseClasses.DataSource = dataTableLicenseClassesInfo;
                cbLicenseClasses.SelectedValue = _localApplicationDTO.licenseClassID;

            }

        }
        private void _fillFees()
        {
            lbApplicationFees.Text = _getFees().ToString() + "$";
        }
        private double _getFees() 
        {
            enApplicationType appType = 0;
            if (_mode == enFormMode.AddNew || _mode == enFormMode.Update)
            {
                appType = enApplicationType.NewLocalDrivingLicenseService;
            }
            return clsApplicationTypeService.GetApplicationTypeByID((int)appType).Fees;
        }
        private void _fillCreatedUserBy()
        {
            if (_mode == enFormMode.AddNew)
            {
                lbCreatedBy.Text = ClsAdmin.userName.ToLower();
            }
            else if (_mode == enFormMode.Update)
            {
                lbCreatedBy.Text = _clsUserService.Find(_localApplicationDTO.baseApplicationDTO.UserCreatedByID).userName.ToString();

            }
        }
        private void _fillDataLabels()
        {
            _fillDate();
            _fillLicenseClasses();
            _fillFees();
            _fillCreatedUserBy();
            _fillApplicationID();
            _fillPersonDetails();

        }
        private void _moveToApplicationTabCtrl()
        {
            tbCtrl.SelectedTab = tpApplicationInfo;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            _moveToApplicationTabCtrl();
                _fillDataLabels();
        }
        private void _MyTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Check if the user is trying to select the restricted tab

            if (e.TabPage == tpApplicationInfo) // 'tpLoginInfo' is the TabPage you want to restrict
            {
                // Check your specific condition

                if (btnNext.Enabled)
                {

                    tbCtrl.SelectedTab = tpApplicationInfo;

                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("You cannot access this tab , Person information is couldn't be found in the system", "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }      
        private void _raiseEventInWinForm()
        {
            evLocalApplicationWasAdded?.Invoke(this, EventArgs.Empty);
        }   
        private clsLocalApplicationDTO _createLocalApplication()
        {
            enStatus ApplicationStatus =enStatus.hold;

            //Base-Info.

            DateTime lastStatusDate = DateTime.Now;

            DateTime date = Convert.ToDateTime(lbApplicationDate.Text);

            enApplicationType applicationType =enApplicationType.NewLocalDrivingLicenseService;//Local

            int userId = clsUserService.Find(ClsAdmin.userName.ToLower()).UserID;// What if I didn't approach to a user inform with an error and terminate the process . 

            double fees = _getFees();

            //Local-Info
            int licenseClassID = (int)cbLicenseClasses.SelectedValue;
                

              clsApplicationDTO baseApplicationDTO = new clsApplicationDTO(date,lastStatusDate,
                applicationType, ApplicationStatus,_personID,userId,fees);

            if (_mode == enFormMode.AddNew)
            {
                ApplicationStatus = enStatus.New;
                baseApplicationDTO.enApplicationStatus=ApplicationStatus;
                return new clsLocalApplicationDTO(-1, baseApplicationDTO, licenseClassID);
            }

            else if (_mode == enFormMode.Update)
            {
                ApplicationStatus = _localApplicationDTO.baseApplicationDTO.enApplicationStatus;
                licenseClassID = (int)cbLicenseClasses.SelectedValue;
                return new clsLocalApplicationDTO(_localApplicationDTO.localApplicationID, _localApplicationDTO.baseApplicationDTO, licenseClassID);

                
            }

            return null;
          
            
        }
        private void _filpCurrentFormMode()
        {
            if (_mode == enFormMode.AddNew)
            {
                _mode = enFormMode.Update;
            }
            else 
                return;
        }

        private bool _doesUserHaveSuchLicenseWithClassID()
        {
            try {
                return clsLicenseService.IsDriverOwnSameClassLicense(_personID,(int)cbLicenseClasses.SelectedValue);
                }
        
            catch { return false; }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (enFormMode.AddNew == _mode)
            {
                //Before you create application check if user has a class like this one 
                if (_doesUserHaveSuchLicenseWithClassID())
                {
                    MessageBox.Show("User already have a license with such a class type", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

              
                _localApplicationDTO = _createLocalApplication();

                if (_localApplicationDTO != null)
                {

                    try
                    {

                        if (clsApplicationService.SaveLocalApplicationInfo(_localApplicationDTO))
                        //success
                        {
                            _filpCurrentFormMode();
                            _settings();
                            _fillApplicationID();
                            _raiseEventInWinForm();
                            MessageBox.Show($"A new Application was added successfully with ID: \' {_localApplicationDTO.localApplicationID}\'"
                                , "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } 
                        else
                        {
                            MessageBox.Show("Failed to add a new application to the system.", "Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    }

                }
            }

            else if (enFormMode.Update == _mode)
            {
                _localApplicationDTO = _createLocalApplication();

                if (_localApplicationDTO != null)
                {
                    try
                    {

                        if (clsApplicationService.SaveLocalApplicationInfo(_localApplicationDTO))
                        //success
                        {
                            _raiseEventInWinForm();
                            _fillLicenseClasses();
                            MessageBox.Show($"The Application ID: \'{_localApplicationDTO.localApplicationID}\' was added updated successfully."
                                , "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message, "Failed Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbCtrl_Selected(object sender, TabControlEventArgs e)
        {
            if (enFormMode.AddNew == _mode)
            {
                if (tbCtrl.SelectedTab == tpApplicationInfo)
                {
                    btnSave.Enabled = true;
                }
                else if (tbCtrl.SelectedTab == tpPersonalInfo)
                {
                    btnSave.Enabled = false;
                }
            }

        }

        private void addEditFilterCtrl_Load(object sender, EventArgs e)
        {

        }
    }
}
