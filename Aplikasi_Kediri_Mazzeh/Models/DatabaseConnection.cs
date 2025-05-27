using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Aplikasi_Kediri_Mazzeh.Models
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;
        private string connectionString = "Server=localhost;Database=kediri_mazzeh;Uid=root;Pwd=;";

        public DatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Koneksi gagal: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            try
            {
                OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query: " + ex.Message);
            }
        }

        public List<Dictionary<string, object>> ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            var results = new List<Dictionary<string, object>>();

            try
            {
                OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i);
                            }
                            results.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query: " + ex.Message);
            }

            return results;
        }
    }
}