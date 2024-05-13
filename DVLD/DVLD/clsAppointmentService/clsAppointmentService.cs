using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DTOs;

using TestAppointmentDataAccessLib;
using GlobalSettings;
namespace clsAppointmentServiceLib
{
    public class clsAppointmentService
    {
        private static  bool AddNewAppointment(clsTestAppointmentDTO testAppointmentDTO)
        {
             int newAppointmentID=clsAppointmentDataAcess.addNewTestAppointment(testAppointmentDTO);

            return newAppointmentID != -1;
        }
        private static bool UpdateAppointment(clsTestAppointmentDTO testAppointmentDTO)
        {
            return clsAppointmentDataAcess.UpdateApplicationInfo(testAppointmentDTO);
        }

        public static clsTestAppointmentDTO Find(int appointmentID)
        {

            return clsAppointmentDataAcess.AccessAppointmentInfoByID(appointmentID);
               

        }
        public static clsTestAppointmentDTO AccessTestAppointmentByApplicationID(int applicationID)
        {

            return clsAppointmentDataAcess.returnAppointmentByApplicationID(applicationID);
              
        }
        public static int AccessTotalTestAppointmentIsLockedByApplicationID(int applicationID)
        {
            return clsAppointmentDataAcess.returnTotalAppointmentIsLockedApplicationID(applicationID);
        }
        public static bool Save(clsTestAppointmentDTO testAppointmentDTO)
        {
            if (testAppointmentDTO.AppointmentID == -1)//new one
            {
                return AddNewAppointment(testAppointmentDTO);
            }
            else//updated
            {
                return UpdateAppointment(testAppointmentDTO);
            } 
        }
        public static async Task<DataTable> ReturnAppointmentsRelateToThisApplicationInfo(enTestType enTestType, int personID,int LicenseClassID)
        {
            
            return await clsAppointmentDataAcess.returnAppointmentsBasedOnApplicationInfo(enTestType,personID, LicenseClassID);
        }
        public static bool isExistsActivePerviousAppointmentSameTestType(enTestType enTestType,int baseApplicationID)
        {
            return clsAppointmentDataAcess.isExistsActivePerviousAppointmentSameTestType(enTestType,baseApplicationID);
        }
        public static bool isExistsFailedPerviousTestAppointment(enTestType enTestType, int baseApplicationID)
        {
            return clsAppointmentDataAcess.isExistsPerviousFailedTestAppointment(enTestType,baseApplicationID);
        }
        public static bool isExistsPassedPerviousTestAppointment(enTestType testType, int baseApplicationID)
        {
            return clsAppointmentDataAcess.isExistsPerviousPassedTestAppointment(testType,baseApplicationID);
        }

    }
}
