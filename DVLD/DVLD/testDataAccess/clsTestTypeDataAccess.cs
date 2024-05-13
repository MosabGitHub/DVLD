using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionClassLibrary;
namespace testDataAccess
{
    public class clsTestTypeDataAccess
    {
        readonly static string  ConnectionString = clsConnectionServer.connectionString;

        public static int addNewTestType(string title,string description, double fees)
        {

            {
                int newTestTypeID = -1;

                string Query = "INSERT INTO TestTypes (Title,Description,Fees) " +
                "VALUES (@titleVal,@DescriptionVal,@feesVal); " +
                "SELECT SCOPE_IDENTITY();";

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@titleVal", title);
                        Command.Parameters.AddWithValue("@DescriptionVal", description);
                        Command.Parameters.AddWithValue("@feesVal", fees);

                        try
                        {
                            Connection.Open();

                            object result = Command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int generatedID))
                            {
                                newTestTypeID = generatedID;
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

                return newTestTypeID;

            }

        }
        public static bool UpdateTestTypeInfo(int applicationTypeId, string title, string description, double fees)
        {
            //You can't update user ID . 


            bool IsUpdated = false;
            

            string Query = "UPDATE TestTypes SET" +
            " Title=@titleVal," +
            " Fees=@feesVal," +
            "Description=@descriptionVal" +
            " WHERE ID=@ID";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@ID", applicationTypeId);
                    Command.Parameters.AddWithValue("@titleVal", title);
                    Command.Parameters.AddWithValue("@descriptionVal", description);

                    Command.Parameters.AddWithValue("@feesVal", fees);

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
        public async static Task<DataTable> GetAllTestTypesInfo()
        {

            string query = "SELECT * FROM TestTypes;";
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

        public static bool AccessTestTypeById(int id, ref string title, ref string description ,ref double fees)
        {
            bool isFound = false;
            string Query = "select * from TestTypes where ID= @ID";

            if (id == -1)
                throw new Exception("TestType ID cannot be -1");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            id = (int)reader["ID"];
                            title = reader["Title"].ToString();
                            title = reader["Title"].ToString();
                            description = reader["Description"].ToString();
                            fees = Convert.ToDouble(reader["Fees"]);

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


    }

}
