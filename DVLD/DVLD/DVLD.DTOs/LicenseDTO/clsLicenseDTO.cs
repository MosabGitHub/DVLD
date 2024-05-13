using DVLD.DTOs.LicesnseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs
{
    public class clsLicenseDTO
    {

        private int _licenseID=-1;
        private int _applicationID;
        private int _licenseClassID;
        private int _driverID;
        private int _userCreatedByID;
        private clsLicenseSpec _licenseSpec;

        public clsLicenseDTO(int ApplicationID,int LicenseClassID,int DriverID,int UserCreatedByID, clsLicenseSpec LicenseSpec) { 
        
            this._applicationID = ApplicationID;
            this._licenseClassID = LicenseClassID;
            this._driverID= DriverID;
            this._userCreatedByID = UserCreatedByID;
            this._licenseSpec = LicenseSpec;
        }
        public clsLicenseDTO(int licenseId,int ApplicationID, int LicenseClassID, int DriverID, int UserCreatedByID, clsLicenseSpec LicenseSpec)
        {
            this._licenseID = licenseId;
            this._applicationID = ApplicationID;
            this._licenseClassID = LicenseClassID;
            this._driverID = DriverID;
            this._userCreatedByID = UserCreatedByID;
            this._licenseSpec = LicenseSpec;
        }

        public int LicenseID { get { return _licenseID; } }

        public int ApplicationID { get { return _applicationID; } }

        public int LicenseClassID {  get { return _licenseClassID; } }
        public clsLicenseSpec LicenseSpec { get {  return _licenseSpec; } }    

        public int DriverID { get { return _driverID; } }
    
        public int UsercreatedByID {  get { return _userCreatedByID; } }
    }
}
