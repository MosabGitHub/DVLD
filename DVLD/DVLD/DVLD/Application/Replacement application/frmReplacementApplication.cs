using AppplicationSerivceLib;
using DetainLicenseServiceLib;
using DVLD.ctrls;
using DVLD.DTOs;
using DVLD.DTOs.LicesnseDTO;
using DVLD.Licenses;
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
using static DVLD.addEditNewUserFrm;

namespace DVLD.Application.Replacement_application
{
    public partial class frmReplacementApplication : Form
    {
        private clsLicenseDTO _DamagedLostLicenseDTO=null;

        private int _newReplacedLicenseID = -1;
        private GlobalSettings.enMode _enMode;
        public frmReplacementApplication()
        {
            InitializeComponent();

            _SubscribeToEvent();
        }
        private void _changeMode()
        {
            if (_enMode == GlobalSettings.enMode.AddNew)
                _enMode = GlobalSettings.enMode.update;

            else
            {
                _enMode = GlobalSettings.enMode.AddNew;
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


            if (_enMode == GlobalSettings.enMode.update)
            {
                _deactivateFilterSearchCtrl();
                _deactivateIssueButton();
                _activeShowLicenseInfoButton();
            }


            //make filter ctrl to be able to accept enter button 
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(MyForm_KeyDown);

        }
        private void MyForm_KeyDown(object sender, EventArgs e)
        {

            filterLicenseCtrl1.PerformSearchButton(sender,e);
        }
        private void _ResetForm()
        {
            filterLicenseCtrl1.reset();
            driverLicenseInfoCtrl1.Reset();
        }
        private void _SubscribeToEvent()
        {
            filterLicenseCtrl1.evSearchLicense += _SearchControl_licenseWasFound;
        }
        private void _AssignDamagedLostLicense(clsLicenseDTO damagedLostLicense)
        {
            try
            {
                this._DamagedLostLicenseDTO = damagedLostLicense;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsLicenseActive()
        {
            if(_DamagedLostLicenseDTO!=null)
            {
                return _DamagedLostLicenseDTO.LicenseSpec.IsActive;
            }
            
            return false;
        }
        private void _fillNewLicenseAndApplication(int newReplacementApplicationID, int newReplacedLicenseID)
        {
            applicationInfoForLicenseReplacementCtrl1.
                FillNewApplicationAndReplacedLicenseIDs(newReplacementApplicationID, newReplacedLicenseID);
        }
        private enApplicationType GetReplacementApplicationType()
        {
            if (rbtnDamagedLicense.Checked)
            {
                return enApplicationType.ReplacementForDamagedDrivingLicense;
            }
            
            else if (rbtnLostLicense.Checked)
            {
                return enApplicationType.ReplacementLostDrivingLicense;
            }

            else
            {
                MessageBox.Show("Replacement reason didn't set , system will be by default assume this is a lost and not damage application."
                    , "Wake up", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                return enApplicationType.ReplacementForDamagedDrivingLicense;
            }

        }
        private void _SendLicenseObjectToLicenseInfoCtrl()
        {
            driverLicenseInfoCtrl1.LoadDriverLicenseInfoCtrl(_DamagedLostLicenseDTO);
        }
        private void _OrderApplicationCtrlToFillCurrentAvailableData()
        {
            applicationInfoForLicenseReplacementCtrl1.FillCurrentAvailableData(_DamagedLostLicenseDTO, GetReplacementApplicationType());
        }
        private void _deactivateOldLicense()
        {

            clsLicenseService.DeactivateLicense(_DamagedLostLicenseDTO.LicenseID);
        }
        private bool _isLicenseDetainedInSystem(int licenseID)
        {
            return clsDetainLicenseService.IsLicenseDetain(licenseID);
        }
        private void _SearchControl_licenseWasFound(object sender, clsCustomEventArgs e)
        {
            if (e == null)
            {
                _ResetForm();
            }
   
            else if(e.LicenseDTO!=null)
            {

               _AssignDamagedLostLicense(e.LicenseDTO);
              
                if (!IsLicenseActive())
                {
                    MessageBox.Show("This license ain't active , you need to choose an active license."
                        ,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _deactivateIssueButton();
                }
      
                else if (_isLicenseDetainedInSystem(e.LicenseDTO.LicenseID))
                {

                    MessageBox.Show($"This license is detained In the system , it expires at {e.LicenseDTO.LicenseSpec.ExpireDate}",
                      "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    _deactivateIssueButton();

                }

                //IsLicenseDetained();
                _SendLicenseObjectToLicenseInfoCtrl();
                _OrderApplicationCtrlToFillCurrentAvailableData();
                _activeShowLicenseHistoryButton();

            }


        }
        private void rbtnDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            applicationInfoForLicenseReplacementCtrl1.ReFillApplicationFees(enApplicationType.ReplacementForDamagedDrivingLicense);

        }
        private void rbtnLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            applicationInfoForLicenseReplacementCtrl1.ReFillApplicationFees(enApplicationType.ReplacementLostDrivingLicense);

        }
        private int _getPersonID()
        {
            try
            {
                if (_DamagedLostLicenseDTO != null)
                {
                    return clsLicenseService.getPersonIDByLicenseID(_DamagedLostLicenseDTO.LicenseID);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get person ID :\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1;
        }
        private DateTime _getExpirationDate()
        {
            DateTime date = DateTime.Now;
            return date.AddYears(10);
        }
        private clsApplicationDTO _CreateNewReplacementApplication()

        {
            if (_DamagedLostLicenseDTO != null)
            {
                try
                {
                    DateTime applicationDate = DateTime.Now;
                    DateTime issueDateTime = DateTime.Now;
                    enApplicationType applicationType = GetReplacementApplicationType();//Lost Or damaged
                    enStatus applicationStatus = enStatus.New;
                    int personID = _getPersonID();
                    return new clsApplicationDTO(applicationDate, issueDateTime, applicationType, applicationStatus, personID,
                        _DamagedLostLicenseDTO.UsercreatedByID, Convert.ToDouble(clsApplicationTypeRepository.GetApplicationFeesFromDataBaseByType(applicationType)));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something we wrong while we creating new international application:(Exception)\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
            else
            {
                MessageBox.Show("Old Liecnse data wasan't loaded properly to create new replacement application:",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

              
            }
            return null;

        }
        private enIssueReason _GetIssueReason()
        {
            if (rbtnDamagedLicense.Checked)
            {
                return enIssueReason.ReplaceForDamage;
            }

            
                return enIssueReason.ReplaceForLost;


        }
        private clsLicenseDTO _createLicense(int newReplacementApplicationID)
        {

            try
            {

                DateTime issueDateTime = DateTime.Now;
                DateTime ExpirationDate = _getExpirationDate();
                bool isActive = true;//Brand - New

                clsLicenseSpec DamageLostLicenseSpec = new
                    clsLicenseSpec( issueDateTime, ExpirationDate,"",isActive,_DamagedLostLicenseDTO.LicenseSpec.PaidFees,_GetIssueReason());

                return new clsLicenseDTO(newReplacementApplicationID, _DamagedLostLicenseDTO.LicenseClassID,
                    _DamagedLostLicenseDTO.DriverID, _DamagedLostLicenseDTO.UsercreatedByID, DamageLostLicenseSpec);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Something we wrong while we creating new replaced License:(Exception)\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;

        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
    
            System.Media.SystemSounds.Hand.Play();
    
            var confirm = MessageBox.Show("Are you sure you want to replace this license , you can't back after this step.", "Confirm Delete", MessageBoxButtons.YesNo);
   
            if (confirm == DialogResult.Yes)
            {
                if (_enMode == GlobalSettings.enMode.AddNew)
            {
                if (_DamagedLostLicenseDTO == null)
                {
                    MessageBox.Show("you can't issue an replaced license without the old license be filled properly into the system.",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    int newReplacementApplicationID , newReplacedLicenseID ;
                    clsLicenseDTO newReplacedLicenseDTO = null;

                    try
                    {
          
                            clsApplicationDTO newReplacementApplication = _CreateNewReplacementApplication();
     

                            if (newReplacementApplication != null)
                        {
         
                                newReplacementApplicationID = clsApplicationService.SaveApplicationInfo(newReplacementApplication);
        
                                if (newReplacementApplicationID != -1)
                            {
                                try
                                {
                                    newReplacedLicenseDTO = _createLicense(newReplacementApplicationID);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Something we wrong while we creating new international application :(Exception)\n" + ex.Message,
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
       
                                    if (newReplacedLicenseDTO != null)
                                {
                                    try
                                    {
                                            _deactivateOldLicense();
                                            newReplacedLicenseID = clsLicenseService.Save(newReplacedLicenseDTO);

                                        if (newReplacedLicenseID != -1)//Success
                                        {
                                            MessageBox.Show($"You successfully issued a new \' replaced \' license with ID : " +
                                                $"\'{newReplacedLicenseID}\'.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            _changeMode();
                                            _settings();
                                            _fillNewLicenseAndApplication(newReplacementApplicationID, newReplacedLicenseID);
                                            _newReplacedLicenseID= newReplacedLicenseID;
                                             _activeShowLicenseInfoButton();

                                            }
                                            else
                                        {//In case you filled to add the new replaced license to the system re active it .
                                            clsApplicationService.DeleteBaseApplicationInfo(newReplacementApplicationID);
                                            clsLicenseService.ActivateLicense(_DamagedLostLicenseDTO.LicenseID);
                                           
                                                MessageBox.Show("Something we wrong while we creating new replaced license.",
                                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsApplicationService.DeleteBaseApplicationInfo(newReplacementApplicationID);

                                        MessageBox.Show("Something we wrong while we creating new replaced license:(Exception)\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }

                                else
                                {
                                    MessageBox.Show("Something went wrong in creating a  new Replaced license properly.",
                                         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }

                            else
                            {
                                MessageBox.Show("Couldn't mange to save a new replacement application in database .",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else
                        {
                            MessageBox.Show("Couldn't mange to create a new replacement application .",
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
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_newReplacedLicenseID != -1)
            {

                frmLicenseInfo licenseInfo = new frmLicenseInfo(_newReplacedLicenseID);
                licenseInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("You can't show a license with -1 ID :","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           frmLicenseHistory licenseHistory = new frmLicenseHistory();
            licenseHistory.LoadDataInfo(_getPersonID());
            licenseHistory.ShowDialog();

        }
  
    }

}
