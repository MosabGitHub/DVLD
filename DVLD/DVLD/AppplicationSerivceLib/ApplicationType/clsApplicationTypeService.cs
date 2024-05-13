using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDataAccess;
using System.Data;
using DVLD.DTOs;
using static System.Net.Mime.MediaTypeNames;
namespace ApplicationServiceLib
{
    public class clsApplicationTypeService
    {
       

        public static clsApplicationTypeDTO GetApplicationTypeByID(int applicationTypeId)
        {

            clsApplicationTypeDTO applicationTypeDTO = new clsApplicationTypeDTO(applicationTypeId);//Empty.

            if (clsApplicationTypeDataAccess.AccessApplicationTypeById(ref applicationTypeDTO))
            {
                return applicationTypeDTO;
            }

            else
            {
                return null;
            }
        }

        public async static Task<DataTable> returnApplicationTypes()
        {
           return await clsApplicationTypeDataAccess.GetAllApplicationTypesInfo();
        }

        public static bool UpdateApplicationInfo(clsApplicationTypeDTO applicationTypeDTO)
        {
            return clsApplicationTypeDataAccess.UpdateApplicationTypeInfo(applicationTypeDTO);
        }
   


    }
}
