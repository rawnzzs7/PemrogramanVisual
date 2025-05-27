using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace KediriMazzeh
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;

        public DatabaseConnection()
        {
            string connectionString = "Server=localhost;Database=kediri_mazzeh;Uid=root;Pwd=;";
            connection = new MySqlConnection(connectionString);
        }

        // Membuka koneksi database
        public void OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Koneksi berhasil!"); // Debugging
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Koneksi gagal: " + ex.Message);
            }
        }

        // Menutup koneksi database
        public void CloseConnection()
        {
            connection.Close();
            Console.WriteLine("Koneksi ditutup"); // Debugging
        }

        // Menambahkan komentar ke database
        public void AddKomentar(string kategori, string item, string komentarText)
        {
            // Debugging: Periksa nilai parameter yang diterima
            Console.WriteLine($"Kategori: {kategori}, Item: {item}, Komentar: {komentarText}");

            string query = "INSERT INTO komentar (kategori, item, komentar_text) VALUES (@kategori, @item, @komentarText)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@kategori", kategori);
            cmd.Parameters.AddWithValue("@item", item);
            cmd.Parameters.AddWithValue("@komentarText", komentarText);

            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Menjalankan perintah Insert untuk menambahkan komentar
                cmd.ExecuteNonQuery();
                Console.WriteLine("Komentar berhasil ditambahkan!"); // Debugging
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show("Gagal menambahkan komentar: " + ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Mengedit komentar di database
        public void EditKomentar(string kategori, string item, string komentarText)
        {
            string query = "UPDATE komentar SET komentar_text = @komentarText WHERE kategori = @kategori AND item = @item";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@kategori", kategori);
            cmd.Parameters.AddWithValue("@item", item);
            cmd.Parameters.AddWithValue("@komentarText", komentarText);

            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Mengeksekusi perintah Update
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Komentar berhasil diedit!"); // Debugging
                }
                else
                {
                    Console.WriteLine("Komentar tidak ditemukan, menambahkan komentar baru...");
                    // Jika komentar tidak ditemukan, menambahkannya
                    AddKomentar(kategori, item, komentarText); // Panggil fungsi AddKomentar untuk menambahkan
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Gagal mengedit komentar: " + ex.Message);
            }
        }

        // Mendapatkan komentar dari database
        public List<Komentar> GetKomentars()
        {
            List<Komentar> komentarList = new List<Komentar>();
            string query = "SELECT kategori, item, komentar_text FROM komentar";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Pastikan MySqlDataReader ditutup setelah selesai
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Komentar komentar = new Komentar
                        {
                            Kategori = reader.GetString(0),
                            Item = reader.GetString(1),
                            KomentarText = reader.GetString(2)
                        };
                        komentarList.Add(komentar);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Gagal mendapatkan komentar: " + ex.Message);
            }
            return komentarList;
        }

        // Menghapus komentar dari database
        public void DeleteKomentar(string kategori, string item)
        {
            string query = "DELETE FROM komentar WHERE kategori = @kategori AND item = @item";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@kategori", kategori);
            cmd.Parameters.AddWithValue("@item", item);

            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                cmd.ExecuteNonQuery();
                Console.WriteLine("Komentar berhasil dihapus!"); // Debugging
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Gagal menghapus komentar: " + ex.Message);
            }
        }
    }
}
