using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs
{
    public class clsTestTypeDTO
    {
        public int ID { get; }
        public string Title { get; }
        public string Description { get; }

        public double Fees { get; }

        public clsTestTypeDTO(int id, string title, string description, double fees)
        {
            ID = id;
            Title = title;
            Description = description;
            Fees = fees;
        }

    }
}
