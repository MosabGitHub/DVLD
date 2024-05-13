using AppplicationSerivceLib;
using clsUsers;
using DVLD.DTOs;
using DVLD.DTOs.LicenseDTO;
using DVLD.DTOs.LicesnseDTO;
using GlobalSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DVLD.ctrls.ApplicationCtrls
{
    public partial class DetainInfoCtrl : UserControl
    {

        public event EventHandler evInputChanged;
        public DetainInfoCtrl()
        {
            InitializeComponent();
        }
        private void tbFineReason_Enter(object sender, EventArgs e)
        {
            if(tbDetainReason.Text== tbDetainReason.Tag.ToString())
            {
                tbDetainReason.Text = "";
                tbDetainReason.ForeColor = Color.Black;
            }
        }
        private void tbFineReason_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbDetainReason.Text))
            {
                tbDetainReason.Text = tbDetainReason.Tag.ToString();
                tbDetainReason.ForeColor = Color.Black;
            }
        }
        private void tbFineFees_Enter(object sender, EventArgs e)
        {
            if (tbFineFees.Text == tbFineFees.Tag.ToString())
            {
                tbFineFees.Text = "";
                tbFineFees.ForeColor = Color.Black;
            }
        }
        private void tbFineFees_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFineFees.Text))
            {
                tbFineFees.Text = tbFineFees.Tag.ToString();
                tbFineFees.ForeColor = Color.Gray;
            }
        }
        private void _fillDetainID(int newLicenseDetainedID)
        {

            lbDetainID.Text = newLicenseDetainedID.ToString();
        }
        private void _fillDetainDate()
        {
            lbDetainDate.Text = DateTime.Now.ToString("dd,MMM,yyyy");
        }
        private void _fillLicenseID(int licenseID)
        {
            lbLicenseID.Text = licenseID.ToString();
        }
        private void _fillUserCreatedBy()
        {
        
            lbCreatedBy.Text =ClsAdmin.userName;

        }
        public void FillAvailableData(int licenseID) 
        {
            _fillDetainDate();
            _fillLicenseID(licenseID);
            _fillUserCreatedBy();

        }
        private DateTime _getDetainDate()
        {
            return DateTime.Now;
        }
        private decimal _getFineFees()
        {
            return Convert.ToDecimal(tbFineFees.Text);
        }
        private int _getUserCreatedByID()
        {
            return clsUserService.Find(lbCreatedBy.Text).UserID;
        }
        private string _getDetainReason()
        {
            return tbDetainReason.Text;
        }
        private void tbFineFees_Validated(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbFineFees.Text))
            {
                epTextBoxes.SetError(tbFineFees, "You must insert amount of fees");

            }
             else if (int.TryParse(tbFineFees.Text, out int enteredAmount))
            {
                int maxAmount = 1000; // Set your maximum amount here

                if (enteredAmount > maxAmount)
                {
                    epTextBoxes.SetError(tbFineFees, "Amount exceeds the maximum limit.");
                }
                else
                {
                    epTextBoxes.SetError(tbFineFees, "");
                }
            }
            else
            {
                epTextBoxes.SetError(tbFineFees, "");
            }
        }
        private void tbDetainReason_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDetainReason.Text))
            {
                epTextBoxes.SetError(tbDetainReason, "You must insert the reason  of detaining");

                tbDetainReason.Focus();
            }
            else
            {
                epTextBoxes.SetError(tbDetainReason, "");

            }
        }
        private void tbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidationUtility.IsValidIDCharachter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epTextBoxes.SetError(tbFineFees, errorMessage);
            }
        }
        private bool isFineFeesValid()
        {
            if (string.IsNullOrEmpty(tbFineFees.Text)||tbFineFees.Text== tbFineFees.Tag.ToString()||
                 !string.IsNullOrEmpty(epTextBoxes.GetError(tbFineFees)))
            {

                return false;

            }

            return true;
        }
        private bool isDetainReasonValid()
        {
            if (string.IsNullOrEmpty(tbDetainReason.Text)|| tbDetainReason.Text== tbDetainReason.Tag.ToString())
                return false;

            return true;
        }
        private void tbFineFees_TextChanged(object sender, EventArgs e)
        {
            evInputChanged?.Invoke(this, EventArgs.Empty);

        }
        private void tbDetainReason_TextChanged(object sender, EventArgs e)
        {
            evInputChanged?.Invoke(this, EventArgs.Empty);

        }
        public bool AreInputsValid()
        {
            return isFineFeesValid() && isDetainReasonValid();
        }
        public clsDetainedLicense CreateDetainLicenseInfoWithNoID(int licenseId)
        {

            bool isReleased = false;
            clsDetainedLicenseSpec detainedLicenseSpec = new clsDetainedLicenseSpec(_getDetainDate(), _getFineFees(),
                _getUserCreatedByID(), isReleased, _getDetainReason(),null,null);

            clsDetainedLicense detainedLicense = new clsDetainedLicense(licenseId, detainedLicenseSpec);

            return detainedLicense;

        }
        public void Reset()
        {
            
            lbCreatedBy.Text = "??";
            lbDetainDate.Text = "??";
            lbDetainID.Text = "??";
            lbLicenseID.Text = "??";
            tbDetainReason.Text = tbDetainReason.Tag.ToString();
            tbFineFees.Text= tbFineFees.Tag.ToString();
        }
        public void FillNewDetainID(int newLicenseDetainedID)
        {
            _fillDetainID(newLicenseDetainedID);
        }

        public void freeze()
        {
            tbFineFees.Enabled = false;
            tbDetainReason.Enabled = false;
        }
    }
}
