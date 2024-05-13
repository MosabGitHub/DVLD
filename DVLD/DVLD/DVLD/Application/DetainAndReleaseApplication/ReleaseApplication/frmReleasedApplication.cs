using AppplicationSerivceLib;
using clsUsers;
using DetainLicenseServiceLib;
using DVLD.ctrls;
using DVLD.DTOs;
using DVLD.DTOs.LicenseDTO;
using DVLD.DTOs.LicenseDTO.Detained_ReleaseLicenses;
using DVLD.Licenses;
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

namespace DVLD.Application.DetainAndReleaseApplication.ReleaseApplication
{
    public partial class frmReleasedApplication : Form
    {

        private enDetainMode _enDetainMode;

        private clsDetainedLicense _DetainedLicense;
        private int _LicenseID = -1;
        public frmReleasedApplication()
        {
            InitializeComponent();
            _SubscribeToEvent_LicenseWasFound();
        }
        private void _SubscribeToEvent_LicenseWasFound()
        {
            filterInfoLicenseCtrl1.evLicenseWasFound += _FilterInfoCtrl_FoundLicense;
        }
        private bool _IsLicenseDetained(clsLicenseDTO licenseDTO)
        {
            return clsDetainLicenseService.IsLicenseDetain(licenseDTO.LicenseID);
        }
        private void _AssignLicense(clsLicenseDTO licenseDTO)
        {
            _DetainedLicense = clsDetainLicenseService.Find(licenseDTO.LicenseID);
            _LicenseID= licenseDTO.LicenseID;
        }
        private void _ActivateReleaseInfoCtrl()
        {
            releaseInfoCtrl1.Enabled = true;
        }
        private void _ActivateReleaseButton()
        {
            btnRelease.Enabled = true;
        }
        private void _ActivateLicenseHistoryButton()
        {
            lbShowLicenseHistory.Enabled = true;
        }
        private void _ActivateLicenseInfoButton()
        {
            lbShowLicenseInfo.Enabled = true;
        }
        private void _DeactivateLicenseHistoryButton()
        {
            lbShowLicenseHistory.Enabled = false;
        }
        private void _DeactivateLicenseInfoButton()
        {
            lbShowLicenseInfo.Enabled = false;
        }
        private void _DeactivateReleaseApplicationCtrl()
        {
            releaseInfoCtrl1.Enabled = false;
        }
        private void _DeactivateReleaseButton()
        {
            btnRelease.Enabled = false;
        }
        private void _DeactivateFilterInfoDriverLicenseCtrl()
        {
            filterInfoLicenseCtrl1.Enabled = false;
        }
        private void _Reset()
        {
            releaseInfoCtrl1.Reset();
            _DetainedLicense = null;
            _enDetainMode = enDetainMode.NotDetained;
            _DeactivateLicenseHistoryButton();
            _DeactivateLicenseInfoButton();
            _DeactivateReleaseApplicationCtrl();
            _DeactivateReleaseButton();
        }
        private void _settings(clsCustomEventArgs e =null)
        {
            if (_DetainedLicense != null ||e!=null)
            {
                _ActivateLicenseHistoryButton();
                _ActivateLicenseInfoButton();
            }
       
            else
            {
                filterInfoLicenseCtrl1.Reset();
            }

            if (_enDetainMode==enDetainMode.Detained)
            {
                _ActivateReleaseInfoCtrl();
                _ActivateReleaseButton();
            }
  
            else if (_enDetainMode == enDetainMode.Release)
            {
                _DeactivateReleaseButton();
                _DeactivateFilterInfoDriverLicenseCtrl();
            }
        

        }
        private void _fillCurrentAvailableApplicationData()
        {
            if (enDetainMode.Detained == _enDetainMode)
            {
                releaseInfoCtrl1.FillAvailableData(_DetainedLicense);
            }
        }
        private void _FilterInfoCtrl_FoundLicense(object sender, clsCustomEventArgs e) 
        {
            _Reset();
            try
            {
                if (e != null)
                {
                    if (_IsLicenseDetained(e.LicenseDTO))
                    {
                        _enDetainMode = enDetainMode.Detained;

                    }

                    else
                    {
                        _enDetainMode = enDetainMode.NotDetained;
                        MessageBox.Show("License you insert ain't detained in the system,\n you need to choose a " +
                            "detained license ID.","Warning",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    _AssignLicense(e.LicenseDTO);
                    _fillCurrentAvailableApplicationData();

                }
            }catch (Exception ex)
            {
                MessageBox.Show("Exception:\n"+ex.Message,"Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            _settings(e);
        }
        private int _getPersonID()
        {
            try
            {
                if (_LicenseID != -1)
                {
                    return clsLicenseService.getPersonIDByLicenseID(_LicenseID);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get person ID :\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1;
        }
        private void _lbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistoryForm = new frmLicenseHistory();
            licenseHistoryForm.LoadDataInfo(_getPersonID());
            licenseHistoryForm.ShowDialog();
        }
        private void _lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(_LicenseID);
            frmLicenseInfo.ShowDialog();
        }
        private bool _releaseDetainedLicenseFromSystem(int newReleaseApplicationID)
        {
            clsReleaseSpec releaseSpec = new clsReleaseSpec(_LicenseID, true, DateTime.Now,
                clsUserService.Find(ClsAdmin.userName).UserID, newReleaseApplicationID);

          return  clsDetainLicenseService.ReleaseDetainedLicense(releaseSpec);

        }
        private void _deleteReleaseApplicationInfo(int newReleaseApplicationID)
        {
            clsApplicationService.DeleteBaseApplicationInfo(newReleaseApplicationID);
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (_enDetainMode == enDetainMode.Detained)
            {
                int newReleaseApplicationID = -1;
                System.Media.SystemSounds.Hand.Play();
                var confirm = MessageBox.Show("Are you sure you want to release license?", "Confirm releasing process", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        clsApplicationDTO releaseApplicationInfo = releaseInfoCtrl1.CreateReleaseApplicationInfo(_getPersonID());

                        if (releaseApplicationInfo != null)
                        {

                            newReleaseApplicationID = clsApplicationService.SaveApplicationInfo(releaseApplicationInfo);

                            if (newReleaseApplicationID != -1)//Succeed
                            {
                                if (_releaseDetainedLicenseFromSystem(newReleaseApplicationID))
                                {
                                    releaseInfoCtrl1.FillNewReleaseApplicationID(newReleaseApplicationID);

                                    _enDetainMode = enDetainMode.Release;

                                    MessageBox.Show("You release the detained license from the system , successfully.",
                                        "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    _deleteReleaseApplicationInfo(newReleaseApplicationID);
                                    MessageBox.Show("something went wrong while we are trying to release detained license " +
                                        "from database.","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                _deleteReleaseApplicationInfo(newReleaseApplicationID);

                                MessageBox.Show("Failed to release the detained license .", "Failed", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }

                        }
                    }catch(Exception ex)
                    {
                        _deleteReleaseApplicationInfo(newReleaseApplicationID);

                        MessageBox.Show("Exception:\n"+ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                _settings();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
