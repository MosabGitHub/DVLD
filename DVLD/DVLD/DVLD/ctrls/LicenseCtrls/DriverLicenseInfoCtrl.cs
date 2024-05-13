using DetainLicenseServiceLib;
using DriverServiceLib;
using DVLD.DTOs;
using DVLD.DTOs.DriverDTO;
using GlobalSettings;
using LicensesServiceLib;
using PersonClass;
using PersonServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ctrls
{
    public partial class DriverLicenseInfoCtrl : UserControl
    {
        private clsLicenseDTO _licenseDTO;
        
        private clsDriverDTO  _driverDTO;

        public void Reset()
        {
            lbClass.Text = "?";
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
            pbDriverImage.Image=Properties.Resources.DefaultImage;
        }
        public DriverLicenseInfoCtrl()
        {
            InitializeComponent();
           
        }

        public void LoadDriverLicenseInfoCtrl(int licenseId)
        {
            _AssignLicenseInfo(licenseId);
            _AssignDriverInfo();
            _fillData();
        }
        public void LoadDriverLicenseInfoCtrl(clsLicenseDTO licenseDTO)
        {
            _licenseDTO = licenseDTO;
            _AssignDriverInfo();
            _fillData();
        }

        private void _fillClass() {

           lbClass.Text= clsLicenseClassService.Find(_licenseDTO.LicenseClassID).title.ToString();
        }
        private void _fillName()
        {
            lbName.Text = _driverDTO.PersonDTO.FullName;
        }
        private void _fillLicenseID()
        {
            lbLicenseID.Text = _licenseDTO.LicenseID.ToString();
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
            lbIsuueDate.Text = _driverDTO.CreatedDate.ToString("dd,MMM,yyyy");
        }
        private void _fillIssueReason()
        {
           enIssueReason issueReason = _licenseDTO.LicenseSpec.IssueReason;
            switch(issueReason)
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
            if(_licenseDTO.LicenseSpec.Notes!="")
            lbNotes.Text = _licenseDTO.LicenseSpec.Notes;
            else
            {
                lbNotes.Text = "No Notes";
            }

        }
        private void _fillIsActive()
        {
            if (_licenseDTO.LicenseSpec.IsActive)
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
            lbExpierationDate.Text = _licenseDTO.LicenseSpec.ExpireDate.ToString("dd,MMM,yyyy");
        }
        private void _fillIsDetained()
        {
           bool isDetained= clsDetainLicenseService.IsLicenseDetain(_licenseDTO.LicenseID);

            if (isDetained)
            {

                lbIsDetained.Text = "Yes";
                lbIsDetained.ForeColor = Color.Red;
            }
            else
            {
                lbIsDetained.ForeColor = Color.Black;
                lbIsDetained.Text = "No";
            } 

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
                MessageBox.Show("This Driver has no personal image: " + ex.Message);
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
        private void _AssignLicenseInfo(int licenseId)
        {
            _licenseDTO = clsLicenseService.Find(licenseId);
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        public void IsLicenseDetained(bool isLicenseDetained)
        {
            if(isLicenseDetained ==true)
            {
                lbIsDetained.Text = "Yes";
            }
            else
            {
                lbIsDetained.Text = "No";
            }
        }
  

        public void LicenseIsDetained()
        {
            _fillIsDetained();
        }
    }
}
