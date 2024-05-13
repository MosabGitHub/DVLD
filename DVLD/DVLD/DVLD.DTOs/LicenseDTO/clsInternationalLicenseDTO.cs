using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LicesnseDTO
{
    public class clsInternationalLicenseDTO
    {


        private int _internationalLicenseID=-1;
        private int _applicationID=-1;
        private int _driverID= -1;
        private int _issuedLocalLicenseID = -1;
        
        private clsInternationalLicenseSpec _internationalLicenseSpec=null;


        public clsInternationalLicenseDTO(int applicationId,int driverID,int issuedLocalLicenseID,clsInternationalLicenseSpec internationalLicenseSpec)
        {

            _applicationID= applicationId;
            _driverID = driverID;
            _issuedLocalLicenseID= issuedLocalLicenseID;
            _internationalLicenseSpec= internationalLicenseSpec;
        }
        public clsInternationalLicenseDTO(int internationalLicenseID,int applicationId, int driverID, int issuedLocalLicenseID, 
            clsInternationalLicenseSpec internationalLicenseSpec)
        {
            _internationalLicenseID = internationalLicenseID;
            _applicationID = applicationId;
            _driverID = driverID;
            _issuedLocalLicenseID = issuedLocalLicenseID;
            _internationalLicenseSpec = internationalLicenseSpec;
        }

        public int InternationalLicenseID { get { return _internationalLicenseID; } }

        public int ApplicationID { get { return _applicationID; } }
        public int DriverID { get { return _driverID; } }
        public int IssuedLocalLicenseID { get { return _issuedLocalLicenseID; } }
        public clsInternationalLicenseSpec InternationalLicenseSpec { get { return _internationalLicenseSpec; } }


    }
}
