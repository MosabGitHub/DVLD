using AppplicationSerivceLib;
using DVLD.ctrls;
using DVLD.DTOs;
using DVLD.DTOs.LicesnseDTO;
using GlobalSettings;
using LicensesServiceLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmIssueInternationalDrivingLicense : Form
    {
       
        private enMode _enMode;
    
        private clsLicenseDTO _LocalLicenseDTO = null;
        public frmIssueInternationalDrivingLicense()
        {
            InitializeComponent();
            _subscribeToLicenseFilterEvent();
            _enMode = enMode.AddNew;
            _settings();


        }

        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                // Check if the custom control has focus or is a parent of the focused control
                if (filterLicenseCtrl1.ContainsFocus)
                {
                    filterLicenseCtrl1.PerformSearchButton(sender, e);
                    e.Handled = true; // Mark the event as handled
                }
            }
        }
        private void _resetForm()
        {
            filterLicenseCtrl1.reset();
            driverLicenseInfoCtrl1.Reset();
            internationalLocalApplicationInfoCTRL1.Reset();
            _LocalLicenseDTO = null;
            filterLicenseCtrl1.reset();

        }
        private void _changeMode()
        {
            if (_enMode == enMode.AddNew)
                _enMode = enMode.update;

            else
            {
                _enMode = enMode.AddNew;
            }
        }
        private void _activeShowLicenseHistoryButton()
        {
            lbShowLicenseHistory.Enabled = true;
        }
        private void _activeShowLicenseInfoButton()
        {
            lbShowLicenseInfo.Enabled = true;
        }

        private void _deactivateFilterSearchCtrl()
        {
            filterLicenseCtrl1.Enabled = false;

        }
        private void _deactivateIssueButton()
        {
            btnIssue.Enabled = false;

        }
        private void _settings()
        {
        

            if (_enMode == enMode.update)
            {
                _deactivateFilterSearchCtrl();
                _deactivateIssueButton();
                _activeShowLicenseInfoButton();
            }


            //make filter ctrl to be able to accept enter button 
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(MyForm_KeyDown);

        }
        private void _subscribeToLicenseFilterEvent()
        {
            filterLicenseCtrl1.evSearchLicense += _licenseFilterSearch_licenseFound;
        }
        private void _showNewLicenseAndApplication(int newInternationalApplicationID,int newInternationalLicenseID)
        {
            internationalLocalApplicationInfoCTRL1.
                FillNewApplicationAndLicenseIDs(newInternationalApplicationID,newInternationalLicenseID);
        }
        private void _assignLicenseObject(clsLicenseDTO localLicenseDTO)
        {
            _LocalLicenseDTO = localLicenseDTO;
        }
        private void _sendLocalLicenseInstanceToLicenseInfo()
        {
            driverLicenseInfoCtrl1.LoadDriverLicenseInfoCtrl(_LocalLicenseDTO);
        }
        private bool _isLicenseClassIsValid()
        {
            if (_LocalLicenseDTO.LicenseClassID != clsLicenseClassService.Find(enLicenseClass.StandardDrivingLicense).classID)//Must be standard license class
            {
                MessageBox.Show("This License ain't Standard Driving License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
                return true;
        }
        private bool isLicenseActive()
        {
            if (!_LocalLicenseDTO.LicenseSpec.IsActive)
            {
                MessageBox.Show("This License ain't active anymore.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false ;
            }

            else 
                return true; 

        }
        private void _licenseFilterSearch_licenseFound(object sender, clsCustomEventArgs e)
        {
            if (e == null)
            {
                _resetForm();
            }
            else
            {
                _assignLicenseObject(e.LicenseDTO);
                _sendLocalLicenseInstanceToLicenseInfo();
                _licenseObjectSendToApplicationCtrl();
                _activeShowLicenseHistoryButton();

                if (!isLicenseActive()|| !_isLicenseClassIsValid())
                {
                    _resetForm();

                }
             
            }
        }
        private void _licenseObjectSendToApplicationCtrl()
        {
            internationalLocalApplicationInfoCTRL1.FillCurrentAvailableData(_LocalLicenseDTO);
        }
        private int _getPersonID()
        {
            try
            {
                if (_LocalLicenseDTO != null)
                {
                    return clsLicenseService.getPersonIDByLicenseID(_LocalLicenseDTO.LicenseID);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show( "Failed to get person ID :\n"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

            return -1;
        }
        private DateTime _getExpirationDate()
        {
            DateTime date = DateTime.Now;
            return date.AddYears(1);
        }
        private clsApplicationDTO _createApplication()
        {
            if (_LocalLicenseDTO != null)
            {
                try
                {
                    DateTime applicationDate = DateTime.Now;
                    DateTime issueDateTime = DateTime.Now;
                    enApplicationType applicationType  = enApplicationType.NewInternationalLicense;//International 
                    enStatus applicationStatus = enStatus.New;
                    int personID = _getPersonID();
                    return new clsApplicationDTO(applicationDate, issueDateTime, applicationType, applicationStatus, personID,
                        _LocalLicenseDTO.UsercreatedByID, Convert.ToDouble(clsApplicationTypeRepository.GetApplicationFeesFromDataBaseByType(applicationType)));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something we wrong while we creating new international application:(Exception)\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;

        }
        private clsInternationalLicenseDTO _createLicense(int newInternationalApplicationID)
        {

            try {
                DateTime issueDateTime = DateTime.Now;
                DateTime ExpirationDate = _getExpirationDate();
                bool isActive=true;//Brand - New
               
                clsInternationalLicenseSpec internationalLicenseSpec = new
                    clsInternationalLicenseSpec(_LocalLicenseDTO.UsercreatedByID, issueDateTime, ExpirationDate, isActive);

                return new clsInternationalLicenseDTO(newInternationalApplicationID,_LocalLicenseDTO.DriverID, 
                    _LocalLicenseDTO.LicenseID,internationalLicenseSpec);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Something we wrong while we creating new International License:(Exception)\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;

        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(_enMode==enMode.AddNew)
            {
                if (_LocalLicenseDTO == null)
                {
                    MessageBox.Show("you can't issue an international license without insert the id of local license",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int newInternationalApplicationID = -1, newInternationalLicenseID = -1;
                    clsInternationalLicenseDTO newInternationalLicenseInfo = null;

                    try
                    {
                        clsApplicationDTO newApplication = _createApplication();
                        if (newApplication != null)
                        {

                            newInternationalApplicationID = clsApplicationService.SaveInternationalLocalApplicationInfo(newApplication);

                            if (newInternationalApplicationID != -1)
                            {
                                try
                                {
                                    newInternationalLicenseInfo = _createLicense(newInternationalApplicationID);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Something we wrong while we creating new international application :(Exception)\n" + ex.Message,
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                if (newInternationalLicenseInfo != null)
                                {
                                    try
                                    {
                                        newInternationalLicenseID = clsInternationalLicenseService.Save(newInternationalLicenseInfo);

                                        if (newInternationalLicenseID != -1)//Success
                                        {
                                            MessageBox.Show($"You successfully issued a new international license with ID : " +
                                                $"\'{newInternationalLicenseID}\'.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            _changeMode();
                                            _settings();
                                            _showNewLicenseAndApplication(newInternationalApplicationID, newInternationalLicenseID);
                                        }
                                        else
                                        {
                                            clsApplicationService.DeleteBaseApplicationInfo(newInternationalApplicationID);

                                            MessageBox.Show("Something we wrong while we creating new international license:(Exception)\n" ,
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsApplicationService.DeleteBaseApplicationInfo(newInternationalApplicationID);

                                        MessageBox.Show("Something we wrong while we creating new international license:(Exception)\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }

                                else
                                {
                                    MessageBox.Show("Something went wrong in creating a new a new international license properly.",
                                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }

                            else
                            {
                                MessageBox.Show("Couldn't mange to save a new international application in database .",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                        else
                        {
                            MessageBox.Show("Couldn't mange to create a new international application .",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Something we wrong while we creating new international application and license:(Exception)\n" + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory();
            frmLicenseHistory.LoadDataInfo(_getPersonID());
            frmLicenseHistory.ShowDialog();
        }
        private void lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(_LocalLicenseDTO.LicenseID);
            frmLicenseInfo.ShowDialog();
        }

    }
  
   

}

