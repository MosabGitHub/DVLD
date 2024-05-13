using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalSettings;
using GlobalVariables;

using ConnectionClassLibrary;
namespace GlobalLibraryDataAccess
{
    public static class globalSettingsDataAccess
    {
        public static string ConnectionString = clsConnectionServer.connectionString;

        private static enStatus getEnStatusByString(string title)
        {
            switch (title.ToLower().Trim())
            {
                case "completed":
                    {
                        return enStatus.completed;
                    }
                case "cancelled":
                    {
                        return enStatus.cancelled;
                    }

                case "new":
                    {
                        return enStatus.New;
                    }
                default:
                    {
                        return enStatus.New;
                    }
            }
        }

        public static Dictionary<int, enStatus> LoadStatusesFromDatabase()
        {

            Dictionary<int, enStatus> _statusDictionary = new Dictionary<int, enStatus>();

            // Assume you have a method to get your database connection
            string query = "SELECT ID, Name FROM ApplicationStatues";
            using (var connection = new SqlConnection(clsConnectionServer.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string title = reader.GetString(1);

                            _statusDictionary[id] = getEnStatusByString(title);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return _statusDictionary;
        }



    }
}