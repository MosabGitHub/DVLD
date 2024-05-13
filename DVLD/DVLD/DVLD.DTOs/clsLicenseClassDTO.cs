using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.DTOs
{
    public class clsLicenseClassDTO
    {

        public int classID;
        public string title;
        public string description;
        public int minAllowedAge;
        public int validityLength;
        public decimal classFees;


        public clsLicenseClassDTO(int classID, string title, string description, int minAge, int validityLength,
            decimal classFees)
        {

            this.classID = classID;
            this.title = title;
            this.description = description;
            this.minAllowedAge = minAge;
            this.validityLength = validityLength;
            this.classFees = classFees;

        }
        public clsLicenseClassDTO(int id )
        {
            
            this.classID = id;
            this.title = "";
            this.description = "";
            this.minAllowedAge = -1;
            this.validityLength = -1;
            this.classFees = -1;
        }
    }

}
