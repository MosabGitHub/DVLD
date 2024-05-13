using DriverServiceLib;
using DVLD.DTOs;
using DVLD.DTOs.DriverDTO;
using DVLD.DTOs.LicesnseDTO;
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

namespace DVLD.ctrls.LicenseCtrls
{
    public partial class InternationalLicenseInfoCtrl : UserControl
    {
        private clsInternationalLicenseDTO _internationalLicenseDTO;
        private clsLicenseDTO _licenseDTO;
        private clsDriverDTO _driverDTO;
        public InternationalLicenseInfoCtrl()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            lbInternationalClass.Text = "?";
            lbName.Text = "?";
            lbLicenseID.Text = "?";
            lbNationalNo.Text = "?";
            lbGender.Text = "?";
            lbIsuueDate.Text = "?";
            lbIssueReason.Text = "?";
            lbNotes.Text = "?";
            lbIsActive.Text = "?";
            lbDateOfBirth.Text = "?";
            lbDriverID.Text = "?";
            lbExpierationDate.Text = "?";
            lbIsDetained.Text = "?";
            pbDriverImage.Image = Properties.Resources.DefaultImage;
        }

        public void LoadInternationalDriverLicenseInfoCtrl(int licenseId)
        {
            _AssignLicenseInfo(licenseId);
            _AssignDriverInfo();
            _fillData();
        }
        public void LoadInternationalDriverLicenseInfoCtrl(clsInternationalLicenseDTO internationallicenseDTO)
        {
            _internationalLicenseDTO = internationallicenseDTO;
            _AssignLocalLicenseInfo();
            _AssignDriverInfo();
            _fillData();
        }

        private void gbDriverLicenseInfo_Enter(object sender, EventArgs e)
        {

        }
        private void _fillClass()
        {
            lbInternationalClass.Text = "International License Class.";
        }
        private void _fillName()
        {
            lbName.Text = _driverDTO.PersonDTO.FullName;
        }
        private void _fillLicenseID()
        {
            lbLicenseID.Text = _internationalLicenseDTO.InternationalLicenseID.ToString();
        }
        private void _fillNationalNo()
        {
            lbNationalNo.Text = _driverDTO.PersonDTO.NationalNumber.ToString();
        }
        private void _fillGender()
        {
            lbGender.Text = _driverDTO.PersonDTO.Gender.ToString();
        }
        private void _fillIssueDate()
        {
            lbIsuueDate.Text = _internationalLicenseDTO.InternationalLicenseSpec.IssueDate.ToString("dd,MMM,yyyy");
        }
        private void _fillIssueReason()
        {
            enIssueReason issueReason = _licenseDTO.LicenseSpec.IssueReason;
            switch (issueReason)
            {
                case enIssueReason.newLicense:
                    {
                        lbIssueReason.Text = "First Time";
                        break;
                    }
                case enIssueReason.renewLicense:
                    {
                        lbIssueReason.Text = "renew License";
                        break;
                    }
                case enIssueReason.ReplaceForLost:
                    {
                        lbIssueReason.Text = "Replace for lost license";
                        break;
                    }
                case enIssueReason.ReplaceForDamage:
                    {
                        lbIssueReason.Text = "Replace for Damage license";
                        break;
                    }
            }

        }
        private void _fillNotes()
        {
            if (_licenseDTO.LicenseSpec.Notes != "")
                lbNotes.Text = _licenseDTO.LicenseSpec.Notes;
            else
            {
                lbNotes.Text = "No Notes";
            }

        }
        private void _fillIsActive()
        {
            if (_internationalLicenseDTO.InternationalLicenseSpec.IsActive)
            {
                lbIsActive.Text = "Yes";
            }
            else
            {
                lbIsActive.Text = "No";
            }
        }
        private void _fillDateOfBirth()
        {
            lbDateOfBirth.Text = _driverDTO.PersonDTO.Birth.ToString("dd,MMM,yyyy");
        }
        private void _fillDriverID()
        {
            lbDriverID.Text = _driverDTO.DriverID.ToString();
        }
        private void _fillExpirationDate()
        {
            lbExpierationDate.Text = _internationalLicenseDTO.InternationalLicenseSpec.ExpirationDate.ToString("dd,MMM,yyyy");
        }
        private void _fillIsDetained()
        {
            lbIsDetained.Text = "No";
        }
        private void _fillDriverPictureBox()
        {
            try
            {
                pbDriverImage.Image = Image.FromFile(_driverDTO.PersonDTO.PersonImagePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("The image file was not found.");
                pbDriverImage.Image = Properties.Resources.DefaultImage;
            }
            catch (Exception ex) // To catch other exceptions, e.g., OutOfMemoryException
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                pbDriverImage.Image = Properties.Resources.DefaultImage;

            }
        }

        private void _fillData()
        {

            if (_licenseDTO != null)
            {
                _fillClass();
                _fillName();
                _fillLicenseID();
                _fillNationalNo();
                _fillGender();
                _fillIssueDate();
                _fillIssueReason();
                _fillNotes();
                _fillIsActive();
                _fillDateOfBirth();
                _fillDriverID();
                _fillExpirationDate();
                _fillIsDetained();
                _fillDriverPictureBox();
            }
            else
            {
                throw new ArgumentException("License Didn't Assign , I couldn't fill data of license info");
            }

        }
        private void _AssignDriverInfo()
        {
            if (_licenseDTO != null)
            {
                _driverDTO = clsDriverService.Find(_licenseDTO.DriverID);
            }
        }

        private void _AssignInternationalInfo(int internationalLicenseId)
        {
            _internationalLicenseDTO=clsInternationalLicenseService.Find(internationalLicenseId);
        }
        private void _AssignLocalLicenseInfo()
        {
            _licenseDTO= clsLicenseService.Find(_internationalLicenseDTO.IssuedLocalLicenseID);
        }
        private void _AssignLicenseInfo(int internationalLicenseId)
        {
            _AssignInternationalInfo(internationalLicenseId);
            _AssignLocalLicenseInfo();


        }
    }
}
