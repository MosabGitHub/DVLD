using DetainLicenseServiceLib;
using DVLD.ctrls;
using DVLD.DTOs;
using DVLD.DTOs.LicenseDTO;
using DVLD.DTOs.LicesnseDTO;
using DVLD.Licenses;
using GlobalSettings;
using LicensesServiceLib;
using PersonServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Application.DetainAndReleaseApplication.DetainApplications
{
    public partial class frmDetainApplication : Form
    {
        private enum enDetainMode
        {
            Detained,
            NotDetained


        }

        private enDetainMode _enIsDetained;

        int newDetainId = -1;
        bool _isSearchLicenseDetained = false;
        private clsLicenseDTO _DetainLicenseDTO;
        public frmDetainApplication()
        {
            InitializeComponent();
            _SubscribeToEvent_LicenseWasFound();
            _SubscribeToEvent_InputChange();

        }

        private void _activateLicenseHistoryButton()
        {
            lbShowLicenseHistory.Enabled = true;
        }
        private void _deactivateLicenseHistoryButton()
        {
            lbShowLicenseHistory.Enabled = false;
        }
        private void _deactivateLicenseInfoButton()
        {
            lbShowLicenseInfo.Enabled = false;
        }
        private void _activateLicenseInfoButton()
        {
            lbShowLicenseInfo.Enabled = true;
        }
        private void _deactivateDetainInfoCtrl()
        {
            detainInfoCtrl1.Enabled = false;
        }
        private void _activateDetainInfoCtrl()
        {
            detainInfoCtrl1.Enabled = true;
        }
        private void _settings()
        {
            if (_enIsDetained==enDetainMode.Detained)
            {
                detainInfoCtrl1.FillNewDetainID(newDetainId);
                detainInfoCtrl1.freeze();
                filterInfoLicenseCtrl1.LicenseIsDetained();
                _deactivateSearchLicenseCtrl();
                _deactivateDetainInfoCtrl();
                deactivateDetainButton();
                
            }

            if (!_isSearchLicenseDetained)
            {
                _activateDetainInfoCtrl();
            }

            if (_DetainLicenseDTO != null)
            {
                _activateLicenseHistoryButton(); 
                _activateLicenseInfoButton();
            }
    
            else
            {
                _deactivateLicenseHistoryButton();
                _deactivateLicenseInfoButton();
                _deactivateDetainInfoCtrl();
                
            }

        }
        private void _reset()
        {
            _isSearchLicenseDetained = false;
            _DetainLicenseDTO = null;
            filterInfoLicenseCtrl1.Reset();
            detainInfoCtrl1.Reset();
            _enIsDetained = enDetainMode.NotDetained;
        }
        private void _SubscribeToEvent_LicenseWasFound()
        {
            filterInfoLicenseCtrl1.evLicenseWasFound += _FilterInfoCtrl_FoundLicense;
        }
        private void _SubscribeToEvent_InputChange()
        {
            detainInfoCtrl1.evInputChanged += inputChanged;

        }
        private void inputChanged(object sender, EventArgs e)
        {

            if (detainInfoCtrl1.AreInputsValid() && _DetainLicenseDTO != null && _isSearchLicenseDetained == false)
            {
                btnDetain.Enabled = true;
            }
            
        }
        private void _AssignFoundLicense(clsLicenseDTO foundLicense)
        {
            _DetainLicenseDTO = foundLicense;
        }
        private bool _IsLicenseDetained()
        {
            return clsDetainLicenseService.IsLicenseDetain(_DetainLicenseDTO.LicenseID);
        }
        private void _fillCurrentAvailableApplicationInfo()
        {
            detainInfoCtrl1.FillAvailableData(_DetainLicenseDTO.LicenseID);
        }
        private void _FilterInfoCtrl_FoundLicense(object sender, clsCustomEventArgs e)
        {
            _isSearchLicenseDetained = false;
            _enIsDetained = enDetainMode.NotDetained;

            if (e != null)
            {
                _AssignFoundLicense(e.LicenseDTO);
                _fillCurrentAvailableApplicationInfo();
                if (_IsLicenseDetained())
                {
                    MessageBox.Show("License already detained in the system", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    _isSearchLicenseDetained = true;
                }
                _settings();
            }
            else
            {
                _reset();
                _settings();
            }
        }
        private clsDetainedLicense _createDetainedLicenseInfo()
        {
            return detainInfoCtrl1.CreateDetainLicenseInfoWithNoID(_DetainLicenseDTO.LicenseID);

        }
        private void deactivateDetainButton()
        {
            btnDetain.Enabled = false;
        }

        private void _deactivateSearchLicenseCtrl()
        {
            filterInfoLicenseCtrl1.Enabled = false;
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Hand.Play();
            var confirm = MessageBox.Show("Are you sure you want to detain license?", "Confirm detain process", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    clsDetainedLicense DetainedLicense = _createDetainedLicenseInfo();

                    int newDetainedLicenseInfoId = clsDetainLicenseService.Save(DetainedLicense);

                    if (newDetainedLicenseInfoId != -1)//Success
                    {

                        MessageBox.Show("You have detained the license in the system successfully.", "Succeed",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _enIsDetained = enDetainMode.Detained;
                        newDetainId = newDetainedLicenseInfoId;
                        _settings();
                    }
                    else
                    {
                        MessageBox.Show("Failed to  detained the license in the system.", "Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _settings();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:"+ex.Message,"Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    _settings();

                }

            }
        }
        private int _getPersonID()
        {
            try
            {
                if (_DetainLicenseDTO != null)
                {
                    return clsLicenseService.getPersonIDByLicenseID(_DetainLicenseDTO.LicenseID);

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
            frmLicenseHistory licenseHistoryForm= new frmLicenseHistory();
            licenseHistoryForm.LoadDataInfo(_getPersonID());
            licenseHistoryForm.ShowDialog();
        }
        private void lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(_DetainLicenseDTO.LicenseID);
                frmLicenseInfo.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
