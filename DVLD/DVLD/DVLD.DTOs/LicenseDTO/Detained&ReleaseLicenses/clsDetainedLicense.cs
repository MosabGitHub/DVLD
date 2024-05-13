using DVLD.DTOs.LicesnseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LicenseDTO
{
    public class clsDetainedLicense
    {
        
        private int _detainID;
        private int _licenseID;
        private int? _releaseApplicationId;
        private clsDetainedLicenseSpec _detainSpec;
        public clsDetainedLicense(int detainID, int licenseID, clsDetainedLicenseSpec detainSpec, int? releaseApplicationId=null )
        {
            _detainID = detainID;
            _licenseID = licenseID;
            _releaseApplicationId = releaseApplicationId;
            _detainSpec = detainSpec;
        }
        public clsDetainedLicense( int licenseID, clsDetainedLicenseSpec detainSpec ,int? releaseApplicationId= null)
        {
            _detainID = -1;
            _licenseID = licenseID;
            _releaseApplicationId = releaseApplicationId;
            _detainSpec = detainSpec;
        }
        public clsDetainedLicense(int licenseID,  clsDetainedLicenseSpec detainSpec)
        {
            _detainID = -1;
            _licenseID = licenseID;
            _releaseApplicationId = -1;
            _detainSpec = detainSpec;
        }

        public int DetainID
        {
            get { return _detainID; }
        }
        public int LicenseID
        {
            get { return _licenseID; }
        }
        public int? ReleaseApplicationID
        {
            get { return _releaseApplicationId; }
        }
        public clsDetainedLicenseSpec DetainSpec
        {
            get { return _detainSpec; }
        }

    }
}
