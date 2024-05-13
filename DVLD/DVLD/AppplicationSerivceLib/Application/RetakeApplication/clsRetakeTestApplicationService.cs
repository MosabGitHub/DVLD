using ApplicationDataAccess;
using DVLD.DTOs.ApplicationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationSerivceLib
{
    public class clsRetakeTestApplicationService
    {

        public static int Save(clsRetakeTestApplication retakeTestApplication)
        {
            return clsRetakeTestApplicationDataAccess.AddRetakeApplicationInfo(retakeTestApplication);
        }

    }
}
