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
    public partial class RenewApplicationInfoCtrl : UserControl
    {
        public RenewApplicationInfoCtrl()
        {
            InitializeComponent();
        }
        public void Reset()
        {

            lbRenewAppID.Text = "??";
            lbApplicationDate.Text = "??";
            lbIssueDate.Text = "??";
            lbApplicationFees.Text = "??";
            lbLicenseFees.Text = "??";
            tbNotes.Text = string.Empty;
            lbRenewLicenseID.Text = "??";
            lbOldLicenseID.Text = "??";
            lbExpirationDate.Text = "??";
            lbCreatedBy.Text = "??";
            lbTotalFees.Text = "??";

        }
        private int _getPersonIDByLicenseID(clsLicenseDTO OldLicenseDTO)
        {
            try
            {
                return clsLicenseService.getPersonIDByLicenseID(OldLicenseDTO.LicenseID);
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
            return clsApplicationTypeRepository.GetApplicationFeesFromDataBaseByType(enApplicationType.RenewDrivingLicenseService);
        }
        private DateTime _ExpirationDate()
        {
            DateTime date = DateTime.Now;
            return date.AddYears(10);

        }
        private void _fillApplicationDate()
        {
            lbApplicationDate.Text = DateTime.Now.ToString("dd,MMM,yyyy");

        }
        private void _fillIssueDate()
        {
            lbIssueDate.Text = DateTime.Now.ToString("dd,MMM,yyyy");

        }
        private void _fillApplicationFees()
        {
            lbApplicationFees.Text = _getApplicationTypeFees().ToString();
        }
        private void _fillLicenseFees(decimal licenseFees)
        {
            lbLicenseFees.Text= licenseFees.ToString();
        }
        private void _fillTotalFees()
        {
            try {
                decimal appFees = Convert.ToDecimal(lbApplicationFees.Text);
                decimal licenseFees= Convert.ToDecimal(lbLicenseFees.Text);

                lbTotalFees.Text = (appFees + licenseFees).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:\n"+ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                lbTotalFees.Text = "-1";
            }

            }
        private void _fillFees(clsLicenseDTO OldLicenseDTO)
        {
            _fillLicenseFees(OldLicenseDTO.LicenseSpec.PaidFees);
            _fillApplicationFees();
            _fillTotalFees();

        }
        private void _FillRenewApplicationID(int renewApplicationID)
        {
            lbRenewAppID.Text = renewApplicationID.ToString();
        }
        private void _FillRenewLicenseID(int renewDrivingLicenseID)
        {
            lbRenewLicenseID.Text = renewDrivingLicenseID.ToString();
        }
        private void _fillOldDrivingLicenseID(clsLicenseDTO OldLicenseDTO)
        {
            lbOldLicenseID.Text = OldLicenseDTO.LicenseID.ToString();

        }
        private void _fillExpirationDate()
        {
            lbExpirationDate.Text = _ExpirationDate().ToString("dd,MMM,yyyy");

        }
        private void _fillCreatedByUserID(clsLicenseDTO OldLicenseDTO)
        {

            clsUserService userService = new clsUserService();
            lbCreatedBy.Text = userService.Find(OldLicenseDTO.UsercreatedByID).userName.ToString();

        }
        public void FillCurrentAvailableData(clsLicenseDTO OldLicenseDTO)
        {

            _fillApplicationDate();
            _fillIssueDate();
            _fillFees(OldLicenseDTO);
            _fillOldDrivingLicenseID(OldLicenseDTO);
            _fillExpirationDate();
            _fillCreatedByUserID(OldLicenseDTO);

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
            catch (Exception ex)
            {
                MessageBox.Show("Failed to return international local application info\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        public void FillNewApplicationAndLicenseIDs(int newRenewApplicationID, int RenewDrivingLicenseID)
        {
            _FillRenewApplicationID(newRenewApplicationID);
            _FillRenewLicenseID(RenewDrivingLicenseID);
        }
        public string Notes()
        {
            return tbNotes.Text;
        }
        public decimal LicenseFees()
        {
            return Convert.ToDecimal(lbLicenseFees.Text);
        }

        private void tbNotes_Enter(object sender, EventArgs e)
        {
            if(tbNotes.Text=="Enter your notes here...")
            {
                tbNotes.Text = "";
                tbNotes.BackColor=Color.Black;
            }
        }

        private void tbNotes_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNotes.Text))
            {
                tbNotes.Text = "Enter your notes here...";
                tbNotes.BackColor=Color.Gray;
            }
        }
    }
}
