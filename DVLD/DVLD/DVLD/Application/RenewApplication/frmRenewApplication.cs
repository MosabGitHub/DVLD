using AppplicationSerivceLib;
using clsUsers;
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

namespace DVLD.Application.RenewApplication
{
    public partial class frmRenewApplication : Form
    {
        private GlobalSettings.enMode _enMode;

        private clsLicenseDTO _oldLocalLicenseDTO;
        private clsLicenseDTO _renewLocalLicenseDTO;
        public frmRenewApplication()
        {
            InitializeComponent();
            _subscribeToLicenseFilterEvent();
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
        private void _deactivateFilterSearchCtrl()
        {
            filterLicenseCtrl1.Enabled = false;

        }
        private void _deactivateRenewButton()
        {
            btnRenew.Enabled = false;

        }
        private void _activeShowLicenseInfoButton()
        {
            lbShowLicenseInfo.Enabled = true;
        }
        private void _settings()
        {
            
            if (_enMode == GlobalSettings.enMode.update)
            {
                _deactivateFilterSearchCtrl();
                _deactivateRenewButton();
                _activeShowLicenseInfoButton();
            }


            //make filter ctrl to be able to accept enter button 
            //this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(MyForm_KeyDown);

        }
        private void _resetForm()
        {
            filterLicenseCtrl1.reset();
            driverLicenseInfoCtrl1.Reset();
            reNewApplicationInfoCtrl1.Reset();
            _oldLocalLicenseDTO = null;
            btnRenew.Enabled = false;
            lbShowLicenseHistory.Enabled = false;
            lbShowLicenseInfo.Enabled=false;
        }   
        private void _subscribeToLicenseFilterEvent()
        {
            filterLicenseCtrl1.evSearchLicense += _licenseFilterSearch_oldLicenseFound;
        }
        private void _assignLicenseObject(clsCustomEventArgs e)
        {

            if (e.LicenseDTO != null)
            {
                _oldLocalLicenseDTO=e.LicenseDTO;
            }
           
            else
            {
                throw new ArgumentException("License neither international or local manged to be assign.");
            }
        }
        private bool isExpirationDateValid(DateTime LicenseExpireDate)
        {
            if(LicenseExpireDate == null)
                return false;
            else  {
                return LicenseExpireDate < DateTime.Now;
            }
            
        }
        private void _activateRenewButton()
        {
            btnRenew.Enabled = true;

        }
        private void _activateShowHistoryButton()
        {
            lbShowLicenseHistory.Enabled = true;

        }
        private void _activateShowLicenseInfoButton()
        {
            lbShowLicenseInfo.Enabled = true;
        }
        private void _licenseFilterSearch_oldLicenseFound(object sender, clsCustomEventArgs e)
        {
            
            if (e == null)
            {
                _resetForm();
            }
         
            else 
            {
                _assignLicenseObject(e);
                _sendLicenseInstanceToLicenseInfo();
                _licenseObjectSendToRenewApplicationCtrl();
                _activeShowLicenseHistoryButton();
                _activateRenewButton();

          
                if (!isExpirationDateValid(e.LicenseDTO.LicenseSpec.ExpireDate))
                {
                MessageBox.Show($"This license ain't expired yet , it expires at {e.LicenseDTO.LicenseSpec.ExpireDate}",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                _activateShowHistoryButton();
                _activateShowLicenseInfoButton();
                _deactivateRenewButton();
                 
                }
      

            }


        }
        private void _sendLicenseInstanceToLicenseInfo()
        {
                driverLicenseInfoCtrl1.LoadDriverLicenseInfoCtrl(_oldLocalLicenseDTO);
        }
        private void _activeShowLicenseHistoryButton()
        {
            lbShowLicenseHistory.Enabled = true;
        }
        private void _licenseObjectSendToRenewApplicationCtrl()
        {
            reNewApplicationInfoCtrl1.FillCurrentAvailableData(_oldLocalLicenseDTO);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int _getPersonID()
        {
            try
            {
                if (_oldLocalLicenseDTO != null)
                {
                    return clsLicenseService.getPersonIDByLicenseID(_oldLocalLicenseDTO.LicenseID);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get person ID :\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1;
        }
        private void lbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory form = new frmLicenseHistory();
            form.LoadDataInfo(_getPersonID());
            form.ShowDialog();
        }
        private void lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(_renewLocalLicenseDTO.LicenseID);
            frmLicenseInfo.ShowDialog();
        }
        private DateTime _getExpirationDate()
        {
            DateTime date = DateTime.Now;
            return date.AddYears(10);
        }
        private void _showNewLicenseAndApplication(int renewApplicationId, int renewLicenseID)
        {
            reNewApplicationInfoCtrl1.
                FillNewApplicationAndLicenseIDs(renewApplicationId, renewLicenseID);
        }

        private clsApplicationDTO _createApplication()
        {
            if (_oldLocalLicenseDTO != null)
            {
                try
                {
                    DateTime applicationDate = DateTime.Now;
                    DateTime issueDateTime = DateTime.Now;
                    enApplicationType applicationType= enApplicationType.RenewDrivingLicenseService;//International 
                    enStatus applicationStatus = enStatus.New;
                    int personID = _getPersonID();
                    return new clsApplicationDTO(applicationDate, issueDateTime, applicationType, applicationStatus, personID,
                        _oldLocalLicenseDTO.UsercreatedByID, 
                        Convert.ToDouble(clsApplicationTypeRepository.GetApplicationFeesFromDataBaseByType(enApplicationType.RenewDrivingLicenseService)));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something we wrong while we creating new international application:(Exception)\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;

        }
        private clsLicenseDTO _createLicense(int newRenewApplicationID)
        {

            try
            {

                DateTime issueDateTime = DateTime.Now;
                DateTime ExpirationDate = _getExpirationDate();
                bool isActive = true;//Brand - New
                enIssueReason issueReason = enIssueReason.renewLicense;
                int userCreatedByID=clsUserService.Find(ClsAdmin.userName).UserID;
                
                clsLicenseSpec LicenseSpec = new clsLicenseSpec(issueDateTime, ExpirationDate, reNewApplicationInfoCtrl1.Notes(),isActive,
                    reNewApplicationInfoCtrl1.LicenseFees(),issueReason);

                return new clsLicenseDTO(newRenewApplicationID, 
                    _oldLocalLicenseDTO.LicenseClassID, _oldLocalLicenseDTO.DriverID , userCreatedByID, LicenseSpec);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Something we wrong while we creating new International License:(Exception)\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;

        }
        private void _deactivateOldLicense()
        {
            try 
            {
                if(clsLicenseService.DeactivateLicense(_oldLocalLicenseDTO.LicenseID))
                    MessageBox.Show("Old License was deactivate successfully.", "Succeed",MessageBoxButtons.OK,MessageBoxIcon.Information); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("error in process of deactivate old license"+ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        private void _assignRenewLocalLicense(int renewLicenseID)
        {
            _renewLocalLicenseDTO=clsLicenseService.Find(renewLicenseID);
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Hand.Play();
            var confirm = MessageBox.Show("Are you sure you want to make renew application", "Confirm renew application", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (_enMode == GlobalSettings.enMode.AddNew)
                {
                    if (_oldLocalLicenseDTO == null)
                    {
                        MessageBox.Show("you can't renew an old license without insert the id of local license",
                            "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        int renewApplicationID = -1, renewLicenseID = -1;
                        clsLicenseDTO renewLicenseDTO = null;

                        try
                        {
                            clsApplicationDTO newApplication = _createApplication();
                            if (newApplication != null)
                            {

                                renewApplicationID = clsApplicationService.SaveInternationalLocalApplicationInfo(newApplication);

                                if (renewApplicationID != -1)
                                {
                                    try
                                    {
                                        renewLicenseDTO = _createLicense(renewApplicationID);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Something we wrong while we creating new international application :(Exception)\n" + ex.Message,
                                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    if (renewLicenseDTO != null)
                                    {
                                        try
                                        {
                                            _deactivateOldLicense();
                                            renewLicenseID = clsLicenseService.Save(renewLicenseDTO);

                                            if (renewLicenseID != -1)//Success
                                            {
                                                MessageBox.Show($"You successfully issued a new international license with ID : " +
                                                    $"\'{renewLicenseID}\'.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                _changeMode();
                                                _settings();
                                                _showNewLicenseAndApplication(renewApplicationID, renewLicenseID);
                                                _assignRenewLocalLicense(renewLicenseID);
                                            }

                                            else
                                            {

                                                clsApplicationService.DeleteBaseApplicationInfo(renewApplicationID);

                                                MessageBox.Show("Something we wrong while we creating creating renew license:(Exception)\n",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            clsApplicationService.DeleteBaseApplicationInfo(renewApplicationID);

                                            MessageBox.Show("Something we wrong while we creating creating renew license:(Exception)\n" + ex.Message,
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }


                                    }

                                    else
                                    {
                                        //Delete application 
                                        MessageBox.Show("Something went wrong in renewing license properly.",
                                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }

                                else
                                {
                                    MessageBox.Show("Couldn't mange to save a new renew application in database .",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }

                            else
                            {
                                MessageBox.Show("Couldn't mange to create a new renew application .",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Something we wrong while we creating new renew application and license:(Exception)\n" + ex.Message,
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
            }
            else
            {
                return;
            }
        }

    }

}
