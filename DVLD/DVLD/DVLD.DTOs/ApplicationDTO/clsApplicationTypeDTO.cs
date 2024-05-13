using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs
{
    public class clsApplicationTypeDTO
    {
        public int ID;
        public string Title;
        public double Fees;

        public clsApplicationTypeDTO(int id, string title, double fees)
        {
            ID = id;
            Title = title;
            Fees = fees;
        }
        public clsApplicationTypeDTO(int id)
        {
            ID = id;
            Title = "";
            Fees = -1;
        }
    }
    
}
