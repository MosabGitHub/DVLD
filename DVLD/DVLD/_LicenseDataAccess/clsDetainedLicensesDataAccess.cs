using ConnectionClassLibrary;
using DVLD.DTOs.LicenseDTO;
using DVLD.DTOs.LicenseDTO.Detained_ReleaseLicenses;
using DVLD.DTOs.LicesnseDTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _LicenseDataAccess
{

    public static class clsDetainedLicensesDataAccess
    {


        public static string ConnectionString = clsConnectionServer.connectionString;
        public static bool IsLicenseDetained(int licenseID)
        {
            string Query = "select IsReleased from DetainedLicenses where LicenseID=@LicenseID;";

            bool isDetained = false;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {

                    Command.Parameters.AddWithValue("@LicenseID", licenseID);


                    try
                    {
                        Connection.Open();

                        object result = Command.ExecuteScalar();

                        if (result != null)
                        {
                            if (Convert.ToBoolean(result) == false)
                                isDetained = true;
                        }

                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.ToString());
                    }



                }

                Connection.Close();
            }

            return isDetained;


        }
        public static int saveDetainedLicenseInfo(clsDetainedLicense DetainedLicense)
        {
            int newDetainedLicenseId = -1;
            string Query = "INSERT INTO [dbo].[DetainedLicenses]" +
                           " ([LicenseID]," +
                           " [DetainDate]," +
                           " [FineFees]," +
                           " [CreatedByUserID]," +
                           " [IsReleased]," +
                           " [DetainReason])" +
                           " VALUES" +
                           " (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased,@DetainReason)" +
                           " select SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand(Query, connection);


            try
            {
                command.Parameters.AddWithValue("@LicenseID", DetainedLicense.LicenseID);
                command.Parameters.AddWithValue("@DetainDate", DetainedLicense.DetainSpec.DetainDate);
                command.Parameters.AddWithValue("@FineFees", DetainedLicense.DetainSpec.FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", DetainedLicense.DetainSpec.CreateByUserID);
                command.Parameters.AddWithValue("@IsReleased", DetainedLicense.DetainSpec.IsReleased);
                command.Parameters.AddWithValue("@DetainReason", DetainedLicense.DetainSpec.DetainReason);

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int value))
                {
                    newDetainedLicenseId = value;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return newDetainedLicenseId;
        }

        public static clsDetainedLicense AccessDetainedLicenseInfoByLicenseId(int licenseID)
        {

            clsDetainedLicense detainedLicense = null;
            string Query = "SELECT * FROM DetainedLicenses Where LicenseID=@LicenseID";

            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand(Query, connection);


            try
            {
                command.Parameters.AddWithValue("@LicenseID", licenseID);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int DetainID = (int)reader["DetainID"];
                    int LicenseID = (int)reader["LicenseID"];
                    DateTime DetainDate = (DateTime)reader["DetainDate"];
                    decimal FineFees = (decimal)reader["FineFees"];
                    int CreatedByUserId = (int)reader["CreatedByUserID"];
                    bool IsReleased = (bool)reader["IsReleased"];

                    DateTime? ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : (DateTime?)null; ;
                   
                    int? ReleasedByUserID = reader["ReleasedByUserID"]!=DBNull.Value?Convert.ToInt32(reader["ReleasedByUserID"]):(int?)null;
                   
                    int? ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ?
                        Convert.ToInt32(reader["ReleaseApplicationID"]) : (int?)null;

                    string DetainReason = (string)reader["DetainReason"];

                    clsDetainedLicenseSpec detainedLicenseSpec = new clsDetainedLicenseSpec(DetainDate,
                        FineFees, CreatedByUserId, IsReleased, DetainReason, ReleaseDate, ReleasedByUserID);

                    detainedLicense = new clsDetainedLicense(DetainID, licenseID, detainedLicenseSpec, ReleaseApplicationID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return detainedLicense;
        }

        public static bool ReleaseDetainedLicense(clsReleaseSpec  releaseSpec) {
            
            bool isReleased = false;

            string Query = "UPDATE [dbo].[DetainedLicenses] SET" +
                           " [IsReleased] =@IsReleased," +
                           " [ReleaseDate] =@ReleaseDate," +
                           " [ReleasedByUserID] =@ReleasedByUserID," +
                           " [ReleaseApplicationID] =@ReleaseApplicationID" +
                           " Where LicenseID=@LicenseID;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand command=new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", releaseSpec.LicenseID);
                    command.Parameters.AddWithValue("@IsReleased", releaseSpec.IsReleased);
                    command.Parameters.AddWithValue("@ReleaseDate", releaseSpec.ReleaseDate);
                    command.Parameters.AddWithValue("@ReleasedByUserID", releaseSpec.ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", releaseSpec.ReleaseApplicationID);

                    connection.Open();


                    int effectedRows= command.ExecuteNonQuery();

                    if (effectedRows > 0)
                    {
                        isReleased = true;
                    }

                }
                connection.Close();
            }

            return isReleased;

        }

        public static async Task<DataTable> ReturnAllDetainedLicensesInfo()
        {

            DataTable table = new DataTable();

            string Query = "select DetainedLicenses.DetainID," +
                           " DetainedLicenses.LicenseID," +
                           " DetainedLicenses.IsReleased," +
                           " DetainedLicenses.FineFees," +
                           " People.NationalNumber," +
                           " (People.FirstName+ ' '+  People.SecondName + ' '+ People.ThirdName + ' '+  People.LastName) as [Full Name]," +
                           " DetainedLicenses.ReleaseApplicationID" +
                           " FROM DetainedLicenses" +
                           " INNER JOIN Licenses ON DetainedLicenses.LicenseID=Licenses.LicenseID" +
                           " INNER JOIN Drivers ON Licenses.DriverID=Drivers.DriverID" +
                           " INNER JOIN People on Drivers.PersonID=People.ID;";

            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand command =new SqlCommand(Query, connection);

            try
            {

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally 
            {
                connection.Close();
            }

            return table;
        }

        public static async Task<DataTable> ReturnFilterDetainedLicensesInfo(string columnName,string columnValue)
        {
            if(columnName == "" || columnValue == "")
                return null;
            string whereClause;
            // Check if the filter is for the derived column "Full Name"
            if (columnName.Equals("FullName", StringComparison.OrdinalIgnoreCase))
            {
                whereClause = "WHERE People.FirstName + ' ' + People.SecondName +' '+People.ThirdName + People.LastName like @ColumnValue";
            }
            else
            {
                // For regular columns, use the column name directly
                whereClause = "WHERE [" + columnName + "] LIKE  @ColumnValue";
            }

            DataTable table = new DataTable();

            string Query = "select DetainedLicenses.DetainID," +
                           " DetainedLicenses.LicenseID," +
                           " DetainedLicenses.IsReleased," +
                           " DetainedLicenses.FineFees," +
                           " People.NationalNumber," +
                           " (People.FirstName+ ' '+  People.SecondName + ' '+ People.ThirdName + ' '+  People.LastName) as [Full Name]," +
                           " DetainedLicenses.ReleaseApplicationID" +
                           " FROM DetainedLicenses" +
                           " INNER JOIN Licenses ON DetainedLicenses.LicenseID=Licenses.LicenseID" +
                           " INNER JOIN Drivers ON Licenses.DriverID=Drivers.DriverID" +
                           " INNER JOIN People on Drivers.PersonID=People.ID" +
                           $" {whereClause};";

            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {

                connection.Open();
         
                    command.Parameters.AddWithValue("@ColumnValue", columnValue + "%");
       
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    table.Load(reader);
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

            return table;
        }
    }

}
