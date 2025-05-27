using Aplikasi_Kediri_Mazzeh.Models;
using Aplikasi_Kediri_Mazzeh.Views;
using Kediri_mazzeh;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Controllers
{
    public class KomentarController
    {
        private Page5 _view;
        private DatabaseConnection _db;
        private string _kategori;

        public KomentarController(Page5 view, string kategori)
        {
            _view = view;
            _kategori = kategori;
            _db = new DatabaseConnection();

            _view.Loaded += OnViewLoaded;
            _view.KategoriChanged += OnKategoriChanged;
            _view.TambahKomentarClicked += OnTambahKomentar;
            _view.EditKomentarClicked += OnEditKomentar;
            _view.UpdateKomentarClicked += OnUpdateKomentar;
            _view.HapusKomentarClicked += OnHapusKomentar;
            _view.KembaliClicked += OnKembaliClicked;
            _view.Closed += OnViewClosed;
        }

        private void OnViewLoaded()
        {
            LoadKomentars();
            _view.SetKategori(_kategori);
        }

        private void OnKategoriChanged(string kategori)
        {
            _kategori = kategori;
            _view.UpdateItemList(GetItemsForKategori(kategori));
        }

        private List<string> GetItemsForKategori(string kategori)
        {
            return kategori switch
            {
                "Kuliner" => new List<string> { "Tahu Takwa", "Sate Bekicot", "Pecel Tumpang", "Gethuk Pisang", "Stik Tahu" },
                "Pariwisata" => new List<string> { "Kampung Inggris", "Air Terjun Dolo", "SLG", "Candi Surowono", "Gunung Kelud" },
                _ => new List<string>()
            };
        }

        private void LoadKomentars()
        {
            try
            {
                string query = "SELECT kategori, item, komentar_text FROM komentar";
                var results = _db.ExecuteQuery(query);

                var komentarList = new List<Komentar>();
                foreach (var row in results)
                {
                    komentarList.Add(new Komentar
                    {
                        Kategori = row["kategori"].ToString(),
                        Item = row["item"].ToString(),
                        KomentarText = row["komentar_text"].ToString()
                    });
                }

                _view.UpdateKomentarList(komentarList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat komentar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnTambahKomentar(string kategori, string item, string komentarText)
        {
            try
            {
                string query = "INSERT INTO komentar (kategori, item, komentar_text) VALUES (@kategori, @item, @komentarText)";
                var parameters = new Dictionary<string, object>
                {
                    { "@kategori", kategori },
                    { "@item", item },
                    { "@komentarText", komentarText }
                };

                int affectedRows = _db.ExecuteNonQuery(query, parameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Komentar berhasil ditambahkan!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadKomentars();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan komentar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnEditKomentar(Komentar komentar)
        {
            _view.SetFormData(komentar);
        }

        private void OnUpdateKomentar(string kategori, string item, string komentarText)
        {
            try
            {
                string query = "UPDATE komentar SET komentar_text = @komentarText WHERE kategori = @kategori AND item = @item";
                var parameters = new Dictionary<string, object>
                {
                    { "@kategori", kategori },
                    { "@item", item },
                    { "@komentarText", komentarText }
                };

                int affectedRows = _db.ExecuteNonQuery(query, parameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Komentar berhasil diperbarui!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadKomentars();
                    _view.ClearForm();
                }
                else
                {
                    MessageBox.Show("Komentar tidak ditemukan", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui komentar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnHapusKomentar(string kategori, string item)
        {
            try
            {
                string query = "DELETE FROM komentar WHERE kategori = @kategori AND item = @item";
                var parameters = new Dictionary<string, object>
                {
                    { "@kategori", kategori },
                    { "@item", item }
                };

                int affectedRows = _db.ExecuteNonQuery(query, parameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Komentar berhasil dihapus!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadKomentars();
                }
                else
                {
                    MessageBox.Show("Komentar tidak ditemukan", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus komentar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnKembaliClicked()
        {
            Window previousWindow = _kategori switch
            {
                "Kuliner" => new Page3(),
                "Pariwisata" => new Page4(),
                _ => new MainWindow()
            };

            previousWindow.Show();
            _view.Close();
        }

        private void OnViewClosed()
        {
            _db.CloseConnection();
        }
    }
}