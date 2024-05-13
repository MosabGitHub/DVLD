using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConnectionClassLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;


namespace _PersonDataAccess
{
    public class clsPersonDataAccess
    {

        private static readonly HashSet<string> allowdColumns = new HashSet<string>
        {
            "ID","NationalNumber","FirstName","SecondName","ThirdName","LastName","Gender","Birth","PhoneNumber","Email","Address","Nationality"
            ,"PersonImagePath"
        };

        private static bool IsValidColumnName(string columnName)
        {
            return allowdColumns.Contains(columnName);
        }
        private static void LogError(Exception ex)
        {
            string logPath = "errorlog.txt"; // Path to your log file
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine("Date/Time: " + DateTime.Now.ToString());
                writer.WriteLine("Message: " + ex.Message);
                writer.WriteLine("StackTrace: " + ex.StackTrace);
                writer.WriteLine("-------------------------------------------------");
            }
        }
       
        private static string ConnectionString = clsConnectionServer.connectionString;
        public static bool AccessPersonInfoByID(int ID, ref string NationalNumber,
            ref string FirstName, ref string secondName,ref string ThirdName, ref string LastName, ref char Gender, ref DateTime Birth
            , ref string PhoneNumber, ref string Email,ref string Address ,ref string Nationality, ref string personalImagePath)
        {
            bool isFound = false;
            string Query = "SELECT * FROM People WHERE ID =@ID";

            SqlConnection Connection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ID", ID);


            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    ID = (int)reader["ID"];
                    NationalNumber = reader["NationalNumber"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    secondName = reader["SecondName"].ToString();
                    ThirdName= reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Gender = Convert.ToChar(reader["Gender"].ToString().Trim());
                    Birth = (DateTime)reader["Birth"];
                    PhoneNumber = reader["PhoneNumber"].ToString().Trim();
                    Email= reader["Email"].ToString().Trim();
                    Address = reader["Address"].ToString();
                    Nationality = reader["Nationality"].ToString();
                    personalImagePath = reader["PersonImagePath"].ToString();
                    isFound = true;
                }

                else
                {
                    ID = -1;//Couldn't find Person , with such an Id 

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Connection.Close();

            return isFound;

        }

        public static bool AccessPersonInfoByNationalNumber(ref int ID, string NationalNumber,
           ref string FirstName, ref string secondName, ref string ThirdName, ref string LastName, ref char Gender, ref DateTime Birth
           , ref string PhoneNumber, ref string Email, ref string Address, ref string Nationality, ref string personalImagePath)
        {
            bool isFound = false;
            string Query = "SELECT * FROM People WHERE NationalNumber =@NationalNumber";

            SqlConnection Connection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);


            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    ID = (int)reader["ID"];
                    NationalNumber = reader["NationalNumber"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    secondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Gender = Convert.ToChar(reader["Gender"].ToString().Trim());
                    Birth = (DateTime)reader["Birth"];
                    PhoneNumber = reader["PhoneNumber"].ToString();
                    Email = reader["Email"].ToString().Trim();
                    Address = reader["Address"].ToString();
                    Nationality = reader["Nationality"].ToString();
                    personalImagePath = reader["PersonImagePath"].ToString();
                    isFound = true;
                }

                else
                {
                    ID = -1;//Couldn't find Person , with such an Id 

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Connection.Close();

            return isFound;

        }
        public static async Task<DataTable>GetAllPeopleByColumnAsync(string columnName, object columnValue)
        {
            if (!string.IsNullOrEmpty(columnValue.ToString()) && IsValidColumnName(columnName))
            {
                string query = $"SELECT * FROM People WHERE [{columnName}] =@param";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@param", columnValue);
                        
                        DataTable dt = new DataTable();

                        try
                        {

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
                            {


                                if (reader.HasRows)
                                {
                                    dt.Load(reader);
                                }

                                reader.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        connection.Close();

                        return dt;
                    }
                }
            }
            else
            {

                return null;
            }
        
        } 
        public async static Task<DataTable> GetAllPeopleInfo()
        {
            
                string query = $"SELECT * FROM People";

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
                        }

                        return dt;
                    }
                }

          

        }
        public static bool IsExist(int ID,string NationalNo )
        {

            {
                bool IsFound = false;
                string Query= " select  ID from people where ID =@ID and NationalNumber = @NationalNumber"; 

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@ID", ID);
                        Command.Parameters.AddWithValue("@NationalNumber", NationalNo);

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
        public static bool IsExist(int ID)
        {

            {
                bool IsFound = false;

                string Query = "SELECT ID FROM People WHERE ID =@ID ";

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@ID", ID);

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
        public static bool IsExist(string NationalNumber)
        {
            {

                {

                    bool isFound = false ;

                    string Query = "SELECT NationalNumber FROM People WHERE NationalNumber =@NationalNumber";

                    using (SqlConnection Connection = new SqlConnection(ConnectionString))
                    {

                        using (SqlCommand Command = new SqlCommand(Query, Connection))
                        {

                            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

                            try
                            {
                                Connection.Open();

                                object result = Command.ExecuteScalar();

                                if (result != null)
                                {
                                    isFound = true;
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                    }

                    return isFound;

                }

            }
        }
        
        public static int IsExistAndReturnID(string NationalNumber)
        {
            {

                {

                    int personID = -1;

                    string Query = "SELECT ID FROM People WHERE NationalNumber =@NationalNumber";

                    using (SqlConnection Connection = new SqlConnection(ConnectionString))
                    {

                        using (SqlCommand Command = new SqlCommand(Query, Connection))
                        {

                            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

                            try
                            {
                                Connection.Open();

                                object result = Command.ExecuteScalar();

                                if (result != null)
                                {
                                    personID =(int)result;
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                    }

                    return personID;

                }

            }
        }

        public static int AddNewPerson(string NationalNumber,
             string FirstName,  string SecondName,  string ThirdName, string LastName, char Gender, DateTime Birth
            , string PhoneNumber, string Email,string Address, string Nationality, string PersonImagePath)
        {

            {
                int NewPersonID = -1;

                string Query = "INSERT INTO People (NationalNumber,FirstName,SecondName,ThirdName,LastName,Gender,Birth," +
                "PhoneNumber,Email,Address,Nationality,PersonImagePath) " +
                "VALUES (@NationalNumber,@FirstName,@SecondName,@ThirdName,@LastName," +
                "@Gender,@Birth,@PhoneNumber,@Email,@Address,@Nationality,@PersonImagePath);" +
                "SELECT SCOPE_IDENTITY();";

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                        Command.Parameters.AddWithValue("@FirstName", FirstName);
                        Command.Parameters.AddWithValue("@SecondName", SecondName);
                        Command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        Command.Parameters.AddWithValue("@LastName", LastName);
                        Command.Parameters.AddWithValue("@Gender", Gender);
                        Command.Parameters.AddWithValue("@Birth", Birth);
                        Command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        Command.Parameters.AddWithValue("@Email", Email);
                        Command.Parameters.AddWithValue("@Address", Address);
                        Command.Parameters.AddWithValue("@Nationality", Nationality);
                        Command.Parameters.AddWithValue("@PersonImagePath", string.IsNullOrEmpty(PersonImagePath)
                        ? DBNull.Value : (object)PersonImagePath);


                        try
                        {
                            Connection.Open();

                            object result = Command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int generatedID))
                            {
                                NewPersonID = generatedID;
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    Connection.Close();
                }

                return NewPersonID;//IF retrun -1 it wasn't added, If new id generated then , we can say a new person added and here is it's id.

            }

        } 

        public static bool UpdatePersonInfo(int ID ,string NationalNumber,
             string FirstName, string SecondName, string ThirdName, string LastName, char Gender, DateTime Birth
            , string PhoneNumber, string Email,string Address, string Nationality, string PersonImagePath)
        {
            
                
                    bool IsUpdated = false;

                    string Query = "UPDATE People SET NationalNumber=@NationalNumber," +
                    " FirstName=@FirstName," +
                    " SecondName=@SecondName," +
                    " ThirdName=@ThirdName," +
                    " LastName=@LastName," +
                    " Gender=@Gender," +
                    " Birth=@Birth," +
                    " PhoneNumber=@PhoneNumber," +
                    " Address=@Address," + // Added comma here
                    " Email=@Email," + // Added comma here
                    " Nationality=@Nationality," +
                    " PersonImagePath=@PersonImagePath" +
                    " WHERE ID = @ID";
                   
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
                    {

                        using (SqlCommand Command = new SqlCommand(Query, Connection))
                        {
                            Command.Parameters.AddWithValue("@ID", ID);
                            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                            Command.Parameters.AddWithValue("@FirstName", FirstName);
                            Command.Parameters.AddWithValue("@SecondName", SecondName);
                            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
                            Command.Parameters.AddWithValue("@LastName", LastName);
                            Command.Parameters.AddWithValue("@Gender", Gender);
                            Command.Parameters.AddWithValue("@Birth", Birth);
                            Command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                            Command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email)
                            ? DBNull.Value : (object)Email.Trim());
                            Command.Parameters.AddWithValue("@Address", Address);
                            Command.Parameters.AddWithValue("@Nationality", Nationality);
                            Command.Parameters.AddWithValue("@PersonImagePath", string.IsNullOrEmpty(PersonImagePath)
                            ? DBNull.Value : (object)PersonImagePath);


                    try
                    {
                        Connection.Open();

                        int EffectedRows = Command.ExecuteNonQuery();
                        if (EffectedRows > 0)
                            IsUpdated = true;

                    }  
                    catch (Exception ex)
                            {
                            LogError(ex);
                            }

                        }
                    }
            return IsUpdated;
        }
        public static bool DeletePersonInfo(ref List<int> IDs )
        {

            bool IsDeleted = false;

            string Query = "DELETE FROM People WHERE ID IN (" + string.Join(", ", IDs.Select(id => $"@id{id}")) + ")";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    foreach (int id in IDs)
                    {
                        Command.Parameters.AddWithValue($"@ID{id}",id);
                    }

                    try
                    {
                        Connection.Open();

                        int EffectedRows = Command.ExecuteNonQuery();
                        if (EffectedRows > 0)
                            IsDeleted = true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            return IsDeleted;
        }

    }//Delete and update./

}
    

