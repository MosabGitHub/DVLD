using _LicenseDataAccess;
using DVLD.DTOs;
using DVLD.DTOs.LicesnseDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalSettings;
namespace LicensesServiceLib
{
    public static class clsLicenseClassService
    {
      
        public async static Task<DataTable> getAllLicenseClassesInfo()
        {
            return await clsLicesnseClassDataAccess.GetAllLicenseClassesInfo();
        }

        public async static Task<DataTable> getIdTitleLicenseClassesInfo()
        {
            return await clsLicesnseClassDataAccess.GetAllLicenseClassesIDAndTitle();
        }

        public static clsLicenseClassDTO Find(int licenseClassId)
        {
            return  clsLicesnseClassDataAccess.AccessLicenseClassById(licenseClassId);

        }

        public static clsLicenseClassDTO Find(enLicenseClass enLicenseClass)
        {
            return clsLicesnseClassDataAccess.AccessLicenseClassByEnumLicenseClass(enLicenseClass);
        }


    }

    public static class clsLicenseService
    {

        private static int _addNewLicense(clsLicenseDTO licenseDTO)
        {
           int newLicenseID= clsLicenseDataAccess.AddNewLicense(licenseDTO);
           return newLicenseID;
        }
        public static int Save(clsLicenseDTO licenseDTO)
        {

            //if (licenseDTO.LicenseClassID == -1)
            //{
                return _addNewLicense(licenseDTO);
            //}
        }
        public static clsLicenseDTO FindAppInfo(int baseApplicationID)
        {
            return clsLicenseDataAccess.AccessLicenseByAppInfo(baseApplicationID);
        }
        public static clsLicenseDTO Find(int licenseID)
        {
            return clsLicenseDataAccess.AccessLicenseByID(licenseID);
        }
        public static bool IsLicenseActive(int licenseID)
        {
            return clsLicenseDataAccess.IsLicenseActive(licenseID);
        }
        public static bool isDriverOwnSameActiveLicenseClassID(int driverID,int licenseClassID)
        {
            return clsLicenseDataAccess.isExists(driverID, licenseClassID);
        }

        public static bool IsDriverOwnSameClassLicense(int personID,int licenseClassID)
        {
            return clsLicenseDataAccess.IsLicenseOwnSameClassLicenseByPersonID(personID, licenseClassID);

        }
        public async static Task<DataTable> FindAllLocalLicensesByDriverID(int driverId)
        {
            return await clsLicenseDataAccess.GetAllLocalDriverLicenseInfo(driverId);
        }
        public async static Task<DataTable> FindAllInternationalLicensesByDriverID(int driverId)
        {
            return await clsLicenseDataAccess.GetAllInternationalDriverLicenseInfo(driverId);
        }

        public static int getPersonIDByLicenseID(int licenseID)
        {
            return clsLicenseDataAccess.GetPersonIDByLicenseId(licenseID);
        }

        public static bool DeactivateLicense(int licenseID) {

            return clsLicenseDataAccess.DeactivateLicenseInfoByID(licenseID);
        }
        public static bool ActivateLicense(int licenseID)
        {

            return clsLicenseDataAccess.ActivateLicenseInfoByID(licenseID);
        }

    }
    public static class clsInternationalLicenseService
    {
        private static int _addNewInternationalLicense(clsInternationalLicenseDTO internationalLicenseDTO)
        {
            int newInternationalLicenseID = clsInternationalLicenseDataAccess.AddNewInternationalLicense(internationalLicenseDTO);
            return newInternationalLicenseID;
        }

        public static int Save(clsInternationalLicenseDTO internationalLicenseDTO)
        {

            if (internationalLicenseDTO.InternationalLicenseID == -1)
            {


                return _addNewInternationalLicense(internationalLicenseDTO);
            }
            else
                return -1; //in case you wanted to update.
        }

        public static  async Task<DataTable> GetAllInternationalDrivingLicenseApplications()
        {
            return await clsInternationalLicenseDataAccess.GetAllInternationalDrivingLicenseApplicationInfo();
        }
        public static async Task<DataTable> GetAllInternationalDrivingLicenseApplicationsByInternationalLicenseID(int internationalLicenseID)
        {
            return await clsInternationalLicenseDataAccess.GetAllInternationalDrivingLicenAppInfoByIntLicenID(internationalLicenseID);

        }
        public static async Task<DataTable> GetAllInternationalDrivingLicenAppByIntAppID(int internationalApplicationID)
        {
            return await clsInternationalLicenseDataAccess.GetAllInternationalDrivingLicenAppInfoByIntAppID(internationalApplicationID);

        }
        public static async Task<DataTable> GetAllInternationalDrivingLicenAppByDriverID(int driverID)
        {
            return await clsInternationalLicenseDataAccess.GetAllInternationalDrivingLicenAppInfoByDriverID(driverID);

        }

        public static async Task<DataTable> GetAllActiveInternationalDrivingLicenAppByActive(bool isActive)
        {
            return await clsInternationalLicenseDataAccess.GetAllInternationalDrivingLicenAppInfoByActive(isActive);

        }
        public static clsInternationalLicenseDTO Find(int internationalLicenseID)
        {
            return clsInternationalLicenseDataAccess.AccessInternationalLicenseByID(internationalLicenseID);
        }
    }

}
