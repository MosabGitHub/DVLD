using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClasses
{
    internal class clsApplicationType
    {

        private int _ID;
        private string _Title;
        private double _Fees;
        
        public clsApplicationType(int ID, string Title, double Fees)
        {
            _ID = ID;
            _Title = Title;
            _Fees = Fees;

        }
    
        public int ID { get { return _ID; } }
        public string Title { get { return _Title; } }
        public double Fees { get { return _Fees; } }

    }
}
