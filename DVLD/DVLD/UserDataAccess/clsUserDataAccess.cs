using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionClassLibrary;
using System.Timers;
using System.Diagnostics.Eventing.Reader;
using System.Collections;
using System.Runtime.InteropServices;
namespace UserDataAccess
{
    public class clsUserDataAccess
    {

        private static readonly HashSet<string> allowedColumns = new HashSet<string>
        {
            "ID","PersonID","UserName","Password","Salt","isActive"
        };
        private static bool isValidColumn(string columnName)
        {
            return allowedColumns.Contains(columnName);
        }

        private static string ConnectionString = clsConnectionServer.connectionString;
        public static int AddNewUser(int personID, string UserName,
         string Password, string Salt,bool isActive)
        {

            {
                int NewUserID = -1;

                string Query = "INSERT INTO Users (PersonID,UserName,Password,Salt,isActive)"+
                "VALUES (@PersonID,@UserName,@Password,@Salt,@isActive);" +
                "SELECT SCOPE_IDENTITY();";

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", personID);
                        Command.Parameters.AddWithValue("@UserName", UserName);
                        Command.Parameters.AddWithValue("@Password", Password);
                        Command.Parameters.AddWithValue("@Salt", Salt);
                        Command.Parameters.AddWithValue("@isActive", isActive);
                        try
                        {
                            Connection.Open();

                            object result = Command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int generatedID))
                            {
                                NewUserID = generatedID;
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

                return NewUserID;

            }

        }
        public static bool AccessUserById( int ID, ref int personID,ref string userName, ref string password, ref
            string salt, ref bool isActive)
        {
            bool isFound = false;
            string Query = "select * from Users where ID= @ID";

            if (ID ==-1|| !isValidColumn("ID"))
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            ID = (int)reader["ID"];
                            personID = (int)reader["PersonID"];
                            userName = reader["UserName"].ToString();
                            password = reader["Password"].ToString();
                            salt = reader["salt"].ToString();
                            isActive = (bool)reader["IsActive"];
                            
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
        public static bool AccessUserByUserName(string userName,ref int ID, ref int personID,  ref string password, ref
         string salt, ref bool isActive)
        {
            bool isFound = false;
            string Query = "select * from Users where UserName= @UserName";

            if ( !isValidColumn("UserName"))
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            ID = (int)reader["ID"];
                            personID = (int)reader["PersonID"];
                            userName = reader["UserName"].ToString();
                            password = reader["Password"].ToString();
                            salt = reader["salt"].ToString();
                            isActive = (bool)reader["IsActive"];

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

        public static bool AccessUserHashAndSaltById(int ID,ref string currentHashedPassword, ref string salt )
        {
            bool isFound = false;
            string Query = "SELECT ID,Password ,Salt FROM Users where ID = @ID";

            if (ID == -1 || !isValidColumn("ID"))
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            ID = (int)reader["ID"];
                            currentHashedPassword = reader["Password"].ToString();
                            salt = reader["salt"].ToString();
                            isFound = true;
                        }


                        reader.Close();
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }

                    connection.Close();
                }
            }

            return isFound;
        }
        public static bool AccessUserHashAndSaltByUserName( string userName, ref string currentHashedPassword, ref string salt)
        {
            bool isFound = false;
            string Query = "SELECT ID,Password ,Salt FROM Users where userName = @userNameParam";

            if (!isValidColumn("UserName"))
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@userNameParam", userName);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            currentHashedPassword = reader["Password"].ToString();
                            salt = reader["salt"].ToString();
                            isFound = true;
                        }


                        reader.Close();
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }

                    connection.Close();
                }
            }

            return isFound;
        }

        public async static Task<DataTable> GetAllUsersInfo()
        {

            string query = "SELECT " +
                "U.ID," +
                "U.PersonID," +
                "(P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName," +
                "U.UserName, U.isActive " +
                "FROM Users U INNER JOIN People P ON U.PersonID = P.ID";
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
        public async static Task<DataTable> GetAllUsersInfoByUserID(int userId)
        {

            string query = "SELECT " +
                "U.ID," +
                "U.PersonID," +
                "(P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName," +
                "U.UserName, U.isActive " +
                "FROM Users U INNER JOIN People P ON U.PersonID = P.ID " +
                "WHERE " +
                "U.ID =@ID;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();
                    command.Parameters.AddWithValue("@ID", userId);
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
                   
                    finally {
                        connection.Close();
                    }
                    return dt;
                }
            }



        }
        public async static Task<DataTable> GetAllUsersInfoByPersonID(int personId)
        {

            string query = "SELECT " +
                "U.ID," +
                "U.PersonID," +
                "(P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName," +
                "U.UserName, U.isActive " +
                "FROM Users U INNER JOIN People P ON U.PersonID = P.ID " +
                "WHERE " +
                "P.ID =@ID;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();
                    command.Parameters.AddWithValue("@ID", personId);
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

        public async static Task<DataTable> GetAllUsersInfoByIsActive(int value)
        {

            string query = "SELECT " +
                "U.ID," +
                "U.PersonID," +
                "(P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName," +
                "U.UserName, " +
                "U.isActive " +
                "FROM Users U INNER JOIN People P ON U.PersonID = P.ID " +
                "WHERE U.isActive = @value;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();
                    command.Parameters.AddWithValue("@value", value);

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
        public static async Task<DataTable> GetAllUsersByColumnAsync(string columnName, string columnValue)
        {
            if (!string.IsNullOrEmpty(columnValue.ToString()) && isValidColumn(columnName))
            {
                string query ="SELECT " +
                " U.ID," +
                " U.PersonID," +
                "(P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName," +
                " U.UserName,  U.isActive " +
                "FROM Users U INNER JOIN People P ON  U.PersonID = P.ID " +
                $"WHERE [{columnName}] like @param";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@param", columnValue+"%");

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

        public static bool isThisPersonHasUser(int personID)
        {

            string Query = "  SELECT ID FROM users WHERE PersonID = @PersonID";
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@PersonID", personID);
                    try
                    {
                        connection.Open();


                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;
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
                    return isFound;
                }
            }
        }
        public static bool isUserNameUnique(string inputUserName)
        {

            string Query = "SELECT UserName FROM users WHERE UserName= @UserName";
            bool isUnique= true;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@UserName", inputUserName);
                    try
                    {
                        connection.Open();


                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isUnique = false;
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
                    return isUnique;
                }
            }
        }
        public static bool IsExist(int ID)
        {

            {
                bool IsFound = false;

                string Query = "SELECT ID FROM Users WHERE ID =@ID ";

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

        public static bool IsExist(string userName)
        {

            {
                bool IsFound = false;

                string Query = "SELECT ID FROM Users WHERE UserName =@userNameInput";

                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@userNameInput", userName);

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

        public static bool UpdateUserInfo(int userID,
        string userName, string password,string salt, bool isActive)
        {
            //You can't update user ID . 


            bool IsUpdated = false;

            string Query = "UPDATE Users SET" +
            " userName=@userName," +
            " password=@password," +
            " salt=@salt," +
            " isActive=@isActive WHERE ID=@ID";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@UserName", userName);
                    Command.Parameters.AddWithValue("@Password", password);
                    Command.Parameters.AddWithValue("@Salt", salt);
                    Command.Parameters.AddWithValue("@isActive", isActive);
                    Command.Parameters.AddWithValue("@ID", userID);

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

        public static int returnPersonIDByUserID(int userID)
        {
            string Query = "SELECT PersonID FROM Users WHERE ID= @ID";
            if (userID == -1 || !isValidColumn("PersonID"))
            {
                return -1;
            }
            int personID = -1;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", userID);

                    try
                    {
                        connection.Open();
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            personID = (int)result;
                        }
                    }


                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    connection.Close();
                }
            }

            return personID;
        }

        public static (string UserName, bool IsActive)  returnUserNameAndIsActiveByUserID(int userID)
        {

            {
                string Query = "SELECT UserName, isActive FROM Users WHERE ID= @ID";
                if (userID == -1 || !isValidColumn("PersonID") || !isValidColumn("isActive"))
                {
                    return ("", false);
                }
                string userName="";
                bool isActive= false; 
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", userID);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                userName = reader["UserName"].ToString();
                                isActive = (bool)reader["isActive"];
                            }
                        }


                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                        connection.Close();
                    }
                }
                     return (userName, isActive);
                
            }
        }

        public static bool DeleteUserInfo( List<int> IDs)
        {

            bool IsDeleted = false;

            string Query = "DELETE FROM Users WHERE ID IN (" + string.Join(", ", IDs.Select(id => $"@id{id}")) + ")";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    foreach (int id in IDs)
                    {
                        Command.Parameters.AddWithValue($"@ID{id}", id);
                    }

                    try
                    {
                        Connection.Open();

                        int EffectedRows = Command.ExecuteNonQuery();
                        if (EffectedRows ==IDs.Count)
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

    }
}
