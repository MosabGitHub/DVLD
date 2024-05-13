using ConnectionClassLibrary;
using DVLD.DTOs;
using DVLD.DTOs.DriverDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using _PersonDataAccess;
using PersonServiceLibrary;
namespace _LicenseDataAccess
{
    public static class clsDriverDataAccess
    {
        public static string ConnectionString = clsConnectionServer.connectionString;

        public static int AddNewDriver(clsDriverDTO driverDTO)
        {
            int newDriverID = -1;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Drivers]" +
                    "([PersonID]," +
                    "[UserCreatedByID]," +
                    "[CreatedDate])" +
                    "VALUES " +
                    "(@PersonID,@UserCreatedByID,@CreatedDate)" +
                    " select SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, Connection);

                try
                {
                    Connection.Open();
                    command.Parameters.AddWithValue("PersonID", driverDTO.PersonDTO.ID);
                    command.Parameters.AddWithValue("UserCreatedByID", driverDTO.UserCreatedByID);
                    command.Parameters.AddWithValue("CreatedDate", driverDTO.CreatedDate);

                     object result= command.ExecuteScalar();

                    int.TryParse(result.ToString(), out newDriverID);

                }
                catch (Exception ex)
                {
                    // Preserve the stack trace of the original exception
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
             
            return newDriverID;

        }

        public async static Task<DataTable> GetAllDriversInfo()

        {

            string query = "SELECT  Drivers.DriverID," +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "(People.FirstName+ ' ' + People.SecondName +' '+  People.ThirdName +' '+  People.LastName ) as [Full Name]," +
                           "COUNT(*)  as [Active Licenses]" +
                           "FROM Drivers " +
                           "INNER JOIN People ON Drivers.PersonID = People.ID " +
                           "INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID " +
                           "where " +
                           //"Licenses.driverID =2 " +
                           //"and " +
                           "Licenses.IsActive=1 " +
                           "group by Drivers.DriverID, " +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "People.FirstName," +
                           "People.SecondName," +
                           "People.ThirdName," +
                           "People.LastName ";

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
                        Console.WriteLine(ex.Message);
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }
        public async static Task<DataTable> GetAllDriversInfoByID(int driverID)

        {

            string query = "SELECT  Drivers.DriverID," +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "(People.FirstName+ ' ' + People.SecondName +' '+  People.ThirdName +' '+  People.LastName ) as [Full Name]," +
                           "COUNT(*)  as [Active Licenses] " +
                           "FROM Drivers " +
                           "INNER JOIN People ON Drivers.PersonID = People.ID " +
                           "INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID " +
                           "where " +
                           "Licenses.driverID =@DriverID " +
                           "and " +
                           "Licenses.IsActive=1 " +
                           "group by Drivers.DriverID, " +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "People.FirstName," +
                           "People.SecondName," +
                           "People.ThirdName," +
                           "People.LastName ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();

                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("DriverID", driverID);

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
        public async static Task<DataTable> GetAllDriversInfoByPersonID(int personID)

        {

            string query = "SELECT  Drivers.DriverID," +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "(People.FirstName+ ' ' + People.SecondName +' '+  People.ThirdName +' '+  People.LastName ) as [Full Name]," +
                           "COUNT(*)  as [Active Licenses] " +
                           "FROM Drivers " +
                           "INNER JOIN People ON Drivers.PersonID = People.ID " +
                           "INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID " +
                           "where " +
                           "PersonID=@PersonID " +
                           "and " +
                           "Licenses.IsActive=1 " +
                           "group by Drivers.DriverID, " +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "People.FirstName," +
                           "People.SecondName," +
                           "People.ThirdName," +
                           "People.LastName ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();

                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("PersonID", personID);

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
        public async static Task<DataTable> GetAllDriversInfoByNationalNo(string nationalNo)

        {

            string query = "SELECT  Drivers.DriverID," +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "(People.FirstName+ ' ' + People.SecondName +' '+  People.ThirdName +' '+  People.LastName ) as [Full Name]," +
                           "COUNT(*)  as [Active Licenses] " +
                           "FROM Drivers " +
                           "INNER JOIN People ON Drivers.PersonID = People.ID " +
                           "INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID " +
                           "where " +
                           "NationalNumber=@NationalNumber " +
                           "and " +
                           "Licenses.IsActive=1 " +
                           "group by Drivers.DriverID, " +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "People.FirstName," +
                           "People.SecondName," +
                           "People.ThirdName," +
                           "People.LastName ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();

                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("NationalNumber", nationalNo);

                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }
        public async static Task<DataTable> GetAllDriversInfoByFullName(string fullName)

        {

            string query = "SELECT  Drivers.DriverID," +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "(People.FirstName+ ' ' + People.SecondName +' '+  People.ThirdName +' '+  People.LastName ) as [Full Name]," +
                           "COUNT(*)  as [Active Licenses] " +
                           "FROM Drivers " +
                           "INNER JOIN People ON Drivers.PersonID = People.ID " +
                           "INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID " +
                           "where " +
                           "Licenses.IsActive=1 " +
                           "group by Drivers.DriverID, " +
                           "Drivers.PersonID," +
                           "People.NationalNumber," +
                           "People.FirstName," +
                           "People.SecondName," +
                           "People.ThirdName," +
                           "People.LastName " +
                           $"having (People.FirstName+ ' ' + People.SecondName +' '+  People.ThirdName +' '+  People.LastName like @pattern) ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();

                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@pattern", fullName+ "%");

                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        // Handle the exception
                    }

                    return dt;
                }
            }


        }

        public static clsDriverDTO AccessDriverByDriverId(int driverID)
        {

            clsDriverDTO driverDTO = null;
            string Query = "select * from Drivers where DriverID= @DriverID";

            if (driverID <= 0)
                throw new Exception("class ID cannot be -1 or 0");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", driverID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            int DriverID = (int)reader["DriverID"];
                            int PersonID = (int)reader["PersonID"];
                            int UserCreatedByID = (int)reader["UserCreatedByID"];
                            DateTime createdDate = (DateTime)reader["CreatedDate"];

                            
                            driverDTO = new clsDriverDTO(DriverID,clsPersonService.Find2(PersonID), UserCreatedByID, createdDate);

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

            return driverDTO;
        }
        public static clsDriverDTO AccessDriverByPersonId(int personID)
        {

            clsDriverDTO driverDTO = null;
            string Query = "select * from Drivers  where PersonID= @PersonID";

            if (personID <= 0)
                throw new Exception("class ID cannot be -1 or 0");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            int DriverID = (int)reader["DriverID"];
                            int PersonID = (int)reader["PersonID"];
                            int UserCreatedByID = (int)reader["UserCreatedByID"];
                            DateTime createdDate = (DateTime)reader["CreatedDate"];


                            driverDTO = new clsDriverDTO(DriverID, clsPersonService.Find2(PersonID), UserCreatedByID, createdDate);

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

            return driverDTO;
        }
        public static bool isExists(int personID)
        {
            bool IsFound = false;

            string Query = "SELECT DriverID FROM Drivers WHERE PersonID=@PersonID";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {

                    Command.Parameters.AddWithValue("@PersonID", personID);

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


    }

}
         