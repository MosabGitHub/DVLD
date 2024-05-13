using ApplicationDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DTOs;
using static System.Net.Mime.MediaTypeNames;
using System.Security.AccessControl;
using AppplicationSerivceLib;
using System.Security.Cryptography.X509Certificates;
using GlobalSettings;

namespace AppplicationSerivceLib
{
    public class clsApplicationService
    {

        public class clsSearchForApplication
        {
            public async static Task<DataTable> getAllApplicationByID(int applicationID)
            {
                string columnName = "LocalApplicationID";
                return await clsLocalApplicationDataAccess.GetAllApplicationsInfoByFilter(columnName, applicationID.ToString());
            }
            public async static Task<DataTable> getAllApplicationByPersonNationalNo(string nationalNo)
            {
                string columnName = "NationalNumber";
                return await clsLocalApplicationDataAccess.GetAllApplicationsInfoByFilter(columnName, nationalNo);
            }
            public async static Task<DataTable> GetAllApplicationByFullName(string fullName)
            {
                string columnName = "FullName";
                return await clsLocalApplicationDataAccess.GetAllApplicationsInfoByFilter(columnName, fullName);
            }
            public async static Task<DataTable> GetAllApplicationByStatusID(int statusID)
            {
                string columnName = "ApplicationStatusID";
                return await clsLocalApplicationDataAccess.GetAllApplicationsInfoByFilter(columnName, statusID.ToString());

            }
            public static clsApplicationDTO GetBaseApplicationByID(int ApplicationId)
            {
                clsApplicationDTO ApplicationDTO = new clsApplicationDTO(ApplicationId);
                if (clsApplicationDataAccess.accessBaseApplicationByID(ApplicationDTO))
                {
                    return ApplicationDTO;
                }

                else
                {
                    return null;
                }

            }
            public static clsApplicationDTO GetRetakeApplicationByID(int personID)
            {
                return clsApplicationDataAccess.accessBaseApplicationByPersonID(personID);
              
            }
            public static string getStatusTitleBaseByApplicationID(clsLocalApplicationDTO localapplicationDTO)
            {

                return clsApplicationDataAccess.accessStatusTitleByStatusID(localapplicationDTO);
            }
            public static float getTotalPassedTestsByBaseApplicationID(clsLocalApplicationDTO localApplicationDTO)
            {
                return clsApplicationDataAccess.accessPassedTestLocalApplicationByBaseApplicationID(localApplicationDTO.localApplicationID);
            }

        }       
        public static int SaveInternationalLocalApplicationInfo(clsApplicationDTO applicationDTO)
        {
            return clsApplicationDataAccess.AddNewBaseApplication(applicationDTO);

        }
        public static int SaveApplicationInfo(clsApplicationDTO ApplicationDTO)
        {
            return clsApplicationDataAccess.AddNewBaseApplication(ApplicationDTO);

        }
        public static int SaveRetakeApplicationInfo(clsApplicationDTO ApplicationDTO,clsLocalApplicationDTO localApplicationDTO)
        {
            int newRetakeApplicationID= SaveApplicationInfo(ApplicationDTO);
          
            //connect retake app with local app.
            clsLocalApplicationDataAccess.addNewLocalApplication(new clsLocalApplicationDTO(localApplicationDTO.localApplicationID,
               clsSearchForApplication.GetBaseApplicationByID(newRetakeApplicationID),localApplicationDTO.licenseClassID));

            return newRetakeApplicationID;

        }


        public static bool DeleteBaseApplicationInfo(int applicationID)
        {
            return clsApplicationDataAccess.DeleteApplicationInfo(applicationID);
        }
        public static Task<DataTable> returnLocalApplicationsInfo()
        {
            return clsLocalApplicationService.returnLocalApplicationsInfo();
        }
        public static bool SaveLocalApplicationInfo(clsLocalApplicationDTO localApplicationDTO)
        {
            return clsLocalApplicationService.Save(localApplicationDTO);
        }
        public static bool deleteLocalApplication(List<int> selectedLocalApplicationIDs)
        {
          return   clsLocalApplicationService.deleteLocalApplication(selectedLocalApplicationIDs);
        }
        public static clsLocalApplicationDTO getLocalApplicationInfoByLocalAppID(int localApplicationId)
        {
            return clsLocalApplicationService.accessLocalApplicationByID(localApplicationId);
        }
        public static clsLocalApplicationDTO FindLocalAppByAppointmentID(int appointmentID)
        {
            return clsLocalApplicationDataAccess.AccessApplicationByAppointmentID(appointmentID);
        }
        public static bool cancelLocalApplication(List<int> selectedLocalApplicationIDs)
        {
            return clsLocalApplicationService.cancelLocalApplicationByID(selectedLocalApplicationIDs);
        }
        public static bool CompleteLocalApplication(int localApplicationID)
        {
            return clsLocalApplicationDataAccess.completeApplicationByID(localApplicationID);
        }
        public static bool isExists(int applicationID)
        {
            return clsApplicationDataAccess.isExists(applicationID);
        }
      

    

    }

}

