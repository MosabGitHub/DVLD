using clsAppointmentServiceLib;
using DVLD.test.appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testLibrary;
using clsAppointmentServiceLib;
using DVLD.DTOs;
using DVLD.ctrls;
using GlobalSettings;
namespace DVLD.test
{
    public partial class frmTestAppointments : Form
    {
       
        private enTestType _frmCurrentTestMode;
        clsLocalApplicationDTO _localApplicationDTO;
        private void _settings()
        {
            applicationInfoCtrl1.evLocalapplicationDTO += _initializeLocalAppInfo;

            if (_frmCurrentTestMode == enTestType.Vision)
            {
                lbMain.Text = "Vision Test Appointment";
                pictureBox1.Image = Properties.Resources.eye;
            }
        
            else if (_frmCurrentTestMode == enTestType.Written)
            {
                lbMain.Text = "Written Test Appointment";
                pictureBox1.Image = Properties.Resources.test__1_;

            }
        
            else if (_frmCurrentTestMode == enTestType.Practical)
            {
                lbMain.Text = "Practical Test Appointment";
                pictureBox1.Image = Properties.Resources.cars;


            }

        }
        private void _reset(object sender ,EventArgs e )
        {
            _loadAppointments();
        }
        private async void _loadAppointments()
        {
          
            DataTable appointmentsDataTable =await clsAppointmentService.ReturnAppointmentsRelateToThisApplicationInfo(
                _frmCurrentTestMode,_localApplicationDTO.baseApplicationDTO.personID,_localApplicationDTO.licenseClassID);

            dgvAppointments.DataSource = appointmentsDataTable;
            if(appointmentsDataTable.Rows.Count>0)
            lbTotalRecords.Text = appointmentsDataTable.Rows.Count.ToString();

        }
        public frmTestAppointments(int localApplicationID, enTestType mode)
        {

            InitializeComponent();
            _frmCurrentTestMode = mode;
            _settings();
            applicationInfoCtrl1.loadApplicationInfo(localApplicationID);
            _loadAppointments();

        }
        private void _initializeLocalAppInfo(object sender, clsCustomEventArgs e)
        {
            _localApplicationDTO = e.LocalApplicationDTO;//Save memory consuming.
        }
   
        private bool _isUserHasActiveAppointment()
        {
                return clsAppointmentService.isExistsActivePerviousAppointmentSameTestType(_frmCurrentTestMode, _localApplicationDTO.localApplicationID);
            
        }
        private bool _isExistsFailedPerviousTestAppointment()
        {
            return clsAppointmentService.isExistsFailedPerviousTestAppointment(_frmCurrentTestMode,_localApplicationDTO.localApplicationID);
        }
        private bool _isExistedPassedPreviousTestAppointment()
        {
            return clsAppointmentService.isExistsPassedPerviousTestAppointment(_frmCurrentTestMode,_localApplicationDTO.localApplicationID);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _subscribeToEvent(frmScheduleTest form)
        {
            form.evAppointmentEdited += _triggerMethodBasedOnEvent;
        }
        private void _triggerMethodBasedOnEvent(object sender, EventArgs e)
        {
            _reset(sender,e);

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvAppointments.SelectedRows.Count ==1) {

                int rowIndex = dgvAppointments.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvAppointments.Rows[rowIndex];
                try
                {
                        {
                            if (int.TryParse(selectedRow.Cells["AppointmentID"].Value.ToString(), out int appointmentID))
                            {
                            frmScheduleTest edit = new frmScheduleTest(appointmentID,_frmCurrentTestMode);
                            _subscribeToEvent(edit);
                            edit.ShowDialog();
                        }
                        }
                    
                }catch(Exception ex)
                {
                    MessageBox.Show("Error:"+ex.Message,"Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error:" + "you need to choose one appointment ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void _subscribeToEvent(frmTakeTest form)
        {
            form.evTestWasTaken += _reset;
        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 1)
            {
                int rowIndex = dgvAppointments.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvAppointments.Rows[rowIndex];
                try
                {
                    {
                        if (int.TryParse(selectedRow.Cells["AppointmentID"].Value.ToString(), out int appointmentID))
                        {
                            if(bool.TryParse(selectedRow.Cells["IsLocked"].Value.ToString(), out bool isLocked)){

                                if (!isLocked)
                                {
                                    frmTakeTest takeTestFrm = new frmTakeTest(appointmentID, _frmCurrentTestMode);
                                    _subscribeToEvent(takeTestFrm);
                                    takeTestFrm.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show($"Appointment ID : \'{appointmentID}\' is locked you can't re-take it . ", "Failed", MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);

                                }
                            }
                            
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error:" + "you need to choose one appointment ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnAppointment_Click(object sender, EventArgs e)
        {
            enFormMode enStatusForm = enFormMode.newOne;
            bool isAvailableToBookAppointment = true;

            if (_isUserHasActiveAppointment())
            {

                MessageBox.Show("The person has an active appointment for this test\n,you can't add " +
                    "new appointment", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isAvailableToBookAppointment = false;
            }

            else  if (_isExistedPassedPreviousTestAppointment())
            {
                MessageBox.Show("The person has already passed the test before \n,you can't add " +
                                    "new appointment for this test", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isAvailableToBookAppointment = false;

            }
            
            else if (_isExistsFailedPerviousTestAppointment())
            {
                enStatusForm = enFormMode.reTake;

            }
     
            if (isAvailableToBookAppointment)
            {
                using (var ScheduleTestForm = new frmScheduleTest(_localApplicationDTO.localApplicationID,
                              _frmCurrentTestMode, enStatusForm))
                {
                    _subscribeToEvent(ScheduleTestForm);
                    ScheduleTestForm.ShowDialog();
                    _reset(sender,e);
                }
            }
           
         }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
