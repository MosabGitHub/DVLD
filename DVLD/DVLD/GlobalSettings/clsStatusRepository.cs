using ConnectionClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSettings
{
    public  class clsStatusRepository
    {

        private  Dictionary<int, enStatus> _statusDictionary = new Dictionary<int, enStatus>();
        public clsStatusRepository()
        {
            LoadStatusesFromDatabase();
        }

        private  void LoadStatusesFromDatabase()
        {
            // Assume you have a method to get your database connection
            using (var connection = new SqlConnection(clsConnectionServer.connectionString))
            {
                var command = new SqlCommand("SELECT ID, Name FROM ApplicationStatues", connection);
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
        }
        private enStatus getEnStatusByString(string title)
        {
            switch(title.ToLower().Trim())
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
        public enStatus GetStatusTitle(int id)
        {
            if (_statusDictionary.TryGetValue(id, out enStatus enStatus))
            {
                return enStatus;
            }

            return enStatus.New; // Or handle this case as needed
        }
        public  int GetStatusId(enStatus status)
        {
            //Lambda Expression kvp => kvp.Value.Equals(title, StringComparison.OrdinalIgnoreCase):

            //KVP : Key value pair
            var entry  =_statusDictionary.FirstOrDefault(kvp => kvp.Value.Equals(status));
            if (!status.Equals(default(KeyValuePair<int, enStatus>)))
            {
                return entry.Key;
            }

            return -1; // Or handle this case as needed
        }
        private  Dictionary<int, enStatus> GetAllStatuses()
        {
            return new Dictionary<int, enStatus>(_statusDictionary);
        }
    
    }

}
