using ConnectionClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSettings
{
    public  class clsTestTypeRepository
    {
        private class testType
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Fees { get; set; }

            public testType(string title, string description, decimal fees)
            {
                Title = title;
                Description = description;
                Fees = fees;
            }
        }
        
        private Dictionary<int, testType> _testTypesDictionray = new Dictionary<int, testType>();

        public clsTestTypeRepository() 
        { 
            LoadTestTypesFromDatabase();
        }

        private void LoadTestTypesFromDatabase()
        {
            // Assume you have a method to get your database connection
            using (var connection = new SqlConnection(clsConnectionServer.connectionString))
            {
                var command = new SqlCommand("SELECT * FROM TestTypes", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);

                        testType testType = new testType( ((string)reader["Title"]),((string)reader["Description"]),
                        ((decimal)reader["Fees"]));
                        _testTypesDictionray[id] = testType;
                    }
                }
            }
        }
        public decimal GetFeesTestType(int id)
        {
            if (_testTypesDictionray.TryGetValue(id, out testType testType))
            {
                return testType.Fees;
            }

            return -1; // Or handle this case as needed
        }
        public int GetTestTypeIdByTitle(enTestType testType)
        {
            // Check if the test types are already loaded into the dictionary
            if (_testTypesDictionray.Count == 0)
            {
                LoadTestTypesFromDatabase();
            }

            // Search for the test type by title
            var entry = _testTypesDictionray.FirstOrDefault(t => t.Value.Title.Equals(testType.ToString(), StringComparison.OrdinalIgnoreCase));

            // If found, return the corresponding ID
            if (!entry.Equals(default(KeyValuePair<int, testType>)))
            {
                return entry.Key;
            }

            // If not found, you can decide to return a default value, throw an exception, or handle it as needed
            throw new KeyNotFoundException("Test type with the given title not found.");
        }

    }
}
