using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ConnectionClassLibrary;
using DVLD.DTOs;
using GlobalSettings;
using static System.Net.Mime.MediaTypeNames;
namespace TestAppointmentDataAccessLib
{
    public class clsAppointmentDataAcess
    {
        public static string ConnectionString = clsConnectionServer.connectionString;
        public static clsTestAppointmentDTO AccessAppointmentInfoByID(int appointmentID)
        {
            clsTestAppointmentDTO testAppointmentDTO = null;
                string Query = "select * from TestAppointments where appointmentID= @IDparam";

            if (appointmentID <= 0)
                throw new ArgumentException("Application ID cannot be zero or below.");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@IDparam", appointmentID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            appointmentID = (int)reader["AppointmentID"];
                            int testTypeID = (int)reader["TestTypeID"];
                            int applicationID = (int)reader["ApplicationID"];
                            int personID = (int)reader["PersonID"];
                            DateTime appointmentDate = (DateTime)reader["AppointmentDate"];
                            decimal.TryParse( reader["Fees"].ToString(), out decimal fees);
                            DateTime dateOfApply = (DateTime)reader["DateOfApply"];
                            bool isLocked = (bool)reader["IsLocked"];

                             testAppointmentDTO = new clsTestAppointmentDTO(appointmentID,testTypeID, applicationID, personID, appointmentDate,
                                fees,dateOfApply, isLocked);
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

            return testAppointmentDTO;
        }
        public static int addNewTestAppointment(clsTestAppointmentDTO testAppointmentDTO)
        {

            int newtestAppointmentID = -1;

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                string query = "INSERT INTO TestAppointments  ( [TestTypeID],[ApplicationID]" +
                    ",[PersonID],[AppointmentDate],[Fees],[DateOfApply],[IsLocked]) VALUES (" +
                    "@TestTypeID,@ApplicationID,@PersonID,@AppointmentDate,@Fees,@DateOfApply,@IsLocked) " +
                    "select SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, Connection);
                //command.CommandType = CommandType.StoredProcedure;

                //SqlParameter outputIdParam = new SqlParameter("@newApplicationID", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output // Specify that this is an output parameter

                //};
                //command.Parameters.Add(outputIdParam);
                try
                {
                    command.Parameters.AddWithValue("@TestTypeID", testAppointmentDTO.TestTypeID);
                    command.Parameters.AddWithValue("@ApplicationID", testAppointmentDTO.ApplicationID);
                    command.Parameters.AddWithValue("@PersonID", testAppointmentDTO.PersonID);
                    command.Parameters.AddWithValue("@AppointmentDate", testAppointmentDTO.appointmentDate);
                    command.Parameters.AddWithValue("@Fees", testAppointmentDTO.fees);
                    command.Parameters.AddWithValue("@DateOfApply", testAppointmentDTO.DateOfApply);
                    command.Parameters.AddWithValue("@IsLocked", testAppointmentDTO.isLocked);


                    Connection.Open();

                   object result =command.ExecuteScalar();

                    if(result != null)
                    {
                        int.TryParse(result.ToString(), out newtestAppointmentID);
                    }
                     


                }
                catch (Exception ex)
                {
                    // Preserve the stack trace of the original exception
                    throw new Exception(ex.Message);
                }
                Connection.Close();

            }

                return newtestAppointmentID;
        }
        
        public static clsTestAppointmentDTO returnAppointmentByApplicationID(int applicationId)
        {

            string Query = "select * from TestAppointments where  ApplicationID = @appIDParam ;";

            if (applicationId <= 0)
                throw new ArgumentException("Application ID cannot be -1 or 0", nameof(applicationId));

            clsTestAppointmentDTO testAppointmentDTO = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@appIDParam", applicationId);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            int AppointmentID = (int)reader["AppointmentID"];
                            int testTypeID = (int)reader["TestTypeID"];
                            int applicationID= (int)reader["ApplicationID"];
                            int personID = (int)reader["PersonID"];
                            DateTime appointmentDate= (DateTime)reader["AppointmentDate"];
                            decimal fees = Convert.ToDecimal(reader["Fees"]);
                            DateTime dateOfApply= (DateTime)reader["DateOfApply"];
                            bool isLocked = (bool)reader["IsLocked"];
                            
                            testAppointmentDTO = new clsTestAppointmentDTO(AppointmentID,testTypeID, applicationID,personID,appointmentDate, 
                                fees, dateOfApply, isLocked);
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

            return testAppointmentDTO;
        }

        public static int returnTotalAppointmentIsLockedApplicationID(int applicationID)
        {
            int totalAppointments= 0;
            string Query = "select COUNT(*) from TestAppointments where ApplicationID=@appIDParam and IsLocked = 1 ";

            if (applicationID <= 0)
                throw new Exception("Application ID . cannot be -1 or 0");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@appIDParam", applicationID);

                    try
                    {connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null){
                        
                            int.TryParse(result.ToString(), out totalAppointments);
                        }
                        
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    connection.Close();
                }
            }

            return totalAppointments;
        }

        public static async Task<DataTable> returnAppointmentsBasedOnApplicationInfo(enTestType enTestType,int PersonID,int LicenseClassID)
        {
            

            string query = "select AppointmentID,AppointmentDate,TestAppointments.Fees as [Is paid], IsLocked from TestAppointments " +
                " INNER JOIN  LocalDrivingLicenseApplications ON TestAppointments.ApplicationID= LocalDrivingLicenseApplications.LocalApplicationID" +
                " inner join Applications on Applications.ID=LocalDrivingLicenseApplications.ApplicationID" +
                " where Applications.personID=@PersonID and TestTypeID= @TestTypeId and  LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@TestTypeId", enTestType);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
        public async static Task<DataTable> GetAllApplicationInfo()
        {

            string query = "select  Applications.ID, " +
                "LicenseClasses.Title  AS DrivingClass," +
                "People.NationalNumber AS NationalNo," +
                "( People.FirstName+ ' '+ People.SecondName+ ' ' + People.ThirdName + ' ' + People.LastName ) AS FullName," +
                "Applications.Date," +
                "Applications.PassedTests," +
                "ApplicationStatues.Name as Status from Applications " +
                "inner join  ApplicationStatues ON Applications.ApplicationStatusID= ApplicationStatues.ID " +
                "inner join  LicenseClasses ON Applications.LicenseClassID= LicenseClasses.ClassID " +
                "inner join People ON Applications.PersonID= People.ID;";

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
        public static bool UpdateApplicationInfo(clsTestAppointmentDTO testAppointmentDTO)
        {
            bool isUpdated = false;
            
            string query = "Update [TestAppointments] " +
                "SET " +
                "[TestTypeID]=@TestTypeID," +
                "[ApplicationID]=@ApplicationID," +
                "[PersonID]=@PersonID," +
                "[AppointmentDate]=@AppointmentDate," +
                "[Fees]=@Fees," +
                "[DateOfApply]=@DateOfApply," +
                "[IsLocked]=@IsLocked "  +
                "WHERE AppointmentID=@IDParam;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDParam", testAppointmentDTO.AppointmentID);
                    command.Parameters.AddWithValue("@TestTypeID", testAppointmentDTO.TestTypeID);
                    command.Parameters.AddWithValue("@ApplicationID", testAppointmentDTO.ApplicationID);
                    command.Parameters.AddWithValue("@PersonID", testAppointmentDTO.PersonID);
                    command.Parameters.AddWithValue("@AppointmentDate", testAppointmentDTO.appointmentDate);
                    command.Parameters.AddWithValue("@Fees", testAppointmentDTO.fees);
                    command.Parameters.AddWithValue("@DateOfApply", testAppointmentDTO.DateOfApply);
                    command.Parameters.AddWithValue("@IsLocked", testAppointmentDTO.isLocked);
                   
                    try
                    {
                        connection.Open();

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            isUpdated = true;
                        }


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
                }

            }
            return isUpdated;

        }

        public static bool isExistsActivePerviousAppointmentSameTestType(enTestType enTestType,int baseApplicationID)
        {
            bool isExists=false;
            int testTypeId = (int)enTestType;

            string Query = "select  COUNT(*)  [Active Test Appointments for the same test appointment] from TestAppointments " +
                          "where ApplicationID =@baseAppIDParam and IsLocked=0 and TestTypeID=@TestID";//Is Active.

            using (SqlConnection connection =new SqlConnection(ConnectionString))
            {
                using (SqlCommand command =new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@baseAppIDParam", baseApplicationID);
                    command.Parameters.AddWithValue("@TestID", testTypeId);

                    try
                    {
                        connection.Open();

                        int result = (int)command.ExecuteScalar();
                        if (result >=1)
                        {
                            isExists = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Here, 'ex' is the original database-related exception
                        throw new Exception("Database operation failed to check " +
                            "\nweather there is a previous active appointment or not..", ex);
                    }

                    finally
                    {
                        connection.Close();
                    }
                }

            }
            return isExists;
        }
            
        public static bool isExistsPerviousFailedTestAppointment(enTestType enTestType, int baseApplicationID)
        {
            bool isExists = false;
            int testTypeId = (int)enTestType;

            string Query = "select  COUNT(*)[Unpassed test]  from TestAppointments " +
                "inner join Tests On TestAppointments.AppointmentID=Tests.TestAppointmentID " +
                "where ApplicationID =@BaseAppIDParam and IsLocked=1  and TestResult=0 and TestTypeID=@testTypeId;";//Is Active.

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@BaseAppIDParam", baseApplicationID);
                    command.Parameters.AddWithValue("@testTypeId", testTypeId);

                    try
                    {
                        connection.Open();

                        int result = (int)command.ExecuteScalar();
                        if (result >= 1)
                        {
                            isExists = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Here, 'ex' is the original database-related exception
                        throw new Exception("Database operation failed to check " +
                            "\nweather there is a previous failed test appointment or not..", ex);
                    }

                    finally
                    {
                        connection.Close();
                    }
                }

            }
            return isExists;
        }

        public static bool isExistsPerviousPassedTestAppointment(enTestType enTestType,int baseApplicationID)
        {
            bool isExists = false;
            int testTypeId = (int)enTestType;

            string Query = "select  COUNT(*)[passed test]  from TestAppointments " +
                "inner join Tests On TestAppointments.AppointmentID=Tests.TestAppointmentID " +
                "where ApplicationID =@BaseAppIDParam and IsLocked=1  and TestResult=1 and TestTypeID=@testTypeId;";//Is passed.

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@BaseAppIDParam", baseApplicationID);
                    command.Parameters.AddWithValue("@testTypeId", (int)enTestType);

                    try
                    {
                        connection.Open();

                        int result = (int)command.ExecuteScalar();
                        if (result >= 1)
                        {
                            isExists = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Here, 'ex' is the original database-related exception
                        throw new Exception("Database operation failed to check " +
                            "\nweather there is a previous passed test appointment or not..", ex);
                    }

                    finally
                    {
                        connection.Close();
                    }
                }

            }
            return isExists;
        }
    }
}

