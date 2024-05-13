using GlobalSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.ApplicationDTO
{
    public class clsRetakeTestApplication
    {
        private int _retakeTestApplicationID;
        private clsLocalApplicationDTO _localApplicationDTO;
        private enTestType _enTestType;
        public clsRetakeTestApplication(int retakeTestApplicationID, clsLocalApplicationDTO localApplicationDTO, enTestType enTestType)
        {
            _retakeTestApplicationID = retakeTestApplicationID;
            _localApplicationDTO = localApplicationDTO;
            _enTestType = enTestType;
        }
        public clsRetakeTestApplication( clsLocalApplicationDTO localApplicationDTO, enTestType enTestType)
        {
            _retakeTestApplicationID = -1;
            _localApplicationDTO = localApplicationDTO;
            _enTestType = enTestType;
        }
        public int RetakeTestApplicationID { get {  return _retakeTestApplicationID; } }

        public clsLocalApplicationDTO LocalApplicationDTO { get {  return _localApplicationDTO; } }

        public enTestType enTestType { get { return _enTestType; } }


    }
}
