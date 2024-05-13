using ApplicationDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationServiceLib
{
    internal class clsApplicationType
    {
    
        private int _ID;
        private string _Title;
        private double _Fees;

        internal clsApplicationType(int ID, string Title, double Fees)
        {
            _ID = ID;
            _Title = Title;
            _Fees = Fees;

        }

        internal int ID { get { return _ID; } }
        internal string Title { get { return _Title; } }
        internal double Fees { get { return _Fees; } }


     
    }

}
   
