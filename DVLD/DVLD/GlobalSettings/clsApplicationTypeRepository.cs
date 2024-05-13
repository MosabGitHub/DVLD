using ConnectionClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSettings
{
    public static class clsApplicationTypeRepository
    {
        private static string ConnectionString = clsConnectionServer.connectionString;
        public static decimal GetApplicationFeesFromDataBaseByType(enApplicationType enApplicationType)
        {
            int applicationTypeId = (int)enApplicationType;
            decimal fees =0;
            string Query = "Select Fees from ApplicationTypes Where ID=@ApplicationTypeID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        fees = (decimal)result;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return fees;
        }
    
    
    }

}
