using _LicenseDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalSettings;
using DVLD.DTOs.LicenseDTO;
using DVLD.DTOs.LicenseDTO.Detained_ReleaseLicenses;
using System.Data;

namespace DetainLicenseServiceLib
{
    public static class clsDetainLicenseService
    {

        private static string _returnColumnNameBasedOnMode(enDetainLicenseListFilters enFilterDetainedLicense)
        {
            string filterColumn= "";

            switch (enFilterDetainedLicense)
            {
                case enDetainLicenseListFilters.DetainID:
                {
                    filterColumn= "DetainID";
                    break;
                }
                case enDetainLicenseListFilters.IsReleased:
                    {
                        filterColumn = "IsReleased";
                        break;
                    }
                case enDetainLicenseListFilters.NationalNo:
                    {
                        filterColumn = "NationalNumber";
                        break;
                    }
                case enDetainLicenseListFilters.FullName:
                    {
                        filterColumn = "FullName";
                        break;
                    }
                case enDetainLicenseListFilters.ReleaseApplicationID:
                    {
                        filterColumn = "ReleaseApplicationID";
                        break;
                    }
            }

            return filterColumn;

        }

        public static bool IsLicenseDetain(int licenseID)
        {
            return clsDetainedLicensesDataAccess.IsLicenseDetained(licenseID);
        }

        public static int Save(clsDetainedLicense DetainedLicense) { 
        
            return clsDetainedLicensesDataAccess.saveDetainedLicenseInfo(DetainedLicense);
        }

        public static clsDetainedLicense Find(int licenseID)
        {
            return clsDetainedLicensesDataAccess.AccessDetainedLicenseInfoByLicenseId(licenseID);
        }

        public static bool ReleaseDetainedLicense(clsReleaseSpec releaseSpec)
        {
            return clsDetainedLicensesDataAccess.ReleaseDetainedLicense(releaseSpec);
        }

        public static async Task<DataTable> GetAllDetainedLicensesInfo()
        {
            return await clsDetainedLicensesDataAccess.ReturnAllDetainedLicensesInfo();
        }

        public static async Task<DataTable>GetFilteredDetainedLicensesInfo(enDetainLicenseListFilters enFilter,string filterValue)
        {
            return await clsDetainedLicensesDataAccess.ReturnFilterDetainedLicensesInfo(_returnColumnNameBasedOnMode(enFilter), filterValue);

        }



    }
}
