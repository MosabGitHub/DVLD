using ApplicationDataAccess;
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

namespace DVLD.ctrls
{
    public partial class InternationalLocalApplicationInfoCTRL : UserControl
    {
        public InternationalLocalApplicationInfoCTRL()
        {
            InitializeComponent();
        }
        public void Reset()
        {

            lbInternationalLocalAppID.Text = "??";
            lbApplicationDate.Text = "??";
            lbIssueDate.Text = "??";
            lbFees.Text = "??";
            lbInternationalLocalLicenseID.Text = "??";
            lbLocalLicenseID.Text = "??";
            lbExpirationDate.Text = "??";
            lbCreatedBy.Text = "??";

        }
        private int _getPersonIDByLicenseID(clsLicenseDTO licenseDTO)
        {
            try
            {

                return clsLicenseService.getPersonIDByLicenseID(licenseDTO.LicenseID);
            }
             catch(Exception ex)
            {
                MessageBox.Show("Problem just happened due to getting person ID by this license information . \n"+ex.Message,
                    "error database ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private decimal _getApplicationTypeFees()
        {
           return  clsApplicationTypeRepository.GetApplicationFeesFromDataBaseByType(enApplicationType.NewInternationalLicense);
        }
        private DateTime _ExpirationDate()
        {
            DateTime date= DateTime.Now;
            return date.AddYears(1);
            
        }
        private void _fillApplicationDate()
        {
            lbApplicationDate.Text = DateTime.Now.ToString("dd,MMM,yyyy");

        }
        private void _fillIssueDate()
        {
            lbIssueDate.Text = DateTime.Now.ToString("dd,MMM,yyyy");

        }
        private void _fillFees()
        {
            lbFees.Text = _getApplicationTypeFees().ToString();

        }
        private void _FillNewInternationalApplicationID(int newInternationalLocalApplicationID)
        {
             lbInternationalLocalAppID.Text= newInternationalLocalApplicationID.ToString();
        }
        private void _FillNewInternationalLicenseID(int newInternationalDrivingLicenseID)
        {
            lbInternationalLocalLicenseID.Text = newInternationalDrivingLicenseID.ToString();
        }
        private void _fillLocalDrivingLicenseID(clsLicenseDTO licenseDTO)
        {
            lbLocalLicenseID.Text = licenseDTO.LicenseID.ToString();

        }
        private void _fillExpirationDate()
        {
            lbExpirationDate.Text = _ExpirationDate().ToString("dd,MMM,yyyy");

        }
        private void _fillCreatedByUserID(clsLicenseDTO licenseDTO)
        {
            clsUserService clsUserService = new clsUserService();
            lbCreatedBy.Text = clsUserService.Find(licenseDTO.UsercreatedByID).userName.ToString();

        }
        public void FillCurrentAvailableData(clsLicenseDTO licenseDTO)
        {

            _fillApplicationDate();
            _fillIssueDate();
            _fillFees();
            _fillLocalDrivingLicenseID(licenseDTO);
            _fillExpirationDate();
            _fillCreatedByUserID(licenseDTO);

        }
        public clsApplicationDTO ReturnInternationalLocalApplicationInfo(clsLicenseDTO licenseDTO)
        {
            try
            {
                int.TryParse(lbCreatedBy.Text, out int userCreatedById);

                DateTime applicationDateTime = Convert.ToDateTime(lbApplicationDate.Text);

                return new clsApplicationDTO(applicationDateTime, DateTime.Now, enApplicationType.NewLocalDrivingLicenseService,
                    enStatus.New, _getPersonIDByLicenseID(licenseDTO), userCreatedById, Convert.ToDouble(_getApplicationTypeFees()));
            
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to return international local application info\n" + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; 
        }
        public void FillNewApplicationAndLicenseIDs(int newInternationalLocalApplicationID, int newInternationalDrivingLicenseID)
        {
            _FillNewInternationalApplicationID(newInternationalLocalApplicationID);
            _FillNewInternationalLicenseID(newInternationalDrivingLicenseID);
        }
    
    }

}
