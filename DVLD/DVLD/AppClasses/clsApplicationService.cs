using ApplicationDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClasses
{
    internal class clsApplicationService
    {

        public static clsApplicationType GetApplicationTypeByID(int applicationTypeId)
        {
            string title = "";
            double fees = 0.0;
            if (clsApplicationDataAccess.AccessApplicationTypeById(applicationTypeId, ref title,ref fees))
            {
               return new clsApplicationType(applicationTypeId,title,fees);
            }
            else
            {
                return null;
            }
        }

    }
}
