using DVLD.DTOs;
using DVLD.DTOs.LicesnseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.ctrls
{
    public class clsCustomEventArgs:EventArgs
    {

        public int PersonID { get; private set; }

        public clsLocalApplicationDTO LocalApplicationDTO { get; private set; }
        public clsInternationalLicenseDTO internationalLicenseDTO { get;private set; }
        public clsLicenseDTO  LicenseDTO{  get; private set; }
        public clsCustomEventArgs(int personID)
        {
            PersonID = personID;
        }
        public clsCustomEventArgs(clsLocalApplicationDTO localApplicationDTO)
        {
            this.LocalApplicationDTO = localApplicationDTO;
        }
        public clsCustomEventArgs(clsInternationalLicenseDTO internationalLicenseDTO)
        {
            this.internationalLicenseDTO = internationalLicenseDTO;
        }

        public clsCustomEventArgs(clsLicenseDTO licenseDTO)
        {
            this.LicenseDTO= licenseDTO;
        }

       
    }
}
