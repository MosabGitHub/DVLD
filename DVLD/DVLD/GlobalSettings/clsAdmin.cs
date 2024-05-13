using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonClass;
using ConnectionClassLibrary;
namespace GlobalSettings
{
    
    public  class ClsAdmin
    {
        private static  clsPerson _person;

        private static string _UserName = "momen";
       
        private static string _Password = "123";

        public ClsAdmin(string userName="momen",string password="123")
        {
            _UserName = userName;
            _Password = password;
        }
        public static string userName{
            get { return "momen"; }
        }

        public static string psasword
        {
            get { return _Password; }
        }
        
        public static int personID
        {
            get
            {
                return _person.ID;
            }
        }
    }

    public static class Prices
    {
        private static decimal _RetakeTestPrice = 5;

        public static decimal RetakeTestPrice { get { return _RetakeTestPrice; } }
    }

}
