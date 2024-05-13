using PersonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.DriverDTO
{
    public class clsDriverDTO
    {
        private int _driverID;
        private clsPerson _personDTO ;
        private int _userCreatedBy;
        private DateTime _createdDate;
        

        public clsDriverDTO(clsPerson clsPerson,int UserCreatedByID,DateTime createdDate ) {

            this.DriverID = -1;
            this._personDTO = clsPerson;
            this._userCreatedBy= UserCreatedByID;
            this._createdDate= createdDate;

        }
        public clsDriverDTO(int driverID, clsPerson clsPerson, int UserCreatedByID, DateTime createdDate)
        {

            this.DriverID = driverID;
            this._personDTO = clsPerson;
            this._userCreatedBy = UserCreatedByID;
            this._createdDate = createdDate;

        }

        public int DriverID { internal set { _driverID = value; }   get { return _driverID; } }
        public clsPerson PersonDTO { get { return _personDTO; } }
        public int UserCreatedByID {  get { return _userCreatedBy; } }
        public DateTime CreatedDate { get { return _createdDate; } }


    }
}
