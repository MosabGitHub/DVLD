using ConnectionClassLibrary;
using DVLD.DTOs;
using DVLD.DTOs.ApplicationDTO;
using GlobalSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDataAccess
{
    public static  class clsApplicationDataAccess

    {
        public static string ConnectionString = clsConnectionServer.connectionString;
        public static float accessPassedTestLocalApplicationByBaseApplicationID(int localApplicationID)

            {

                float totalPassedTests= -1;
                 string Query = "SELECT  COUNT(*) [passed tests] FROM TestAppointments" +
                                " INNER JOIN Tests ON TestAppointments.AppointmentID = Tests.TestAppointmentID " +
                                " INNER JOIN LocalDrivingLicenseApplications ON TestAppointments.ApplicationID=LocalDrivingLicenseApplications.LocalApplicationID" +
                                " where LocalDrivingLicenseApplications.LocalApplicationID=@LocalApplicationID and Tests.TestResult=1;";

                if (localApplicationID <= 0)
                    throw new Exception("Application ID cannot be Zero or below.");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@LocalApplicationID", localApplicationID);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                float.TryParse(result.ToString(), out totalPassedTests);
                            }


                        }


                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                        connection.Close();
                    }
                }

                return totalPassedTests;
            }
        public static bool isExists(int applicationID)
            {
                bool IsFound = false;

                string Query = "SELECT ID FROM Applications WHERE ID =@IDParam ";

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@IDParam", applicationID);

                        try
                        {
                            Connection.Open();

                            object result = Command.ExecuteScalar();

                            if (result != null)
                            {
                                IsFound = true;
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }

                return IsFound;
            }
        public static bool accessBaseApplicationByID(clsApplicationDTO applicationDTO)
        {

            

                bool isFound = false;

                string Query = "SELECT * FROM Applications WHERE ID= @IDparam";

                if (applicationDTO.applicationID<= 0)
                    throw new Exception("Application ID cannot be Zero or below.");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@IDparam", applicationDTO.applicationID);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                  
                                //Base Application info
                                int applicationID = (int)reader["ID"];
                                DateTime applicationDate = (DateTime)reader["Date"];
                                enApplicationType applicationType = (enApplicationType)reader["ApplicationTypeID"];
                                DateTime lastStatusDate = (DateTime)reader["lastStatusDate"];
                                enStatus enStatus = (enStatus)(reader["ApplicationStatusID"]);
                                int personID = (int)reader["PersonID"];
                                int userCreatedByID = (int)reader["UserCreatedByID"];
                                double fees = Convert.ToDouble(reader["Fees"]);

                                   applicationDTO = new clsApplicationDTO(applicationID, applicationDate,
                                    lastStatusDate, applicationType, enStatus, personID, userCreatedByID, fees);

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
        public static clsApplicationDTO accessBaseApplicationByPersonID(int personID)
        {
            clsApplicationDTO applicationDTO = null;
            enApplicationType enApplicationType = enApplicationType.RetakeTest;
            enStatus enApplicationStatus = enStatus.New;
            string Query = "SELECT * FROM Applications WHERE PersonID= @PersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatusID=@ApplicationStatusID";

            if (personID <= 0)
                throw new Exception("personID ID cannot be Zero or below.");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", enApplicationType);
                    command.Parameters.AddWithValue("@ApplicationStatusID", enApplicationStatus);



                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            //Base Application info
                            int applicationID = (int)reader["ID"];
                            DateTime applicationDate = (DateTime)reader["Date"];
                            enApplicationType applicationType = (enApplicationType)reader["ApplicationTypeID"];
                            DateTime lastStatusDate = (DateTime)reader["lastStatusDate"];
                            enStatus enStatus = (enStatus)(reader["ApplicationStatusID"]);
                             personID = (int)reader["PersonID"];
                            int userCreatedByID = (int)reader["UserCreatedByID"];
                            double fees = Convert.ToDouble(reader["Fees"]);

                            applicationDTO = new clsApplicationDTO(applicationID, applicationDate,
                             lastStatusDate, applicationType, enStatus, personID, userCreatedByID, fees);

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

            return applicationDTO;
        }

        public static string accessStatusTitleByStatusID(clsLocalApplicationDTO localApplicationDTO)
        {
            string title = "Empty";
         
            string Query = "SELECT Name FROM  Applications A " +
                "INNER JOIN ApplicationStatues  ON A.ApplicationStatusID = ApplicationStatues.ID " +
                "where A.ID=@IDparam";

            if (localApplicationDTO.baseApplicationDTO.applicationID <= 0)
                throw new Exception("Application ID cannot be Zero or below.");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@IDparam", localApplicationDTO.baseApplicationDTO.applicationID);

                    try
                    {
                        connection.Open();
                        object result =command.ExecuteScalar();
                        if (result!=null)
                        {
                            title=result.ToString();

                        }


                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    connection.Close();
                }
            }
               
            return title; 
        }
        
        public static int  AddNewBaseApplication(clsApplicationDTO baseApplicationDTO)
        {
            int newBaseApplicationID = -1;
            string Query = "INSERT INTO [Applications] " +
                           "([Date]," +
                           "[LastStatusDate]" +
                           ",[ApplicationTypeID]" +
                           ",[ApplicationStatusID]" +
                           ",[PersonID]" +
                           ",[UserCreatedByID]" +
                           ",[Fees])" +
                           "VALUES " +
                           "(@Date,@LastStatusDate,@ApplicationTypeID,@ApplicationStatusID,@PersonID,@UserCreatedByID,@Fees) " +
                           "select SCOPE_IDENTITY();";
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {

                    command.Parameters.AddWithValue("@Date", baseApplicationDTO.applicationDate);
                    command.Parameters.AddWithValue("@LastStatusDate", baseApplicationDTO.lastStatusDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", baseApplicationDTO.applicationType);
                    command.Parameters.AddWithValue("@ApplicationStatusID", (int)baseApplicationDTO.enApplicationStatus);
                    command.Parameters.AddWithValue("@PersonID", baseApplicationDTO.personID);
                    command.Parameters.AddWithValue("@UserCreatedByID", baseApplicationDTO.UserCreatedByID);
                    command.Parameters.AddWithValue("@Fees", baseApplicationDTO.Fees);

                    try
                    {
                        Connection.Open();

                        object result = command.ExecuteScalar();

                        int.TryParse(result.ToString(), out newBaseApplicationID);


                    }
                    catch (Exception ex)
                    {
                        // Preserve the stack trace of the original exception
                        throw new Exception(ex.Message);
                    }

                }
                Connection.Close();
            }

            return newBaseApplicationID;
        }
        public static bool DeleteApplicationInfo(int applicationID)
        {
            string Query = "DELETE FROM [dbo].[Applications] WHERE Applications.ApplicationID=@ApplicationID;";
            bool IsDeleted = false;

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    try
                    {
                        Connection.Open();

                        int EffectedRows = command.ExecuteNonQuery();
                        if (EffectedRows > 0)
                            IsDeleted = true;
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(Query, ex);

                    }

                    Connection.Close();
                }
            }

            return IsDeleted;
        }

    }
    public static class clsLocalApplicationDataAccess
    {
        public static string ConnectionString = clsConnectionServer.connectionString;
        public static bool AccessApplicationById(ref clsLocalApplicationDTO localApplicationDTO)
        {

            bool isFound = false;

            string Query = "SELECT LocalDrivingLicenseApplications.LocalApplicationID," +
                " LocalDrivingLicenseApplications.LicenseClassID," +
                " Applications.Date, " +
                "Applications.ID ApplicationID, " +
                " Applications.ApplicationTypeID," +
                " Applications.LastStatusDate," +
                " Applications.ApplicationStatusID," +
                " Applications.PersonID," +
                " Applications.UserCreatedByID," +
                " Applications.Fees " +
                "FROM Applications " +
                "INNER JOIN  LocalDrivingLicenseApplications ON Applications.ID = LocalDrivingLicenseApplications.ApplicationID " +
                "WHERE LocalApplicationID= @IDparam";

            if (localApplicationDTO.localApplicationID <= 0)
                throw new Exception("Application ID cannot be Zero or below.");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@IDparam", localApplicationDTO.localApplicationID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            //local Application info.
                            int licenseClassID = (int)reader["LicenseClassID"];

                            //Base Application info
                            int applicationID = (int)reader["ApplicationID"];
                            DateTime applicationDate = (DateTime)reader["Date"];
                            enApplicationType applicationType = (enApplicationType)reader["ApplicationTypeID"];
                            DateTime lastStatusDate = (DateTime)reader["lastStatusDate"];
                            enStatus enStatus = (enStatus)(reader["ApplicationStatusID"]);
                            int personID = (int)reader["PersonID"];
                            int userCreatedByID = (int)reader["UserCreatedByID"];
                            double fees = Convert.ToDouble(reader["Fees"]);

                            clsApplicationDTO applicationDTO = new clsApplicationDTO(applicationID, applicationDate,
                                lastStatusDate, applicationType, enStatus, personID, userCreatedByID, fees);
                            localApplicationDTO = new clsLocalApplicationDTO(localApplicationDTO.localApplicationID, applicationDTO, licenseClassID);

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
        public static clsLocalApplicationDTO AccessApplicationByAppointmentID(int appointmentID)
        {
            clsLocalApplicationDTO localApplicationDTO = null;

            string Query = "select LocalApplicationID," +
                           "LocalDrivingLicenseApplications.ApplicationID," +
                           "LicenseClassID," +
                           "Applications.Date," +
                           "Applications.LastStatusDate," +
                           "Applications.ApplicationTypeID," +
                           "Applications.ApplicationStatusID," +
                           "Applications.PersonID," +
                           "Applications.UserCreatedByID," +
                           "Applications.Fees " +
                           "from LocalDrivingLicenseApplications " +
                           "inner join TestAppointments ON LocalDrivingLicenseApplications.LocalApplicationID=TestAppointments.ApplicationID " +
                           "inner join Applications ON LocalDrivingLicenseApplications.ApplicationID=Applications.ID " +
                           "where AppointmentID=@IDParam;";

            if (appointmentID <= 0)
                throw new ArgumentException("Application ID cannot be Zero or below.");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@IDParam", appointmentID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            //local Application info.
                            int localApplicationID = (int)reader["LocalApplicationID"];
                            int applicationID = (int)reader["ApplicationID"];
                            int licenseClassID = (int)reader["LicenseClassID"];
                            //Base Application info
                            DateTime applicationDate = (DateTime)reader["Date"];
                            DateTime lastStatusDate = (DateTime)reader["lastStatusDate"];
                            enApplicationType applicationType = (enApplicationType)reader["ApplicationTypeID"];
                            enStatus enStatus = (enStatus)(reader["ApplicationStatusID"]);
                            int personID = (int)reader["PersonID"];
                            int userCreatedByID = (int)reader["UserCreatedByID"];
                            double fees = Convert.ToDouble(reader["Fees"]);

                            clsApplicationDTO applicationDTO = new clsApplicationDTO(applicationID, applicationDate,
                                lastStatusDate, applicationType, enStatus, personID, userCreatedByID, fees);
                            localApplicationDTO = new clsLocalApplicationDTO(localApplicationID, applicationDTO, licenseClassID);

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

            return localApplicationDTO;
        }
        public static int addNewLocalApplication(clsLocalApplicationDTO localApplicationDTO)
        {
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("AddNewLocalApplication", Connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Define the output parameters
                    SqlParameter outputLocalAppIdParam = new SqlParameter
                    {
                        ParameterName = "@NewLocalApplicationID",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter outputBaseAppIdParam = new SqlParameter
                    {
                        ParameterName = "@BaseApplicationID",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    //Add the output parameters to the command
                    command.Parameters.Add(outputLocalAppIdParam);
                    command.Parameters.Add(outputBaseAppIdParam);
                    {

                        command.Parameters.AddWithValue("@Date", localApplicationDTO.baseApplicationDTO.applicationDate);
                        command.Parameters.AddWithValue("@LastStatusDate", localApplicationDTO.baseApplicationDTO.lastStatusDate);
                        command.Parameters.AddWithValue("@ApplicationTypeID", localApplicationDTO.baseApplicationDTO.applicationType);
                        command.Parameters.AddWithValue("@ApplicationStatusID", (int)localApplicationDTO.baseApplicationDTO.enApplicationStatus);
                        command.Parameters.AddWithValue("@PersonID", localApplicationDTO.baseApplicationDTO.personID);
                        command.Parameters.AddWithValue("@UserCreatedByID", localApplicationDTO.baseApplicationDTO.UserCreatedByID);
                        command.Parameters.AddWithValue("@Fees", localApplicationDTO.baseApplicationDTO.Fees);
                        command.Parameters.AddWithValue("@LicenseClassID", localApplicationDTO.licenseClassID);

                        try
                        {
                            Connection.Open();

                            command.ExecuteNonQuery();

                            localApplicationDTO.localApplicationID = (int)outputLocalAppIdParam.Value;
                            localApplicationDTO.baseApplicationDTO.applicationID = (int)outputBaseAppIdParam.Value;
                        }
                        catch (Exception ex)
                        {
                            // Preserve the stack trace of the original exception
                            throw new Exception(ex.Message);
                        }

                    }
                    Connection.Close();
                }

                return localApplicationDTO.localApplicationID ;

            }

        }
        public async static Task<DataTable> GetAllLocalApplicationInfo()
        {
            enApplicationType ApplicationType = enApplicationType.NewLocalDrivingLicenseService;
            string query = "SELECT " +
                "LocalApplicationID, " +
                "People.NationalNumber AS NationalNo," +
                "LicenseClasses.Title as [Driving License]," +
                "(People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) AS FullName," +
                "Applications.Date," +
                "(select count(*) from Tests where TestAppointmentID in(" +
                "select AppointmentID from testAppointments " +
                "where ApplicationID = LocalDrivingLicenseApplications.LocalApplicationID) " +
                "AND TestResult = 1) as [Passed Tests] ," +
                "ApplicationStatues.Name as Status from Applications " +
                "inner join ApplicationStatues ON Applications.ApplicationStatusID = ApplicationStatues.ID " +
                "inner join LocalDrivingLicenseApplications ON Applications.ID = LocalDrivingLicenseApplications.ApplicationID " +
                "inner join People ON Applications.PersonID = People.ID " +
                "inner join LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.ClassID" +
                " where Applications.ApplicationTypeID=@ApplicationTypeID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationType);
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
        public async static Task<DataTable> GetAllApplicationsInfoByFilter(string columnName, string columnValue)
        {
            string whereClause;

            // Check if the filter is for the derived column "Full Name"
            if (columnName.Equals("FullName", StringComparison.OrdinalIgnoreCase))
            {
                whereClause = "WHERE People.FirstName + ' ' + People.SecondName +' '+People.ThirdName + People.LastName like @FilterValue";
            }
            else
            {
                // For regular columns, use the column name directly
                whereClause = "WHERE [" + columnName + "] = @FilterValue";
            }
            string query = @"SELECT " +
                "LocalApplicationID, " +
                "People.NationalNumber AS NationalNo," +
                "LicenseClasses.Title as [Driving License]," +
                "(People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) AS FullName," +
                "Applications.Date," +
                "(select count(*) from Tests where TestAppointmentID in(" +
                "select AppointmentID from testAppointments " +
               "where ApplicationID = Applications.ID) " +
                "AND TestResult = 1) as [Passed Tests] ," +
                "ApplicationStatues.Name as Status from Applications " +
                "inner join ApplicationStatues ON Applications.ApplicationStatusID = ApplicationStatues.ID " +
                "inner join LocalDrivingLicenseApplications ON Applications.ID = LocalDrivingLicenseApplications.ApplicationID " +
                "inner join People ON Applications.PersonID = People.ID " +
                "inner join LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.ClassID " +
                $"{whereClause};";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (columnName == "FullName")
                    {
                        command.Parameters.AddWithValue("@FilterValue", "%" + columnValue + "%");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@FilterValue", columnValue);
                    }
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
        public static bool UpdateApplicationInfo(clsLocalApplicationDTO localApplicationDTO)
        {
            bool isUpdated = false;

            string query = "Update Applications " +
                "SET " +
                "Date=@dateParam," +
                "LastStatusDate=@lastDateParam," +
                "ApplicationTypeID=@appliactionTypeParam," +
                "ApplicationStatusID=@appliactionStatusParam," +
                "PersonID=@PersonIDParam," +
                "UserCreatedByID=@userCreatedByParam," +
                "Fees=@FeesParam " +
                "WHERE ID=@IDParam;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDParam", localApplicationDTO.baseApplicationDTO.applicationID);
                    command.Parameters.AddWithValue("@dateParam", localApplicationDTO.baseApplicationDTO.applicationDate);
                    command.Parameters.AddWithValue("@lastDateParam", localApplicationDTO.baseApplicationDTO.lastStatusDate);
                    command.Parameters.AddWithValue("@appliactionTypeParam", localApplicationDTO.baseApplicationDTO.applicationType);
                    command.Parameters.AddWithValue("@appliactionStatusParam", (int)localApplicationDTO.baseApplicationDTO.enApplicationStatus);
                    command.Parameters.AddWithValue("@PersonIDParam", localApplicationDTO.baseApplicationDTO.personID);
                    command.Parameters.AddWithValue("@userCreatedByParam", localApplicationDTO.baseApplicationDTO.UserCreatedByID);
                    command.Parameters.AddWithValue("@FeesParam", localApplicationDTO.baseApplicationDTO.Fees);
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
                        throw new Exception("Database  operation failed to update base application INfO.", ex);
                    }

                    finally
                    {
                        connection.Close();
                    }
                }

            }

            //update child application (local driving licesnse application ) .
            if (isUpdated)
            {
                isUpdated = _updateLocalApplicationInfo(localApplicationDTO);
            }

            return isUpdated;

        }
        public static bool deleteLocalApplicationInfo(List<int> selectedLocalApplicationIDs)

        {
            List<int> baseApplicationIDs = AccessBaseApplicationIDsByLocalApplicationID(selectedLocalApplicationIDs);

            if (baseApplicationIDs.Count < 1)
                return false;

            bool IsDeleted = false;

            string Query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalApplicationID IN ("
                + string.Join(",", selectedLocalApplicationIDs.Select(id => $"@ID{id}")) + ")";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    foreach (int localApplicationID in selectedLocalApplicationIDs)
                    {
                        Command.Parameters.AddWithValue($"@ID{localApplicationID}", localApplicationID);
                    }

                    try
                    {
                        Connection.Open();

                        int EffectedRows = Command.ExecuteNonQuery();
                        if (EffectedRows == selectedLocalApplicationIDs.Count)
                            IsDeleted = true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }

            if (IsDeleted)
            {
                return _deleteBaseApplicationInfo(baseApplicationIDs);
            }

            return IsDeleted;
        }
        public static bool cancelApplicationByID(List<int> selectedLocalApplicationIDs)
        {
            bool isCancelled = false;
            if (selectedLocalApplicationIDs.Count < 1)
                return false;

            List<int> derievedbaseApplicationIDs = AccessBaseApplicationIDsByLocalApplicationID(selectedLocalApplicationIDs);

            if (derievedbaseApplicationIDs.Count < 1)
                return false;

            clsStatusRepository statusRepository = new clsStatusRepository();
            int ApplicationStatusID = statusRepository.GetStatusId(enStatus.cancelled);

            string Query = "UPDATE [dbo].[Applications] " +
                           $"SET [ApplicationStatusID] = {ApplicationStatusID}" +
                           "WHERE ID IN (" +
                           string.Join(",", derievedbaseApplicationIDs.Select(id => $"@ID{id}")) + ")";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    foreach (int baseApplicationID in derievedbaseApplicationIDs)
                    {
                        Command.Parameters.AddWithValue($"@ID{baseApplicationID}", baseApplicationID);
                    }

                    try
                    {
                        Connection.Open();

                        int EffectedRows = Command.ExecuteNonQuery();
                        if (EffectedRows == selectedLocalApplicationIDs.Count)
                            isCancelled = true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            return isCancelled;

        }
        public static bool completeApplicationByID(int localApplicationID)
        {
            bool isCompleted = false;
          
            clsLocalApplicationDTO clsLocalApplicationDTO = new clsLocalApplicationDTO(localApplicationID);
            AccessApplicationById(ref clsLocalApplicationDTO);
          
            clsStatusRepository statusRepository = new clsStatusRepository();
            int ApplicationStatusID = statusRepository.GetStatusId(enStatus.completed);

            string Query = "UPDATE [dbo].[Applications] " +
                           "SET [ApplicationStatusID] = @applicationStatus" +
                           " WHERE ID=@ApplicationID";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    
                        Command.Parameters.AddWithValue($"@ApplicationID", clsLocalApplicationDTO.baseApplicationDTO.applicationID);
                        Command.Parameters.AddWithValue($"@applicationStatus", ApplicationStatusID);


                    try
                    {
                        Connection.Open();

                        int EffectedRows = Command.ExecuteNonQuery();
                        if (EffectedRows >0)
                            isCompleted= true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            return isCompleted;

        }
        private static bool _deleteBaseApplicationInfo(List<int> baseApplicationIDs)
        {
            bool isDeleted = false;



            string Query = "delete  FROM Applications WHERE ID IN ( " +
                string.Join(",", baseApplicationIDs.Select(id => $"@ID{id}")) + ")";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    foreach (int baseApplicationID in baseApplicationIDs)
                    {
                        Command.Parameters.AddWithValue($"@ID{baseApplicationID}", baseApplicationID);
                    }

                    try
                    {
                        Connection.Open();

                        int EffectedRows = Command.ExecuteNonQuery();
                        if (EffectedRows == baseApplicationIDs.Count)
                            isDeleted = true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }

            return isDeleted;
        }
        private static bool _updateLocalApplicationInfo(clsLocalApplicationDTO localApplicationDTO)
        {
            bool isUpdated = false;

            string query = "Update LocalDrivingLicenseApplications " +
                "SET " +
                "ApplicationID=@ApplicationID," +
                "LicenseClassID=@LicenseClassID " +
                "WHERE LocalApplicationID=@IDParam;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDParam", localApplicationDTO.localApplicationID);
                    command.Parameters.AddWithValue("@ApplicationID", localApplicationDTO.baseApplicationDTO.applicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", localApplicationDTO.licenseClassID);

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
                        throw new Exception("Database  operation failed to update base application INfO.", ex);
                    }

                    finally
                    {
                        connection.Close();
                    }
                }

            }

            return isUpdated;

        }
        private static List<int> AccessBaseApplicationIDsByLocalApplicationID(List<int> selectedLocalApplicationIDs)
        {
            List<int> baseApplicationIDs = new List<int>();
            string query = " SELECT Applications.ID FROM Applications" +
                "  INNER JOIN LocalDrivingLicenseApplications ON Applications.ID=LocalDrivingLicenseApplications.ApplicationID " +
                "WHERE LocalApplicationID IN (" + string.Join(",", selectedLocalApplicationIDs.Select(id => $"@ID{id}")) + ")";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        foreach (int localApplicationID in selectedLocalApplicationIDs)
                        {
                            command.Parameters.AddWithValue($"@ID{localApplicationID}", localApplicationID);
                        }
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int baseApplicationID = (int)reader["ID"];
                            baseApplicationIDs.Add(baseApplicationID);//Base application ID.
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

                    return baseApplicationIDs;
                }
            }
        }
   
    }

    public static class clsRetakeTestApplicationDataAccess
    {
        public static string ConnectionString = clsConnectionServer.connectionString;

        public static int AddRetakeApplicationInfo(clsRetakeTestApplication retakeTestApplicationDTO)
        {
            int newRetakeTestApplicationID = -1;

            string Query = "INSERT INTO [RetakeTestApplications] " +
                           "([LocalApplicationID]," +
                           "[TestTypeID])" +
                           " VALUES " +
                           "(@LocalApplicationID,@TestTypeID) " +
                           "select SCOPE_IDENTITY();";
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {

                    command.Parameters.AddWithValue("@LocalApplicationID", retakeTestApplicationDTO.LocalApplicationDTO.localApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", retakeTestApplicationDTO.enTestType);
               

                    try
                    {
                        Connection.Open();

                        object result = command.ExecuteScalar();

                        int.TryParse(result.ToString(), out newRetakeTestApplicationID);


                    }
                    catch (Exception ex)
                    {
                        // Preserve the stack trace of the original exception
                        throw new Exception(ex.Message);
                    }

                }
                Connection.Close();
            }

            return newRetakeTestApplicationID;
        }

        public static clsApplicationDTO ReturnRetakeTestApplicationIfExists(int personID)

        {
            clsApplicationDTO retakeApplication = null;
            enApplicationType applicationType = enApplicationType.RetakeTest;

            string Query = "SELECT ID, Date, LastStatusDate, ApplicationTypeID, ApplicationStatusID, PersonID, Fees, UserCreatedByID" +
                           " FROM Applications" +
                           " where PersonID=@PersonID and ApplicationTypeID =@ApplicationType";


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@ApplicationType", applicationType);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            //Base Application info
                            int applicationID = (int)reader["ID"];
                            DateTime applicationDate = (DateTime)reader["Date"];
                            applicationType = (enApplicationType)reader["ApplicationTypeID"];
                            DateTime lastStatusDate = (DateTime)reader["lastStatusDate"];
                            enStatus enStatus = (enStatus)(reader["ApplicationStatusID"]);
                            personID = (int)reader["PersonID"];
                            int userCreatedByID = (int)reader["UserCreatedByID"];
                            double fees = Convert.ToDouble(reader["Fees"]);

                            retakeApplication = new clsApplicationDTO(applicationID, applicationDate,
                             lastStatusDate, applicationType, enStatus, personID, userCreatedByID, fees);

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

            return retakeApplication;
        }

    }


}

