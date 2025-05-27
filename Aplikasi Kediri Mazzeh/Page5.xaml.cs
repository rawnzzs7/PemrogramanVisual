using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KediriMazzeh
{
    public partial class Page5 : Window
    {
        public static string LastPage { get; set; } = string.Empty;
        private DatabaseConnection dbConnection;
        private Komentar komentarEdit; // Menyimpan komentar yang sedang diedit

        public Page5()
        {
            InitializeComponent();
            this.Closed += Page5_Closed; // Event handler untuk menutup aplikasi dengan benar

            dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();
            LoadKomentars();
        }

        // Event handler untuk menutup aplikasi saat halaman ditutup
        private void Page5_Closed(object sender, EventArgs e)
        {
            dbConnection.CloseConnection();  // Menutup koneksi database
            Application.Current.Shutdown();  // Menutup aplikasi dengan benar
        }

        private void LoadKomentars()
        {
            // Load komentar dari database dan tampilkan di DataGrid
            List<Komentar> komentarList = dbConnection.GetKomentars();
            komentarDataGrid.ItemsSource = komentarList;
        }

        private void KategoriComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear itemComboBox saat kategori berubah
            itemComboBox.Items.Clear();

            if (kategoriComboBox.SelectedItem is ComboBoxItem selectedKategori)
            {
                string kategori = selectedKategori.Content.ToString();

                // Menambahkan item sesuai kategori yang dipilih
                switch (kategori)
                {
                    case "Kuliner":
                        itemComboBox.Items.Add("Tahu Takwa");
                        itemComboBox.Items.Add("Sate Bekicot");
                        itemComboBox.Items.Add("Pecel Tumpang");
                        itemComboBox.Items.Add("Gethuk Pisang");
                        itemComboBox.Items.Add("Stik Tahu");
                        break;

                    case "Pariwisata":
                        itemComboBox.Items.Add("Kampung Inggris");
                        itemComboBox.Items.Add("Air Terjun Dolo");
                        itemComboBox.Items.Add("SLG");
                        itemComboBox.Items.Add("Candi Surowono");
                        itemComboBox.Items.Add("Gunung Kelud");
                        break;
                }

                // Pilih item pertama jika ada
                if (itemComboBox.Items.Count > 0)
                    itemComboBox.SelectedIndex = 0;
            }
        }

        private void TambahKomentar_Click(object sender, RoutedEventArgs e)
        {
            // Pastikan kategori, item, dan komentar terisi dengan benar
            if (kategoriComboBox.SelectedItem is ComboBoxItem kategoriItem &&
                itemComboBox.SelectedItem is string item &&
                !string.IsNullOrWhiteSpace(komentarTextBox.Text))
            {
                dbConnection.AddKomentar(kategoriItem.Content.ToString(), item, komentarTextBox.Text);
                LoadKomentars();
                komentarTextBox.Clear();
                MessageBox.Show("Berhasil menambahkan komentar!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Harap lengkapi semua isian sebelum menambahkan komentar.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EditKomentar_Click(object sender, RoutedEventArgs e)
        {
            // Pastikan ada komentar yang dipilih untuk diedit
            if (komentarDataGrid.SelectedItem is Komentar selectedKomentar)
            {
                // Simpan komentar yang dipilih untuk diedit
                komentarEdit = selectedKomentar;

                // Isi form dengan data komentar yang dipilih
                kategoriComboBox.SelectedItem = FindComboBoxItem(selectedKomentar.Kategori);
                itemComboBox.SelectedItem = selectedKomentar.Item;
                komentarTextBox.Text = selectedKomentar.KomentarText;

                MessageBox.Show("Anda dapat mengedit komentar ini.", "Edit Komentar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Pilih komentar yang ingin diedit.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private ComboBoxItem FindComboBoxItem(string kategori)
        {
            // Mencari ComboBoxItem berdasarkan kategori
            foreach (ComboBoxItem item in kategoriComboBox.Items)
            {
                if (item.Content.ToString() == kategori)
                {
                    return item;
                }
            }
            return null;
        }

        private void UpdateKomentar_Click(object sender, RoutedEventArgs e)
        {
            // Pastikan ada komentar yang dipilih untuk diedit
            if (komentarEdit != null && kategoriComboBox.SelectedItem is ComboBoxItem kategoriItem &&
                itemComboBox.SelectedItem is string item &&
                !string.IsNullOrWhiteSpace(komentarTextBox.Text))
            {
                // Update komentar yang dipilih
                dbConnection.EditKomentar(kategoriItem.Content.ToString(), item, komentarTextBox.Text);
                LoadKomentars();

                // Reset form input dan beri feedback ke pengguna
                komentarTextBox.Clear();
                MessageBox.Show("Komentar berhasil diperbarui!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Pastikan semua isian lengkap untuk update komentar.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void HapusKomentar_Click(object sender, RoutedEventArgs e)
        {
            // Pastikan ada komentar yang dipilih untuk dihapus
            if (komentarDataGrid.SelectedItem is Komentar selectedKomentar)
            {
                var result = MessageBox.Show("Apakah Anda yakin ingin menghapus komentar ini?",
                    "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    dbConnection.DeleteKomentar(selectedKomentar.Kategori, selectedKomentar.Item);
                    LoadKomentars();
                    MessageBox.Show("Komentar berhasil dihapus.", "Informasi", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Pilih komentar yang ingin dihapus.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void KembaliPageSebelumnya_Click(object sender, RoutedEventArgs e)
        {
            Window previousPage = null;

            // Cek halaman sebelumnya dan buka halaman yang sesuai
            if (LastPage == "Page3")
            {
                previousPage = new Page3();
            }
            else if (LastPage == "Page4")
            {
                previousPage = new Page4();
            }

            // Jika halaman ditemukan, tampilkan halaman sebelumnya
            if (previousPage != null)
            {
                previousPage.Show(); // Menampilkan halaman sebelumnya
                this.Hide(); // Menyembunyikan halaman Page5
            }
            else
            {
                MessageBox.Show("Halaman sebelumnya tidak ditemukan.", "Kesalahan", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
