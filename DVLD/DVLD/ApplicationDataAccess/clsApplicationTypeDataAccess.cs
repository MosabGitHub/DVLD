using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionClassLibrary;
using DVLD.DTOs;
namespace ApplicationDataAccess
{
    public class clsApplicationTypeDataAccess
    {
        private static string ConnectionString = clsConnectionServer.connectionString;
       
        public static int addNewApplicationType(clsApplicationTypeDTO applicationTypeDTO )
        {

            {
                int newApplicationTypeID = -1;

                string Query = "INSERT INTO ApplicationTypes (Title,Fees) " +
                "VALUES (@titleVal,@feesVal); " +
                "SELECT SCOPE_IDENTITY();";

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@titleVal", applicationTypeDTO.Title);
                        Command.Parameters.AddWithValue("@feesVal", applicationTypeDTO.Fees);
                        try
                        {
                            Connection.Open();

                            object result = Command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int generatedID))
                            {
                                newApplicationTypeID = generatedID;
                            }

                        }
                        catch (Exception ex)
                        {
                            // Preserve the stack trace of the original exception
                            throw new Exception(ex.Message);
                        }

                    }
                    Connection.Close();
                }

                return newApplicationTypeID;

            }

        }

        public static bool UpdateApplicationTypeInfo(clsApplicationTypeDTO applicationTypeDTO)
        {
            //You can't update user ID . 


            bool IsUpdated = false;

            string Query = "UPDATE ApplicationTypes SET" +
            " Title=@titleVal," +
            " Fees=@feesVal" +
            " WHERE ID=@ID";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@ID", applicationTypeDTO.ID);
                    Command.Parameters.AddWithValue("@titleVal", applicationTypeDTO.Title);
                    Command.Parameters.AddWithValue("@feesVal", applicationTypeDTO.Fees);

                    try
                    {
                        Connection.Open();

                        int EffectedRows = Command.ExecuteNonQuery();
                        if (EffectedRows > 0)
                            IsUpdated = true;

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }
            return IsUpdated;
        }
        public async static Task<DataTable> GetAllApplicationTypesInfo()
        {

            string query = "SELECT * FROM ApplicationTypes;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Here, 'ex' is the original database-related exception
                        throw new Exception("Database operation failed.", ex);
                    }

                    finally
                    {
                        connection.Close();
                    }
                    return dt;
                }
            }



        }

        public static bool AccessApplicationTypeById(ref clsApplicationTypeDTO applicationTypeDTO )
        {
            bool isFound = false;
            string Query = "select * from ApplicationTypes where ID= @ID";

            if (applicationTypeDTO.ID == -1)
                throw new Exception("Application ID cannot be -1");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", applicationTypeDTO.ID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            applicationTypeDTO.ID = (int)reader["ID"];
                            applicationTypeDTO.Title= reader["Title"].ToString();
                            applicationTypeDTO.Fees = Convert.ToDouble( reader["Fees"]);

                            isFound = true;
                        }


                        reader.Close();
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    connection.Close();
                }
            }

            return isFound;
        }

        public static double returnApplicationFeesByID(int applicationTypeID)

        {
            double fees = 0.0;
            string Query = "select Fees from ApplicationTypes where ID= @IDParam";

            if (applicationTypeID == -1)
                throw new Exception("ApplicationType ID cannot be -1");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@IDParam", applicationTypeID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {                      
                            fees = Convert.ToDouble(reader["Fees"]);
                        }


                        reader.Close();
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    connection.Close();
                }
            }

            return fees;
        }
    }
}
