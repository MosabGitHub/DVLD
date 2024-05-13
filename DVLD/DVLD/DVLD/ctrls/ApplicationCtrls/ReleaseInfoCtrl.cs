using clsUsers;
using DVLD.DTOs;
using DVLD.DTOs.LicenseDTO;
using GlobalSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ctrls.ApplicationCtrls
{
    public partial class ReleaseInfoCtrl : UserControl
    {

        private clsDetainedLicense _DetainedLicense;
        private void _settings()
        {
            tbDetainReason.Enabled = false;
        }
        public ReleaseInfoCtrl()
        {
            InitializeComponent();
            _settings();
        }
        private void _fillDetainID()
        {
            
            lbDetainID.Text = _DetainedLicense.DetainID.ToString();
        }
        private void _fillDetainDate()
        {
            lbDetainDate.Text = _DetainedLicense.DetainSpec.DetainDate.ToString("dd,MMM,yyyy");
        }
        private void _fillLicenseID()
        {
            lbLicenseID.Text = _DetainedLicense.LicenseID.ToString();
        }
        private void _fillUserCreatedBy()
        {

            lbCreatedBy.Text =_DetainedLicense.DetainSpec.CreateByUserID.ToString();

        }
        private void _fillFineFees()
        {
            lbFineFees.Text = _DetainedLicense.DetainSpec.FineFees.ToString();
        }
        private void _fillApplicationFees()
        {
            lbApplicationFees.Text=
            clsApplicationTypeRepository.GetApplicationFeesFromDataBaseByType
            (enApplicationType.ReleaseDetainedDrivingLicense).ToString();

        }
        private void _fillTotalFees()
        {
            if(decimal.TryParse(lbFineFees.Text,out decimal fineFees)&&
                decimal.TryParse(lbApplicationFees.Text, out decimal applicationFees))
            {
            
                lbTotalFees.Text=(fineFees+applicationFees).ToString();
         
            }
            else
            {
                lbTotalFees.Text = "-1";
                throw new ArgumentException("finance problem.");
            }
        }
        private void _fillFees()
        {
            _fillFineFees();
            _fillApplicationFees();
            _fillTotalFees();
        }
        private void _fillDetainReason()
        {
            tbDetainReason.Text = _DetainedLicense.DetainSpec.DetainReason.ToString();
        }
        private void _AssignDetainedLicense(clsDetainedLicense detainedLicense)
        {
            _DetainedLicense= detainedLicense;
        }
        public void FillAvailableData(clsDetainedLicense detainedLicense)
        {
            _AssignDetainedLicense(detainedLicense);
            _fillDetainID();
            _fillDetainDate();
            _fillFees();
            _fillDetainReason();
            _fillUserCreatedBy();
            _fillLicenseID();
            _fillUserCreatedBy();
        }
        public void FillNewReleaseApplicationID(int newReleaseApplicationID)
        {
            lbReleaseApplicationID.Text = newReleaseApplicationID.ToString();
            lbReleaseApplicationID.ForeColor = Color.Red;

        }
        public void Reset()
        {
            lbReleaseApplicationID.ForeColor= Color.Black;
            _DetainedLicense = null;
            lbDetainID.Text = "??";
            lbDetainDate.Text = "??";
            lbFineFees.Text = "??";
            lbApplicationFees.Text = "??";
            tbDetainReason.Text = tbDetainReason.Tag.ToString();
            lbLicenseID.Text = "??";
            lbCreatedBy.Text = "??";
            lbTotalFees.Text = "??";
            lbReleaseApplicationID.Text = "??";

        }
        private double _GetFees()
        {
            try
            {
                if (!double.TryParse(lbTotalFees.Text, out double totalFees))
                {
                    totalFees = -1;
                }
                return totalFees;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public clsApplicationDTO CreateReleaseApplicationInfo(int personID)
        {
            try
            {
                DateTime date = DateTime.Now;
                DateTime lastStatusDate = date;
                enApplicationType enApplicationType = enApplicationType.ReleaseDetainedDrivingLicense;
                enStatus enApplicationStatus = enStatus.New;
                int userCreatedByID = clsUserService.Find(ClsAdmin.userName).UserID;
                double totalFees = _GetFees();

                return new clsApplicationDTO(date, lastStatusDate,
                    enApplicationType, enApplicationStatus, personID, userCreatedByID, totalFees);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong in creating a new release application type:\n"+ex.Message
                    , "Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null; 
            }

        }

    }

}
