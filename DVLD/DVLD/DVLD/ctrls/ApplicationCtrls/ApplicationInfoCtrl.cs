using AppplicationSerivceLib;
using DVLD.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using GlobalSettings;
using ApplicationServiceLib;
using PersonServiceLibrary;
using LicensesServiceLib;
using DVLD.Licenses;
namespace DVLD.ctrls
{
    public partial class ApplicationInfoCtrl : UserControl
    {
        public delegate void EventHandlerReturnLocalApplicationInfoDTO(object sender, clsCustomEventArgs e);

        public EventHandlerReturnLocalApplicationInfoDTO evLocalapplicationDTO;

        private int _licenseID = -1;

        private clsLocalApplicationDTO _localapplicationDTO;
        public ApplicationInfoCtrl()
        {
            InitializeComponent();
        }

        private clsLocalApplicationDTO _getApplicationInfo(int localApplicationID)
        {
            return clsApplicationService.getLocalApplicationInfoByLocalAppID(localApplicationID);
        
        }
        private void _fillStatus() {
            
            lbStatus.Text = clsApplicationService.clsSearchForApplication.getStatusTitleBaseByApplicationID(_localapplicationDTO);
        }
        private void _fillID()
        {
            lbAppID.Text = _localapplicationDTO.baseApplicationDTO.applicationID.ToString();
            lbDrivingLocalAppID.Text = _localapplicationDTO.localApplicationID.ToString();

        }
        private void _fillFees()
        {
            lbFees.Text = _localapplicationDTO.baseApplicationDTO.Fees.ToString();
        }
        private void _fillType()
        {
            enApplicationType enApplicationType = _localapplicationDTO.baseApplicationDTO.applicationType;
            lbType.Text = clsApplicationTypeService.GetApplicationTypeByID((int)enApplicationType).Title;
        }
        private void _fillApplicant()
        {
           lbApplicant.Text =clsPersonService.Find2(_localapplicationDTO.baseApplicationDTO.personID).FullName;
          
        }    
        private void _fillLicenseClass()
        {
            lbAppForLicense.Text = clsLicenseClassService.Find(_localapplicationDTO.licenseClassID).title;
        }
        private void _fillDate()
        {
            lbDate.Text= _localapplicationDTO.baseApplicationDTO.applicationDate.ToString();
        }
        private void _fillLastStatusDate()
        {
            lblastStatusDate.Text = _localapplicationDTO.baseApplicationDTO.lastStatusDate.ToString();
        }
        private void _fillCreatedBy()
        {
            lbCreatedBy.Text = ClsAdmin.userName;
        }
        private void _fillPassedTests()
        {
            lbPassedTest.Text =clsApplicationService.clsSearchForApplication.getTotalPassedTestsByBaseApplicationID(_localapplicationDTO).ToString();
            lbPassedTest.Text += "/3";
        }
        private void _fillApplicationInfo()
        {
            _fillID ();
            _fillStatus();
            _fillFees();
            _fillType();
            _fillApplicant();
            _fillLicenseClass();
            _fillDate();
            _fillLastStatusDate();
            _fillCreatedBy();
            _fillPassedTests();
        }
        public void loadApplicationInfo(int localApplicationID)
        {

            _localapplicationDTO=(_getApplicationInfo(localApplicationID));
            if(_localapplicationDTO!=null)
            {

                 clsLicenseDTO license = clsLicenseService.FindAppInfo(_localapplicationDTO.baseApplicationDTO.applicationID);
                if (license != null)
                { 
                _licenseID = license.LicenseID;
                }
                linkLabel1.Enabled = (_licenseID != -1);
            }

            _fillApplicationInfo();

            evLocalapplicationDTO?.Invoke(this, new clsCustomEventArgs(_localapplicationDTO));//Return back to orginal form to use its data.
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
           
                frmLicenseInfo form = new frmLicenseInfo(_licenseID);
            form.ShowDialog();
         
        }
        private void _handleUpdatePersonInfo(object sender, EventArgs e)
        {
            _fillApplicant();//Reset.

        }
        private void lbViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails form = new frmPersonDetails(_localapplicationDTO.baseApplicationDTO.personID);
            form.evUpdatedPerson += _handleUpdatePersonInfo;//If a person updated this will be handled 
            form.ShowDialog();
        }
    
    }

}
