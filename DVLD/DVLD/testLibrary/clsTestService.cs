using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testDataAccess;
using DVLD.DTOs;
namespace testLibrary
{
    public static class clsTestTypeService
    {
        
            public static clsTestTypeDTO GetTestTypeByID(int applicationTypeId)
            {
                string title = "", description = "";
                double fees = 0.0;
                if (clsTestTypeDataAccess.AccessTestTypeById(applicationTypeId, ref title, ref description, ref fees))
                {
                    return new clsTestTypeDTO(applicationTypeId, title, description, fees);
                }

                else
                {
                    return null;
                }

            }
            public async static Task<DataTable> returnTestTypes()
            {
                return await clsTestTypeDataAccess.GetAllTestTypesInfo();
            }
            public static bool UpdateTestInfo(clsTestTypeDTO applicationTypeDTO)
            {
                return clsTestTypeDataAccess.UpdateTestTypeInfo(applicationTypeDTO.ID, applicationTypeDTO.Title, applicationTypeDTO.Description,
                    applicationTypeDTO.Fees);
            }

    }
    public static class clsTestService { 
        public  static bool addNewTest(clsTestDTO testDTO)
        {
            int newTestID= clsTestDataAccess.addNewTest(testDTO);
        
            return newTestID != -1;
        }

    }

    

}
