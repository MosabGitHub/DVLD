using AppplicationSerivceLib;
using clsAppointmentServiceLib;
using DVLD.DTOs;
using GlobalSettings;
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
using testLibrary;
using LicensesServiceLib;
using static DVLD.Application.frmAddEditNewLocalDrivingLicense;
using static DVLD.test.appointments.frmScheduleTest;
namespace DVLD.test.appointments
{
    public partial class frmTakeTest : Form
    {
        public delegate void eventHandlerTestTaken (object sender, EventArgs e);
        public eventHandlerTestTaken evTestWasTaken;

        private clsLocalApplicationDTO _localApplicationDTO;

        private clsTestAppointmentDTO _TestAppointmentDTO;
        
        private int _appointmentID = -1;
        private enTestType _enTestType;
        public frmTakeTest(int appointmentID, enTestType testType)
        {
            _enTestType = testType;
            InitializeComponent();
            _appointmentID = appointmentID;
            _loadApplicationInfo();
            _loadAppointmentInfo();
            _fillData();
        }     
        private void _loadAppointmentInfo()
        {
            _TestAppointmentDTO = clsAppointmentService.Find(_appointmentID);
        }
        private void _loadApplicationInfo()
        {
            _localApplicationDTO = clsApplicationService.FindLocalAppByAppointmentID(_appointmentID);
        }
        private void _fillAppID()
        {
            lbAppID.Text = _localApplicationDTO.localApplicationID.ToString();
        }
        private void _fillDrivingClass()
        {
            lbAppForLicense.Text = clsLicenseClassService.Find(_localApplicationDTO.licenseClassID).title;

        }

        private void _fillApplicantName()
        {
            lbName.Text = clsPersonService.Find2(_localApplicationDTO.baseApplicationDTO.personID).FullName;
        }

        private void _fillTrail()
        {
            //Get number of appointments for the same test from database.,which is locked.

            lbTrial.Text =
                clsAppointmentService.AccessTotalTestAppointmentIsLockedByApplicationID
                (_localApplicationDTO.baseApplicationDTO.applicationID).ToString();


        }

        private void _fillFees()
        {
            clsTestTypeRepository testTypeRepository = new clsTestTypeRepository();
            lbFees.Text = lbFees.Text = testTypeRepository.GetFeesTestType(((int)_enTestType)).ToString();
        }

        private void _fillTestID()
        {
            lbTestID.Text = "Not taken yet.";
        }
        private void _fillDate()
        {
            lbDateTestTake.Text=DateTime.Now.ToString();
        }
        private void _fillData()
        {
            _fillAppID();
            _fillDrivingClass();
            _fillApplicantName();
            _fillTrail();
            _fillDate();
            _fillFees();
            _fillTestID();
        }

        private void _freeze()
        {
            btnSave.Enabled = false;
            rbtnFail.Enabled = false;
            rbtnPass.Enabled = false;
            gbTest.Enabled = false;
        }

        private enTestResult _TestResult()
        {

            if (rbtnFail.Checked)
            {
                return enTestResult.failure;

            }

            return enTestResult.success;

        }
        private clsTestDTO _createTestInfo()
        {
            return new clsTestDTO(_appointmentID, _TestResult(), tbNotes.Text, _localApplicationDTO.baseApplicationDTO.UserCreatedByID);
        }
        private void btnSave_Enter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Green;
        }
        private void _lockedAppointment()
        {
            try
            {
                _TestAppointmentDTO.isLocked = true;
                clsAppointmentService.Save(_TestAppointmentDTO);
            }
            catch(Exception ex) {

                _TestAppointmentDTO.isLocked=false;
                MessageBox.Show("Error:" + ex.Message,"Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to save ? After that you cannot change\n" +
                "the pass/fail results, after you save.", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if (confirm == DialogResult.Yes)
            {
                try
                {

                    if (clsTestService.addNewTest(_createTestInfo()))
                    {
                        _lockedAppointment();//Pass or fail .

                        evTestWasTaken?.Invoke(this,EventArgs.Empty);//Inform that test was taken.
                        
                        MessageBox.Show("Test successfully saved into the system.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                        
                    }

                    else
                    {
                        MessageBox.Show("Test failed to save into the system.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnPass_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbtnFail_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

        }

    }
}
