using AppplicationSerivceLib;
using DriverServiceLib;
using DVLD.DTOs;
using DVLD.DTOs.DriverDTO;
using DVLD.DTOs.LicesnseDTO;
using GlobalSettings;
using LicensesServiceLib;
using PersonServiceLibrary;
using System;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmIssueDrivingLicenseForFirstTime : Form
    {
        private enMode _enMode;
        private int _newLicenseId = -1;

        public delegate void eventHandlerNewLicense(object sender, EventArgs e);

        public eventHandlerNewLicense evNewLicenseWasCreated;
        private int _localApplicationID = -1;
        public frmIssueDrivingLicenseForFirstTime(int localApplicationID)
        {
            InitializeComponent();
            _enMode = enMode.AddNew;
            _LoadApplicationInfo(localApplicationID);
        }

        private void _LoadApplicationInfo(int localApplicationID)
        {
            applicationInfoCtrl1.loadApplicationInfo(localApplicationID);
            _localApplicationID = localApplicationID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Create a license and save in the system . 

        private DateTime _getExpireDate(int licenseClassId)
        {
            int validityLength = clsLicenseClassService.Find(licenseClassId).validityLength;
            DateTime expireDate = DateTime.Now.AddYears(validityLength);
            return expireDate;
        }

        private decimal _getFees(int licenseClassId)
        {
            return clsLicenseClassService.Find(licenseClassId).classFees;
        }

        private bool isDriverHasSameLicense(int driverId, int licenseclassId)
        {
            return clsLicenseService.isDriverOwnSameActiveLicenseClassID(driverId, licenseclassId);
        }
        private clsDriverDTO _createNewDriver(clsLocalApplicationDTO localApplicationDTO)
        {
            return new clsDriverDTO(clsPersonService.Find2(localApplicationDTO.baseApplicationDTO.personID),
                localApplicationDTO.baseApplicationDTO.UserCreatedByID, DateTime.Now);
        }
        private int _getDriverID(clsLocalApplicationDTO localApplicationDTO)
        {

            if (clsDriverService.isExists(localApplicationDTO.baseApplicationDTO.personID))
            {


                int driverId = clsDriverService.FindByPersonID(localApplicationDTO.baseApplicationDTO.personID).DriverID;
                if (!isDriverHasSameLicense(driverId, localApplicationDTO.licenseClassID))
                    return driverId;
                else
                    throw new ArgumentException("Driver has already a license with same class ID .");
            }

            else//Create a new driver and return new ID 
            {

                clsDriverService.Save(_createNewDriver(localApplicationDTO));

                return clsDriverService.FindByPersonID(localApplicationDTO.baseApplicationDTO.personID).DriverID;

            }

        }
        private clsLicenseDTO _createLicense()
        {
            try
            {
                bool isActive = true;
                clsLocalApplicationDTO localApplicationDTO = clsApplicationService.getLocalApplicationInfoByLocalAppID(_localApplicationID);

                clsLicenseSpec licenseSpec = new clsLicenseSpec(DateTime.Now, _getExpireDate(localApplicationDTO.licenseClassID),
                    tbNotes.Text, isActive, _getFees(localApplicationDTO.licenseClassID), enIssueReason.newLicense);

                return new clsLicenseDTO(localApplicationDTO.baseApplicationDTO.applicationID, localApplicationDTO.licenseClassID,
                  _getDriverID(localApplicationDTO), localApplicationDTO.baseApplicationDTO.UserCreatedByID, licenseSpec);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        private void _freeze()
        {
            tbNotes.Enabled = false;
            btnIssue.Enabled = false;
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {

            try
            {

                if (_enMode == enMode.AddNew)
                {

                    int newLicenseID = clsLicenseService.Save(_createLicense());

                    if (newLicenseID != -1)
                    {
                        _newLicenseId = newLicenseID;
                        MessageBox.Show($"License issued successfully , with License ID \' {newLicenseID}\'", "Succeed",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        evNewLicenseWasCreated?.Invoke(this, EventArgs.Empty);
                        _enMode = enMode.update;
                        _freeze();
                    }

                    else
                    {
                        MessageBox.Show($"License issued failed.", "Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }

                }

                else if (_enMode == enMode.update)
                {


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: " + ex, "Failed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
