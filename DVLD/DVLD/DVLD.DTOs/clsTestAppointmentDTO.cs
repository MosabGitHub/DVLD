using GlobalSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs
{
    public class clsTestAppointmentDTO
    {

        readonly int _appointmentID;
        readonly int _testTypeID;
        readonly int _applicationID;
        readonly int _personID;
        public DateTime appointmentDate;
        public decimal fees;
        readonly DateTime dateOfApply;
        private bool _isLocked;
        readonly enStatus _State;
        public clsTestAppointmentDTO(int testTypeID, int applicationID, int personID, DateTime appointmentDate,
            decimal fees, DateTime dateOfApply, bool isLocked) {
            this._appointmentID = -1;
            this._testTypeID = testTypeID;
            this._applicationID = applicationID;
            this._personID = personID;
            this.appointmentDate = appointmentDate;
            this.fees = fees;
            this.dateOfApply = dateOfApply;
            this.isLocked = isLocked;
            _State = enStatus.New;

        }
        public clsTestAppointmentDTO(int appointmentID, int testTypeID, int applicationID, int personID, DateTime appointmentDate,
            decimal fees, DateTime dateOfApply, bool isLocked)
        {
            this._appointmentID = appointmentID;
            this._testTypeID = testTypeID;
            this._applicationID = applicationID;
            this._personID = personID;
            this.appointmentDate = appointmentDate;
            this.fees = fees;
            this.dateOfApply = dateOfApply;
            this.isLocked = isLocked;
            
        }

        public int AppointmentID { get { return this._appointmentID; } }

        public int TestTypeID {  get { return this._testTypeID; } }

        public int ApplicationID {  get { return this._applicationID; } }

        public int PersonID {  get { return this._personID; } }

        public DateTime AppointmentDate { set { this.appointmentDate = value; } get { return this.appointmentDate; } }

        public DateTime DateOfApply { get { return this.dateOfApply; } }

        public bool isLocked {
            set
            {
                if (_isLocked == false)
                { this._isLocked = value; }
                else
                    throw new ArgumentException("You can't unlock an appointment.");
            }
            get { return _isLocked; } }
    }

}

