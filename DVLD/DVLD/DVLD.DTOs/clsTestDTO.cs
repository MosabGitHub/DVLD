using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalSettings;

namespace DVLD.DTOs
{
    public class clsTestDTO
    {

        private int _testID;

        private int _testAppointmentID;

        private enTestResult _testResult;

        private string _notes;

        private int _userCreateByID;

        

        public clsTestDTO(int testAppointmentID, enTestResult testResult, string notes, int userCreatedBy)
        {
            this._testID = -1;
            this._testAppointmentID = testAppointmentID;
            this._testResult = testResult;
            this._notes = notes;
            this._userCreateByID = userCreatedBy;
        }


        public int TestID
        {
            get { return _testID; }
            set { _testID = value; } // Assigning the value to the backing field, not the property itself
        }

        public int TestAppointmentID
        {
            get { return _testAppointmentID; }
            set { _testAppointmentID = value; }
        }
        public enTestResult TestResult
        {
            get { return _testResult; }
            set { _testResult = value; }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        public int UserCreatedByID
        {
            get { return _userCreateByID; }
            set { _userCreateByID = value; }
        }
    }
}
