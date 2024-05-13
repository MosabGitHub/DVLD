using AppplicationSerivceLib;
using clsAppointmentServiceLib;
using DVLD.DTOs;
using GlobalSettings;
using PersonServiceLibrary;
using System;
using LicensesServiceLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testLibrary;
using static DVLD.test.appointments.frmScheduleTest;
using clsUsers;
using DVLD.DTOs.ApplicationDTO;
using AppplicationSerivceLib;


namespace DVLD.test.appointments
{
    public partial class frmScheduleTest : Form
    {

        public delegate void eventHandlerTestAppointment(object sender, EventArgs e);
        public eventHandlerTestAppointment evAppointmentEdited;

        private enFormMode _enFrmMode;

        private enTestType _enTestType;

        private clsLocalApplicationDTO _localApplicationDTO;

        private clsTestAppointmentDTO _testAppointmentDTO;//Edit mode.
        private void _settings()
        {
            dtpAppointment.MinDate = DateTime.Now;
            switch (_enTestType)
            {
                case enTestType.Vision:
                    {
                        gbTest.Text = "Vision";
                        break;
                    }
                case enTestType.Written:
                    {
                        gbTest.Text = "Written";
                        break;
                    }
                case enTestType.Practical:
                    {
                        gbTest.Text = "Practical";
                        break;
                    }
                default:
                    {
                        gbTest.Text = "Test";
                        break;
                    }
            }

            switch (_enFrmMode)
            {
                case enFormMode.newOne:
                    {
                        lbHeader.Text = "Schedule Test";
                        break;
                    }
         
                case enFormMode.reTake:
                    {
                        lbHeader.Text = "Schedule Retake Test";
                        lbSubHeader.Text = "";
                        dtpAppointment.Enabled = Enabled;
                        btnSave.Enabled = Enabled;
                        gbRetakeTest.Enabled = true;
                        break;
                    }
          
                case enFormMode.locked:
                    {
                        lbHeader.Text = "Locked Test";
                        lbSubHeader.Text = "Person already sat for the test,appointment locked";
                        dtpAppointment.Enabled = false;
                        btnSave.Enabled = false;
                        gbRetakeTest.Enabled = false;
                        break;
                    }
      
                case enFormMode.edit:
                    {
                        lbHeader.Text = "Edit Test";
                        lbSubHeader.Text = "";
                        dtpAppointment.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    }

            }
        }
        public frmScheduleTest(int ApplicationID, enTestType enTestType, enFormMode formMode)
        {
             InitializeComponent();
            _changeFrmMode(formMode);
            _changeTestType(enTestType);
            _loadApplicationInfo(ApplicationID);
            _settings();
        }
        public frmScheduleTest(int appointmentID,enTestType enTestType)
        {

             InitializeComponent();
            _changeFrmMode(enFormMode.edit);
            _changeTestType(enTestType);
            _loadApplicationInfoByAppointmentID(appointmentID);
            _InitializeAppointmentInfo(appointmentID);
            _checkAppointmentIsLocked();
            _fillData();
            _settings();
            _changeTestType((enTestType)_testAppointmentDTO.TestTypeID);

        }
    
        private void _loadApplicationInfoByAppointmentID(int appointmentID)
        {
            _localApplicationDTO = clsApplicationService.FindLocalAppByAppointmentID(appointmentID);

        }
        private void _checkAppointmentIsLocked()
        {
            if (_testAppointmentDTO.isLocked)
            {
                _changeFrmMode(enFormMode.locked);
            }
        }
        private void _changeFrmMode(enFormMode frmMode)
        {
            _enFrmMode = frmMode;
        }
        private void _changeTestType(enTestType enTestType)
        {
            _enTestType = enTestType;
        }
        private void _InitializeAppointmentInfo(int appointmentID)
        {
            _testAppointmentDTO = clsAppointmentService.Find(appointmentID);
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
       
                lbTrial.Text = clsAppointmentService.AccessTotalTestAppointmentIsLockedByApplicationID
                (_localApplicationDTO.baseApplicationDTO.applicationID).ToString();
          

        }
        private void _fillFees()
        {
            if (_enTestType == enTestType.Vision)
            {
                clsTestTypeRepository testTypeRepository = new clsTestTypeRepository();
                lbRetakeTotalFees.Text = lbFees.Text = testTypeRepository.GetFeesTestType(((int)enTestType.Vision)).ToString();
            }
            else if (_enTestType == enTestType.Written)
            {
                clsTestTypeRepository testTypeRepository = new clsTestTypeRepository();
                lbRetakeTotalFees.Text = lbFees.Text = testTypeRepository.GetFeesTestType(((int)enTestType.Written)).ToString();
            }
            else if (_enTestType == enTestType.Practical)
            {
                clsTestTypeRepository testTypeRepository = new clsTestTypeRepository();
                lbRetakeTotalFees.Text = lbFees.Text = testTypeRepository.GetFeesTestType(((int)enTestType.Practical)).ToString();
            }
        }
        private decimal _getRetakeApplicationFees()
        {
            return clsApplicationTypeRepository.GetApplicationFeesFromDataBaseByType(enApplicationType.RetakeTest);
        }
        private void _fillRetakeTestInfo()
        {

            if (_enFrmMode == enFormMode.edit)
            {
                clsApplicationDTO retakeTestApplication = clsApplicationService.clsSearchForApplication.GetRetakeApplicationByID(_localApplicationDTO.baseApplicationDTO.personID);
                if (retakeTestApplication != null && retakeTestApplication.applicationType == enApplicationType.RetakeTest)
                {
                    gbRetakeTest.Enabled= true;
                    lbRetakeAppID.Text = retakeTestApplication.applicationID.ToString();
                }
            }

            clsTestTypeRepository testTypeRepository = new clsTestTypeRepository();

            lbRetakeFees.Text = _getRetakeApplicationFees().ToString();

            lbRetakeTotalFees.Text = (Prices.RetakeTestPrice + testTypeRepository.GetFeesTestType((int)_enTestType)).ToString();


        }
        private void _fillData()
        {
            _fillAppID();
            _fillDrivingClass();
            _fillApplicantName();
            _fillTrail();
            _fillFees();
            _fillRetakeTestInfo();
        }
        private void _loadApplicationInfo(int localApplicationID)
        {
            try
         
            {
                _localApplicationDTO = clsApplicationService.getLocalApplicationInfoByLocalAppID(localApplicationID);
                _fillData();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Access to local application wasn't finished.\n", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private decimal returnFeesBasedOnTestType(enTestType enTestType)
        {
            clsTestTypeRepository testTypeRepository = new clsTestTypeRepository();

            switch (enTestType)
            {
                case enTestType.Vision:
                    {
                        return testTypeRepository.GetFeesTestType((int)enTestType.Vision);
                    }
                case enTestType.Written:
                    {
                        return testTypeRepository.GetFeesTestType((int)enTestType.Written);

                    }
                case enTestType.Practical:
                    {
                        return testTypeRepository.GetFeesTestType((int)enTestType.Practical);

                    }
            }
            return -1;
        }
        private decimal _getFees()
        {
            //based on test type
            if (enFormMode.newOne == _enFrmMode)
            {
                return returnFeesBasedOnTestType(_enTestType);

            }

            else if (enFormMode.reTake == _enFrmMode)
            {
                return Prices.RetakeTestPrice + returnFeesBasedOnTestType(_enTestType);
            }

            else
            {
               return  returnFeesBasedOnTestType(_enTestType);
            }
        }

        private int _getPersonID()
        {
            return _localApplicationDTO.baseApplicationDTO.personID;
        }
        private int _getUserCreatedByID()
        {
            return _localApplicationDTO.baseApplicationDTO.UserCreatedByID;
        }
        private int createRetakeApplicationAndSaveInDataBase()
        {
            clsUserService clsUserService = new clsUserService();
            int newRetakeApplicationID = -1;

            int userCreatedById = _localApplicationDTO.baseApplicationDTO.UserCreatedByID;
            enApplicationType enApplicationType = enApplicationType.RetakeTest;

            clsApplicationDTO retakeTestApplication = new clsApplicationDTO(DateTime.Now,DateTime.Now,
                enApplicationType,enStatus.New, _getPersonID(), _getUserCreatedByID(),(double)_getRetakeApplicationFees());//Create app

            if (retakeTestApplication != null)//SAve to database
            {
                 newRetakeApplicationID=  clsApplicationService.SaveApplicationInfo(retakeTestApplication);
                    
            }

            return newRetakeApplicationID;

        }
        private clsTestAppointmentDTO _createAppointment()
        {
            bool isLocked = false;
            DateTime dateOfApply = DateTime.Now;
            decimal fees = _getFees() ;

            //Does exists.
            if (enFormMode.reTake == _enFrmMode)
            {
                int newRetakeApplicationID = createRetakeApplicationAndSaveInDataBase();
                if (newRetakeApplicationID != -1)
                {
                    return new clsTestAppointmentDTO((int)_enTestType, _localApplicationDTO.localApplicationID,
                   _localApplicationDTO.baseApplicationDTO.personID, dtpAppointment.Value, fees, dateOfApply, isLocked);
                }
                else
                {
                    MessageBox.Show("Failed to create appointment .");
                    return null;
                }
            }

            else//Normal test appointment 
            {
                return new clsTestAppointmentDTO((int)_enTestType, _localApplicationDTO.localApplicationID,
                _localApplicationDTO.baseApplicationDTO.personID, dtpAppointment.Value, fees, dateOfApply, isLocked);

            }
            

        }
        private void _updateAppointment()
        {
             if (enFormMode.edit == _enFrmMode)
            {
                
                _testAppointmentDTO.AppointmentDate = dtpAppointment.Value;
            }
        }
        private void _freeze()
        {
            gbTest.Enabled=false;
            btnSave.Enabled = false;

        }    
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_enFrmMode == enFormMode.newOne|| _enFrmMode == enFormMode.reTake)
            {
                 _testAppointmentDTO = _createAppointment();
                if (_testAppointmentDTO != null)
                {
                    try
                    {
                        if (clsAppointmentService.Save(_testAppointmentDTO))
                        {
                            MessageBox.Show($"Appointment scheduled successfully.", "Succeed"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _freeze();
                        }
                        else
                        {
                            MessageBox.Show("Couldn't add a new appointment due to some problems in the system.", "Failed"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Problem occurred: \' {ex.Message} \'scheduled Failed.", "Failed"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
          
            else if (_enFrmMode == enFormMode.edit)
            {
                try { 
                      _updateAppointment();
                    {
                        

                        if (clsAppointmentService.Save(_testAppointmentDTO))
                        {
                            MessageBox.Show($"Appointment ID : \' {_testAppointmentDTO.AppointmentID} \'updated successfully.", "Succeed"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            evAppointmentEdited?.Invoke(this, new EventArgs());//Reset data in the form .
                            _freeze();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Problem occureed: \' {ex.Message} \'scheduled Failed.", "Failed"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void dtpAppointment_ValueChanged(object sender, EventArgs e)
        {
            _testAppointmentDTO.appointmentDate = dtpAppointment.Value;
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
