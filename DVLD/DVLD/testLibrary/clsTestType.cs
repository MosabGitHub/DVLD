using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testLibrary
{
    internal class clsTestType
    {
        private int _ID;

        private string _Title;
        private string _Description; 

        private double _Fees;
        internal clsTestType(int id, string title, string description, double fees)
        {
            _ID = id;
            _Title = title;
            _Description = description;
            _Fees = fees;
        }
        internal int ID
        {
            get { return _ID; }
        }
        internal string Title
        {
            get { return _Title; }
        }
        internal string Description
        {
            get { return _Description; }
        }
        internal double Fees
        {
            get { return _Fees; }
        }

    }

}
