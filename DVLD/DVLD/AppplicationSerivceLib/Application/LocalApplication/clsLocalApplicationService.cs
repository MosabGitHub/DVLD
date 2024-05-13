using DVLD.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDataAccess;
using System.Data;

namespace AppplicationSerivceLib
{
    public class clsLocalApplicationService
    {
        internal static clsLocalApplicationDTO accessLocalApplicationByID(int localApplicationID)
        {
        clsLocalApplicationDTO localApplicationDTO = new clsLocalApplicationDTO(localApplicationID);
        if (clsLocalApplicationDataAccess.AccessApplicationById(ref localApplicationDTO))
            return localApplicationDTO;
        else
            return null;
        }
        internal static bool deleteLocalApplication(List<int> applicationIDS)
        {
            return clsLocalApplicationDataAccess.deleteLocalApplicationInfo(applicationIDS);
        }
        internal static clsLocalApplicationDTO getApplicationLocalInfo(int localApplicationId)
        {
            clsLocalApplicationDTO localApplicationDTO = new clsLocalApplicationDTO(localApplicationId);
            if (clsLocalApplicationDataAccess.AccessApplicationById(ref localApplicationDTO))
                return localApplicationDTO;
            else
                return null;
        }
        internal static bool _addNewlocalApplication(clsLocalApplicationDTO localApplicationDTO)
        {
            int newLocalAppId = -1;
            newLocalAppId = clsLocalApplicationDataAccess.addNewLocalApplication(localApplicationDTO);


                return newLocalAppId != -1;

        }
        internal static bool _updateLocalApplication(clsLocalApplicationDTO localApplicationDTO)
        {
            return clsLocalApplicationDataAccess.UpdateApplicationInfo(localApplicationDTO);
        }
        internal static bool Save(clsLocalApplicationDTO localApplicationDTO)
        {
            switch (localApplicationDTO.localApplicationID)
            {


                case -1:
                    {
                        return _addNewlocalApplication(localApplicationDTO);

                    }
                default://Update since it ain't -1 ( not new).
                    {
                        return _updateLocalApplication(localApplicationDTO);
                    }
            }
        }
        internal async static Task<DataTable> returnLocalApplicationsInfo()
        {
            return await clsLocalApplicationDataAccess.GetAllLocalApplicationInfo();
        }
        internal static bool cancelLocalApplicationByID(List<int>selectedLocalApplicationIDs)
        {
            return clsLocalApplicationDataAccess.cancelApplicationByID(selectedLocalApplicationIDs);

        }
    }

}
