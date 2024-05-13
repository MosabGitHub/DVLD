using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.DTOs
{
    public class clsLocalApplicationDTO
    {

        private clsApplicationDTO _baseApplicationDTO;
        private int _localApplicationID = -1;
        private int _licenseClassID = -1;
        public clsLocalApplicationDTO(int localApplicationID, clsApplicationDTO baseApplicationDTO , int licenseClassID)
        {

            this._localApplicationID = localApplicationID;
            this._baseApplicationDTO = baseApplicationDTO;
            this._licenseClassID = licenseClassID;

        }//Add new one , or update? 
        //Update or access
        public clsLocalApplicationDTO(int localApplicationID)
        {
            _localApplicationID = localApplicationID;
            
        }

        public clsApplicationDTO baseApplicationDTO { get { return _baseApplicationDTO; } }

        public int licenseClassID
        {
            set
            {
                if (_localApplicationID != -1)
                    _licenseClassID = value;
                else throw new Exception("You can't set licenseClassID for this localApplication while ID=-1");

            }
            get { return _licenseClassID; }
        }

        public int localApplicationID
        {
            set { _localApplicationID = value; }
            get { return _localApplicationID; }
        }
    }
    }