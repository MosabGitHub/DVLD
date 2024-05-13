using ConnectionClassLibrary;
using DVLD.DTOs;
using DVLD.DTOs.DriverDTO;
using DVLD.DTOs.LicesnseDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GlobalSettings;
using System.ComponentModel;

using System.Data;
using System.Collections;
namespace _LicenseDataAccess
{
    public static class clsLicenseDataAccess
    {
    public static string ConnectionString = clsConnectionServer.connectionString;

        public static int AddNewLicense(clsLicenseDTO licenseDTO)
        {
            int newLicenseID = -1;
            if (licenseDTO == null)
                return -1;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Licenses]" +
                    "([ApplicationID]," +
                    "[DriverID]," +
                    "[LicenseClassID]," +
                    "[IssueDate]," +
                    "[ExpireDate]," +
                    "[Notes]," +
                    "[IsActive]," +
                    "[PaidFees]," +
                    "[CreatedByUserID]," +
                    "[IssueReason])" +
                    "VALUES " +
                    "(@ApplicationID,@DriverID, @LicenseClassID, @IssueDate, @ExpireDate, @Notes, @IsActive, @PaidFees, @CreatedByUserID" +
                    ",@IssueReason) " +
                    "select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, Connection);

                try
                {
                    Connection.Open();
                    command.Parameters.AddWithValue("@ApplicationID", licenseDTO.ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", licenseDTO.DriverID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseDTO.LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", licenseDTO.LicenseSpec.IssueDate);
                    command.Parameters.AddWithValue("@ExpireDate", licenseDTO.LicenseSpec.ExpireDate);
                    command.Parameters.AddWithValue("@Notes", licenseDTO.LicenseSpec.Notes);
                    command.Parameters.AddWithValue("@IsActive", licenseDTO.LicenseSpec.IsActive);
                    command.Parameters.AddWithValue("@PaidFees", licenseDTO.LicenseSpec.PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", licenseDTO.UsercreatedByID);
                    command.Parameters.AddWithValue("@IssueReason", licenseDTO.LicenseSpec.IssueReason);

                    object result = command.ExecuteScalar();

                    int.TryParse(result.ToString(), out newLicenseID);


                    Connection.Close();

                }
                catch (Exception ex)
                {
                    // Preserve the stack trace of the original exception
                    throw new Exception(ex.Message);
                }
            }

            return newLicenseID;

        }
        public static clsLicenseDTO AccessLicenseByAppInfo(int baseApplicaitonID)
        {
            enIssueReason enIssueReason = 0;
            clsLicenseDTO licenseDTO = null;
            string Query = "select * from Licenses where ApplicationID=@ApplicationID";

            if (baseApplicaitonID <= 0)
                throw new Exception("Application ID cannot be -1 or 0");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", baseApplicaitonID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            //License Info
                            int LicenseID = (int)reader["LicenseID"];
                            int ApplicationID = (int)reader["ApplicationID"];
                            int DriverID = (int)reader["DriverID"];
                            int licenseClassID = (int)reader["LicenseClassID"];

                            //License Spec
                            DateTime IssueDate = (DateTime)reader["IssueDate"];
                            DateTime ExpireDate = (DateTime)reader["ExpireDate"];
                            string Notes = (string)reader["Notes"];
                            bool isActive = (bool)reader["IsActive"];
                            decimal PaidFees = (decimal)reader["PaidFees"];
                            int userCreatedByID = (int)reader["CreatedByUserID"];
                            int issueReasonId = reader.GetByte(reader.GetOrdinal("IssueReason"));

                            if (Enum.IsDefined(typeof(enIssueReason), issueReasonId))
                            {
                                enIssueReason = (enIssueReason)issueReasonId;
                            }
                            else
                            {
                                throw new ArgumentException("Failed because of IssueReason in database.");
                            }

                            clsLicenseSpec licenseSpec = new clsLicenseSpec(IssueDate, ExpireDate, Notes, isActive, PaidFees, enIssueReason);
                            licenseDTO = new clsLicenseDTO(LicenseID, ApplicationID, licenseClassID, DriverID, userCreatedByID, licenseSpec);

                        }


                        reader.Close();
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return licenseDTO;

        }
        public static clsLicenseDTO AccessLicenseByID(int licenseID)
        {
            enIssueReason enIssueReason = 0;

            clsLicenseDTO licenseDTO = null;
            string Query = "select * from Licenses where LicenseID=@LicenseID";

            if (licenseID <= 0)
                throw new Exception("license ID cannot be minus or zero");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            //License Info
                            int LicenseID = (int)reader["LicenseID"];
                            int ApplicationID = (int)reader["ApplicationID"];
                            int DriverID = (int)reader["DriverID"];
                            int licenseClassID = (int)reader["LicenseClassID"];

                            //License Spec
                            DateTime IssueDate = (DateTime)reader["IssueDate"];
                            DateTime ExpireDate = (DateTime)reader["ExpireDate"];
                            string Notes = (string)reader["Notes"];
                            bool isActive = (bool)reader["IsActive"];
                            decimal PaidFees = (decimal)reader["PaidFees"];
                            int userCreatedByID = (int)reader["CreatedByUserID"];
                            int issueReasonId = reader.GetByte(reader.GetOrdinal("IssueReason"));

                            if (Enum.IsDefined(typeof(enIssueReason), issueReasonId))
                            {
                                enIssueReason = (enIssueReason)issueReasonId;
                            }
                            else
                            {
                                throw new ArgumentException("Failed because of IssueReason in database.");
                            }
                            clsLicenseSpec licenseSpec = new clsLicenseSpec(IssueDate, ExpireDate, Notes, isActive, PaidFees, enIssueReason);
                            licenseDTO = new clsLicenseDTO(LicenseID, ApplicationID, licenseClassID, DriverID, userCreatedByID, licenseSpec);
                        }


                        reader.Close();
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return licenseDTO;

        }
        public static bool IsLicenseActive(int licenseID)
        {
            bool isActive = true;
            string Query = "select IsActive from Licenses where LicenseID=@LicenseID ";

            if (licenseID <= 0)
                throw new Exception("license ID cannot be -1 or 0");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        isActive = Convert.ToBoolean(result);

                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return isActive;

        }
        public static bool isExists(int driverID, int licenseClassID)

        {
            bool IsFound = false;

            string Query = "SELECT COUNT(*)IsExits FROM Licenses WHERE DriverID=@DriverID AND LicenseClassID=@LicenseClassID and isActive=1";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {

                    Command.Parameters.AddWithValue("@DriverID", driverID);
                    Command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    try
                    {
                        Connection.Open();

                        object result = Command.ExecuteScalar();

                        if ((int)result > 0)
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
        public async static Task<DataTable> GetAllLocalDriverLicenseInfo(int driverID)

        {

            string query = "SELECT Licenses.LicenseID," +
                "Licenses.ApplicationID," +
                "LicenseClasses.Title," +
                "Licenses.IssueDate," +
                "Licenses.ExpireDate," +
                "Licenses.IsActive " +
                "from Licenses inner join LicenseClasses ON Licenses.LicenseClassID=LicenseClasses.ClassID " +
                "where DriverID=@DriverID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();

                    try
                    {
                        command.Parameters.AddWithValue("@DriverID", driverID);
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
                        Console.WriteLine(ex.Message);
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }
        public async static Task<DataTable> GetAllInternationalDriverLicenseInfo(int driverID)

        {

            string query = "SELECT InternationalLicenses.InternationalLicenseID as [INT.License ID]," +
                           "InternationalLicenses.ApplicationID as [Application ID]," +
                           "InternationalLicenses.IssuedUsingLocalLicenseID as [L.LICENSE ID]," +
                           "InternationalLicenses.IssueDate as [Issue Date]," +
                           "InternationalLicenses.ExpirationDate as [Expiration Date]," +
                           "InternationalLicenses.IsActive as [Is Active]" +
                           " from InternationalLicenses" +
                           " where DriverID=@DriverID;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();

                    try
                    {
                        command.Parameters.AddWithValue("@DriverID", driverID);
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
                        Console.WriteLine(ex.Message);
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }

        public static int GetPersonIDByLicenseId(int licenseID)
        {

            int personID = -1;

            string Query = "select  Drivers.PersonID" +
                           " FROM Drivers INNER JOIN People ON Drivers.PersonID = People.ID" +
                           " INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID" +
                           " where LicenseID=@LicenseID;";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@LicenseID", licenseID);
                    try
                    {
                        Connection.Open();

                        object result = Command.ExecuteScalar();

                        int.TryParse(result.ToString(), out personID);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                Connection.Close();
            }

            return personID;
        }

        public static bool DeactivateLicenseInfoByID(int licenseID)
        {
            bool isDeactivate = false;
            string Query = "UPDATE [dbo].[Licenses] SET [IsActive] =0 WHERE LicenseID=@LicenseID" ;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    try
                    {

                        connection.Open();

                        object effectedRows = command.ExecuteNonQuery();

                        int.TryParse(effectedRows.ToString(), out int totalRows);
                        { 
                            if (totalRows > 0)
                            {
                                isDeactivate = true;

                            }
                        }
                    }
                    catch( Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                connection.Close();
            }
            return isDeactivate;
        }
        public static bool ActivateLicenseInfoByID(int licenseID)
        {
            bool isDeactivate = false;
            string Query = "UPDATE [dbo].[Licenses] SET [IsActive] =1 WHERE LicenseID=@LicenseID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    try
                    {

                        connection.Open();

                        object effectedRows = command.ExecuteNonQuery();

                        int.TryParse(effectedRows.ToString(), out int totalRows);
                        {
                            if (totalRows > 0)
                            {
                                isDeactivate = true;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                connection.Close();
            }
            return isDeactivate;
        }

        public static bool IsLicenseOwnSameClassLicenseByPersonID(int personID,int licenseClassID)

        {
            bool isOwned = false;

            string Query = "SELECT COUNT( Licenses.LicenseClassID) as [total licenses with same class id]" +
                           " FROM Licenses" +
                           " INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID" +
                           " where PersonID=@PersonID and LicenseClassID=@LicenseClassID" +
                           " select * from Licenses;";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {

                    Command.Parameters.AddWithValue("@PersonID", personID);
                    Command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    try
                    {
                        Connection.Open();

                        object result = Command.ExecuteScalar();

                        if ((int)result > 0)
                        {
                            isOwned = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }

            return isOwned;
        }

    }

    public static class clsInternationalLicenseDataAccess
    {
       
        public static string ConnectionString = clsConnectionServer.connectionString;
        public static int AddNewInternationalLicense(clsInternationalLicenseDTO internationalLicenseDTO)
        {
            int newLicenseID = -1;

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO [dbo].[InternationalLicenses]" +
                    "([ApplicationID]," +
                    "[DriverID]," +
                    "[IssuedUsingLocalLicenseID]," +
                    "[IssueDate]," +
                    "[ExpirationDate]," +
                    "[CreatedByUserID]," +
                    "[IsActive])" +
                    " VALUES " +
                    "(@ApplicationID,@DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @CreatedByUserID, @IsActive)" +
                    "select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, Connection);

                try
                {
                    Connection.Open();
                    command.Parameters.AddWithValue("@ApplicationID", internationalLicenseDTO.ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", internationalLicenseDTO.DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", internationalLicenseDTO.IssuedLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", internationalLicenseDTO.InternationalLicenseSpec.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", internationalLicenseDTO.InternationalLicenseSpec.ExpirationDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", internationalLicenseDTO.InternationalLicenseSpec.CreatedByUserID);
                    command.Parameters.AddWithValue("@IsActive", internationalLicenseDTO.InternationalLicenseSpec.IsActive);
             

                    object result = command.ExecuteScalar();

                    int.TryParse(result.ToString(), out newLicenseID);


                    Connection.Close();

                }
                catch (Exception ex)
                {
                    // Preserve the stack trace of the original exception
                    throw new Exception(ex.Message);
                }
            }

            return newLicenseID;

        }
        public async static Task<DataTable> GetAllInternationalDrivingLicenseApplicationInfo()
        {

            string query = "SELECT  InternationalLicenses.InternationalLicenseID as [INT.License ID]," +
                           "InternationalLicenses.ApplicationID as [Application ID]," +
                           "InternationalLicenses.DriverID as [Driver ID]," +
                           "InternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID]," +
                           "InternationalLicenses.IssueDate as [Issue Date]," +
                           "InternationalLicenses.ExpirationDate as [Expiration Date]," +
                           "InternationalLicenses.IsActive as [Is Active] " +
                           " FROM Applications " +
                           " INNER JOIN InternationalLicenses ON Applications.ID = InternationalLicenses.ApplicationID";

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
                       throw new Exception($"Could not find {ex.Message}");
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }
        public async static Task<DataTable> GetAllInternationalDrivingLicenAppInfoByIntLicenID(int internationalLicenseID)
        {

            string query = "SELECT  InternationalLicenses.InternationalLicenseID as [INT.License ID]," +
                           "InternationalLicenses.ApplicationID as [Application ID]," +
                           "InternationalLicenses.DriverID as [Driver ID]," +
                           "InternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID]," +
                           "InternationalLicenses.IssueDate as [Issue Date]," +
                           "InternationalLicenses.ExpirationDate as [Expiration Date]," +
                           "InternationalLicenses.IsActive as [Is Active] " +
                           " FROM Applications " +
                           " INNER JOIN InternationalLicenses ON Applications.ID = InternationalLicenses.ApplicationID" +
                           " WHERE InternationalLicenseID like @IDPattern";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
  
                { 
                    command.Parameters.AddWithValue("@IDPattern","%"+ internationalLicenseID+ "%");
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
                        throw new Exception($"Could not find {ex.Message}");
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }
        public async static Task<DataTable> GetAllInternationalDrivingLicenAppInfoByIntAppID(int internationalApplicationID)
        {

            string query = "SELECT  InternationalLicenses.InternationalLicenseID as [INT.License ID]," +
                           "InternationalLicenses.ApplicationID as [Application ID]," +
                           "InternationalLicenses.DriverID as [Driver ID]," +
                           "InternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID]," +
                           "InternationalLicenses.IssueDate as [Issue Date]," +
                           "InternationalLicenses.ExpirationDate as [Expiration Date]," +
                           "InternationalLicenses.IsActive as [Is Active] " +
                           " FROM Applications " +
                           " INNER JOIN InternationalLicenses ON Applications.ID = InternationalLicenses.ApplicationID" +
                           " WHERE ApplicationID like @IDPattern";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))

                {
                    command.Parameters.AddWithValue("@IDPattern", "%" + internationalApplicationID + "%");
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
                        throw new Exception($"Could not find {ex.Message}");
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }
        public async static Task<DataTable> GetAllInternationalDrivingLicenAppInfoByDriverID(int driverID)
        {

            string query = "SELECT  InternationalLicenses.InternationalLicenseID as [INT.License ID]," +
                           "InternationalLicenses.ApplicationID as [Application ID]," +
                           "InternationalLicenses.DriverID as [Driver ID]," +
                           "InternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID]," +
                           "InternationalLicenses.IssueDate as [Issue Date]," +
                           "InternationalLicenses.ExpirationDate as [Expiration Date]," +
                           "InternationalLicenses.IsActive as [Is Active] " +
                           " FROM Applications " +
                           " INNER JOIN InternationalLicenses ON Applications.ID = InternationalLicenses.ApplicationID" +
                           " WHERE DriverID like @IDPattern";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))

                {
                    command.Parameters.AddWithValue("@IDPattern", "%" + driverID + "%");
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
                        throw new Exception($"Could not find {ex.Message}");
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }
        public async static Task<DataTable> GetAllInternationalDrivingLicenAppInfoByActive(bool isActive)
        {

            string query = "SELECT  InternationalLicenses.InternationalLicenseID as [INT.License ID]," +
                           "InternationalLicenses.ApplicationID as [Application ID]," +
                           "InternationalLicenses.DriverID as [Driver ID]," +
                           "InternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID]," +
                           "InternationalLicenses.IssueDate as [Issue Date]," +
                           "InternationalLicenses.ExpirationDate as [Expiration Date]," +
                           "InternationalLicenses.IsActive as [Is Active] " +
                           " FROM Applications " +
                           " INNER JOIN InternationalLicenses ON Applications.ID = InternationalLicenses.ApplicationID" +
                           " WHERE IsActive=@IsActive";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("IsActive", isActive);

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
                        throw new Exception($"Could not find {ex.Message}");
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }
        public static clsInternationalLicenseDTO AccessInternationalLicenseByID(int internationalLicenseID)
        {

            clsInternationalLicenseDTO internationalLicenseDTO= null;
            string Query = "select * from InternationalLicenses where InternationalLicenseID=@InternationalLicenseID";

            if (internationalLicenseID <= 0)
                throw new Exception("license ID cannot be minus or zero");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            //International License Info
                            int InternationalLicenseID = (int)reader["InternationalLicenseID"];
                            int ApplicationID = (int)reader["ApplicationID"];
                            int DriverID = (int)reader["DriverID"];
                            int IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];

                            //International License Spec
                            int userCreatedByID = (int)reader["CreatedByUserID"];
                            DateTime IssueDate = (DateTime)reader["IssueDate"];
                            DateTime ExpireDate = (DateTime)reader["ExpirationDate"];
                            bool isActive = (bool)reader["IsActive"];
                            

                            clsInternationalLicenseSpec InternationalLicenseSpec = new clsInternationalLicenseSpec(userCreatedByID, IssueDate,
                                ExpireDate, isActive);
                           
                            internationalLicenseDTO = new clsInternationalLicenseDTO(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                InternationalLicenseSpec);
                        }


                        reader.Close();
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return internationalLicenseDTO;

        }



    }


}
