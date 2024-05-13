using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionClassLibrary;
using DVLD.DTOs;
using GlobalSettings;
namespace _LicenseDataAccess
{
    public class clsLicesnseClassDataAccess
    {
        private static string ConnectionString = clsConnectionServer.connectionString;

        public async static Task<DataTable> GetAllLicenseClassesInfo()

        {

            string query = $"SELECT * FROM LicenseClasses";

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
        public async static Task<DataTable> GetAllLicenseClassesIDAndTitle()

        {

            string query = "SELECT ClassID ,Title from LicenseClasses;";


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
        public static clsLicenseClassDTO AccessLicenseClassById(int licenseClassID)
        {
            clsLicenseClassDTO licenseClassDTO = null;

            string Query = "select * from LicenseClasses where ClassID= @ClassID";

            if (licenseClassID <= 0)
                throw new Exception("class ID cannot be -1 or 0");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", licenseClassID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                             licenseClassDTO = new clsLicenseClassDTO(

                            (int)reader["ClassID"],
                            reader["Title"].ToString(),
                            reader["Description"].ToString(),
                            (byte)reader["MinAllowedAge"],
                            (byte)reader["ValidityLength"],
                            (decimal)reader["Fees"]
                            
                            );

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

            return licenseClassDTO;
        }
        public static clsLicenseClassDTO AccessLicenseClassByEnumLicenseClass(enLicenseClass enLicenseClass)
        {
            clsLicenseClassDTO licenseClassDTO = null;

            string Query = "select * from LicenseClasses where ClassID= @ClassID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", (int)enLicenseClass);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            licenseClassDTO = new clsLicenseClassDTO(

                           (int)reader["ClassID"],
                           reader["Title"].ToString(),
                           reader["Description"].ToString(),
                           (byte)reader["MinAllowedAge"],
                           (byte)reader["ValidityLength"],
                           (decimal)reader["Fees"]

                           );

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

            return licenseClassDTO;
        }

    }
}
