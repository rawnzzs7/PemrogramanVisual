using Aplikasi_Kediri_Mazzeh.Models;
using System.Windows;
using System.Windows.Controls;

namespace Aplikasi_Kediri_Mazzeh.Views
{
    public partial class Page5 : Window
    {
        public delegate void KategoriChangedHandler(string kategori);
        public delegate void TambahKomentarHandler(string kategori, string item, string komentar);
        public delegate void EditKomentarHandler(Komentar komentar);
        public delegate void UpdateKomentarHandler(string kategori, string item, string komentar);
        public delegate void HapusKomentarHandler(string kategori, string item);
        public delegate void KembaliHandler();

        public event KategoriChangedHandler KategoriChanged;
        public event TambahKomentarHandler TambahKomentarClicked;
        public event EditKomentarHandler EditKomentarClicked;
        public event UpdateKomentarHandler UpdateKomentarClicked;
        public event HapusKomentarHandler HapusKomentarClicked;
        public event KembaliHandler KembaliClicked;

        public Page5()
        {
            InitializeComponent();
        }

        public void SetKategori(string kategori)
        {
            foreach (ComboBoxItem item in kategoriComboBox.Items)
            {
                if (item.Content.ToString() == kategori)
                {
                    kategoriComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        public void UpdateItemList(List<string> items)
        {
            itemComboBox.Items.Clear();
            foreach (var item in items)
            {
                itemComboBox.Items.Add(item);
            }
            if (itemComboBox.Items.Count > 0)
                itemComboBox.SelectedIndex = 0;
        }

        public void UpdateKomentarList(List<Komentar> komentars)
        {
            komentarDataGrid.ItemsSource = komentars;
            komentarDataGrid.Items.Refresh();
        }

        public void SetFormData(Komentar komentar)
        {
            SetKategori(komentar.Kategori);
            itemComboBox.SelectedItem = komentar.Item;
            komentarTextBox.Text = komentar.KomentarText;
        }

        public void ClearForm()
        {
            komentarTextBox.Clear();
        }

        private void KategoriComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (kategoriComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                KategoriChanged?.Invoke(selectedItem.Content.ToString());
            }
        }

        private void TambahKomentar_Click(object sender, RoutedEventArgs e)
        {
            if (kategoriComboBox.SelectedItem is ComboBoxItem kategoriItem &&
                itemComboBox.SelectedItem != null &&
                !string.IsNullOrWhiteSpace(komentarTextBox.Text))
            {
                TambahKomentarClicked?.Invoke(
                    kategoriItem.Content.ToString(),
                    itemComboBox.SelectedItem.ToString(),
                    komentarTextBox.Text);
            }
            else
            {
                MessageBox.Show("Harap lengkapi semua isian", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateKomentar_Click(object sender, RoutedEventArgs e)
        {
            if (kategoriComboBox.SelectedItem is ComboBoxItem kategoriItem &&
                itemComboBox.SelectedItem != null &&
                !string.IsNullOrWhiteSpace(komentarTextBox.Text))
            {
                UpdateKomentarClicked?.Invoke(
                    kategoriItem.Content.ToString(),
                    itemComboBox.SelectedItem.ToString(),
                    komentarTextBox.Text);
            }
            else
            {
                MessageBox.Show("Harap lengkapi semua isian", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void HapusKomentar_Click(object sender, RoutedEventArgs e)
        {
            if (komentarDataGrid.SelectedItem is Komentar selectedKomentar)
            {
                HapusKomentarClicked?.Invoke(selectedKomentar.Kategori, selectedKomentar.Item);
            }
            else
            {
                MessageBox.Show("Pilih komentar yang ingin dihapus", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void KembaliPageSebelumnya_Click(object sender, RoutedEventArgs e)
        {
            KembaliClicked?.Invoke();
        }
    }
}