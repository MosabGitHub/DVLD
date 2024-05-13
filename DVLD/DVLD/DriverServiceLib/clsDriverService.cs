using _LicenseDataAccess;
using DVLD.DTOs.DriverDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverServiceLib
{
    public static class clsDriverService
    {
        private static bool _AddNewDriver(clsDriverDTO driverDTO)
        {
            return clsDriverDataAccess.AddNewDriver(driverDTO)!=-1;    

        }
        public static bool Save(clsDriverDTO driverDTO)
        {
            if(driverDTO == null)
                return false;

            else if (driverDTO.DriverID == -1)
            {
                return _AddNewDriver(driverDTO);
            }
            else
            {
                //Update logic.
                return false; 
            }
        }

        public static clsDriverDTO Find(int DriverID)
        {
            return clsDriverDataAccess.AccessDriverByDriverId(DriverID);
        }
        public async static Task<DataTable> Find()
        {
            return await clsDriverDataAccess.GetAllDriversInfo();
        }

        public async static Task<DataTable> getDriversInfoByID(int driverID)
        {
            return await clsDriverDataAccess.GetAllDriversInfoByID(driverID);

        }
        public async static Task<DataTable> getDriversInfoByPersonID(int personID)
        {
            return await clsDriverDataAccess.GetAllDriversInfoByPersonID(personID);

        }
        public async static Task<DataTable> getDriversInfoByNationalNo(string nationalNo)
        {
            return await clsDriverDataAccess.GetAllDriversInfoByNationalNo(nationalNo);

        }
        public async static Task<DataTable> getDriversInfoByFullName(string nationalNo)
        {
            return await clsDriverDataAccess.GetAllDriversInfoByFullName(nationalNo);

        }

        public static clsDriverDTO FindByPersonID(int personID) {

            return clsDriverDataAccess.AccessDriverByPersonId(personID);

        }

        public static bool isExists(int personID)
        {
            return clsDriverDataAccess.isExists(personID);
        }
    }
}
