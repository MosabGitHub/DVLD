using ConnectionClassLibrary;
using DVLD.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDataAccess
{
    public class clsTestDataAccess
    {
        private static string ConnectionString = clsConnectionServer.connectionString;

        public static int addNewTest(clsTestDTO testDTO)
        {

            {
                int newTestID = -1;

                string Query = "INSERT INTO Tests (" +
                               "[TestAppointmentID],[TestResult],[Notes],[CreatedByUserID]) " +
                               "VALUES " +
                               "(@TestAppointmentID," +
                               "@TestResult," +
                               "@Notes," +
                               "@CreatedByUserID) " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@TestAppointmentID", testDTO.TestAppointmentID);
                        Command.Parameters.AddWithValue("@TestResult",testDTO.TestResult);
                        Command.Parameters.AddWithValue("@Notes", testDTO.Notes);
                        Command.Parameters.AddWithValue("@CreatedByUserID", testDTO.UserCreatedByID);

                        try
                        {
                            Connection.Open();

                            object result = Command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int generatedID))
                            {
                                newTestID = generatedID;
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

                return newTestID;

            }

        }
    }
}
