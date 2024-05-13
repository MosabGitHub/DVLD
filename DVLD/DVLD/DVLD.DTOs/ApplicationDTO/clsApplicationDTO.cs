using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalSettings;

namespace DVLD.DTOs
{
    public class clsApplicationDTO
    {
      
        private int _applicationID=-1;
        private enApplicationType _applicationTypeID;
        private int _PersonID=-1;

        public DateTime applicationDate;
        public DateTime lastStatusDate;

        public enStatus enApplicationStatus ;
        public int UserCreatedByID = -1;
    
        public double Fees;
        public clsApplicationDTO(DateTime applicationDate, DateTime lastStatusDate, enApplicationType enApplicationType,
        enStatus applicationStatus, int personID, int userCreatedByID,double fees)
        {
            _applicationID = -1;
            this.applicationDate = applicationDate;
            this.lastStatusDate = lastStatusDate;
            this._applicationTypeID = enApplicationType;
            this.enApplicationStatus = applicationStatus;
            this._PersonID = personID;
            this.UserCreatedByID = userCreatedByID;
            this.Fees = fees;

        }//Add new one 
        public clsApplicationDTO(int appID,DateTime applicationDate, DateTime lastStatusDate, enApplicationType enApplicationType,
        enStatus applicationStatus, int personID, int userCreatedByID, double fees)
        {
            _applicationID = appID;
            this.applicationDate = applicationDate;
            this.lastStatusDate = lastStatusDate;
            this._applicationTypeID = enApplicationType;
            this.enApplicationStatus =  applicationStatus;
            this._PersonID = personID;
            this.UserCreatedByID = userCreatedByID;
            this.Fees = fees;

        }//Update and access current existed one
        public clsApplicationDTO()
        {

            this.applicationDate = DateTime.Now;
            this.lastStatusDate = DateTime.Now;
            this.applicationType =0;
            this.enApplicationStatus = enStatus.New;
            this.personID = -1;
            this.UserCreatedByID = -1;

            this.Fees = -1;
        }
        public clsApplicationDTO(int applicationID)
        {
            this._applicationID = applicationID;
            this.applicationDate = DateTime.Now;
            this.lastStatusDate = DateTime.Now;
            this.applicationType = 0;
            this.enApplicationStatus = enStatus.New;
            this.personID = -1;
            this.UserCreatedByID = -1;

            this.Fees = -1;
        }
        public enApplicationType applicationType
        {
            set 
                {
                    _applicationTypeID= value;
                }
            get 
            { 
                return  _applicationTypeID; 
            }
        }
        public int personID {
            set
            {
                if (_applicationID != -1)
                {
                    _PersonID = value;
                }
                else throw new Exception("You can't set ApplicationType for this application while ID=-1");
            }
            get { return _PersonID; } }
        public int applicationID { set { _applicationID = value; } get { return _applicationID; } }


    }

}
