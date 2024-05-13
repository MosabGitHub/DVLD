using AppplicationSerivceLib;
using DVLD.DTOs;
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
using GlobalSettings;
using DVLD.DTOs.LicesnseDTO;
namespace DVLD.ctrls
{
    public partial class FilterLicenseCtrl : UserControl
    {

        public delegate void LicenseEventHandler (object sender ,clsCustomEventArgs e);
        
        public LicenseEventHandler evSearchLicense;
        public FilterLicenseCtrl()
        {
            InitializeComponent();
        }
        public void reset()
        {
            tbLicenseIDSearch.Text= string.Empty;
            btnSearch.Enabled = true;
            groupBox1.Enabled = true;
        }
        public  void PerformSearchButton(object sender, EventArgs e)
        {
            // Simulate the button click
            this.btnSearch_Click(sender,e);
        }
        private void _searchForLocalLicense()
        {
            try
            {
                if (int.TryParse(tbLicenseIDSearch.Text, out int licenseID))
                {
                    clsLicenseDTO localLicenseDTO = clsLicenseService.Find(licenseID);
                    if (localLicenseDTO != null)
                    {
                        evSearchLicense?.Invoke(this, new clsCustomEventArgs(localLicenseDTO));//Succeed
                        return;

                    }
                    else
                    {
                        MessageBox.Show("License ID wasn't found in the system,Try something else.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        evSearchLicense?.Invoke(this, null);
                            return;

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception was thrown in the system:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                evSearchLicense?.Invoke(this, null);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbLicenseIDSearch.Text))
            {
                MessageBox.Show("you need to fill the box with an ID to search for it .", "Reminder", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

                _searchForLocalLicense();          
    
       
        }
        private void tbLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidIDCharachter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epSearch.SetError(tbLicenseIDSearch, errorMessage);
            }

            else
            {

                e.Handled = false;
                epSearch.SetError(tbLicenseIDSearch, "");

            }
        }
        

    }
}
