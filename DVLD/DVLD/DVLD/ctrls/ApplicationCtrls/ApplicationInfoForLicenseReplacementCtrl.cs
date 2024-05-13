using clsUsers;
using DVLD.DTOs;
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

namespace DVLD.ctrls.ApplicationCtrls
{
    public partial class ApplicationInfoForLicenseReplacementCtrl : UserControl
    {
        private enApplicationType _enApplicationType;

        public void FillCurrentAvailableData(clsLicenseDTO licenseDTO, enApplicationType applicationType)
        {
            _enApplicationType = applicationType;
            _fillApplicationDate();
            _fillFees();
            _fillOldDrivingLicenseID(licenseDTO);
            _fillCreatedByUserID(licenseDTO);

        }
        public clsApplicationDTO ReturnReplacementApplicationInfo(clsLicenseDTO licenseDTO)
        {
            try
            {
                int.TryParse(lbCreatedBy.Text, out int userCreatedById);

                DateTime applicationDateTime = Convert.ToDateTime(lbApplicationDate.Text);

                return new clsApplicationDTO(applicationDateTime, DateTime.Now, _enApplicationType,
                    enStatus.New, _getPersonIDByLicenseID(licenseDTO), userCreatedById, Convert.ToDouble(_getApplicationTypeFees()));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to return international local application info\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        public void FillNewApplicationAndReplacedLicenseIDs(int newReplacementApplicationID, int newReplacedDrivingLicenseID)
        {
            _FillNewReplacementApplicationID(newReplacementApplicationID);
            _FillNewReplacedLicenseID(newReplacedDrivingLicenseID);
        }
        public void Reset()
        {

            lbLicenseReplacementAppID.Text = "??";
            lbApplicationDate.Text = "??";
            lbFees.Text = "??";
            lbReplcaedLicenseID.Text = "??";
            lbOldLicenseID.Text = "??";
            lbCreatedBy.Text = "??";

        }
        public ApplicationInfoForLicenseReplacementCtrl()
        {
            InitializeComponent();
        }

        private int _getPersonIDByLicenseID(clsLicenseDTO licenseDTO)
        {
            try
            {

                return clsLicenseService.getPersonIDByLicenseID(licenseDTO.LicenseID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem just happened due to getting person ID by this license information . \n" + ex.Message,
                    "error database ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private decimal _getApplicationTypeFees()
        {
            return clsApplicationTypeRepository.GetApplicationFeesFromDataBaseByType(_enApplicationType);
        }
        private void _fillApplicationDate()
        {
            lbApplicationDate.Text = DateTime.Now.ToString("dd,MMM,yyyy");

        }
        private void _fillFees()
        {
            lbFees.Text = _getApplicationTypeFees().ToString();

        }
        private void _FillNewReplacementApplicationID(int newReplacementApplicationID)
        {
            lbLicenseReplacementAppID.Text = newReplacementApplicationID.ToString();
        }
        private void _FillNewReplacedLicenseID(int newReplacedDrivingLicenseID)
        {
            lbReplcaedLicenseID.Text = newReplacedDrivingLicenseID.ToString();
        }
        private void _fillOldDrivingLicenseID(clsLicenseDTO licenseDTO)
        {
            lbOldLicenseID.Text = licenseDTO.LicenseID.ToString();

        }
        private void _fillCreatedByUserID(clsLicenseDTO licenseDTO)
        {
            clsUserService  userService = new clsUserService();
            lbCreatedBy.Text = userService.Find(licenseDTO.UsercreatedByID).userName.ToString();

        }
     
     
        public void ReFillApplicationFees(enApplicationType applicationType)
        {
            _enApplicationType= applicationType;
            _fillFees();
        }

    }
}
