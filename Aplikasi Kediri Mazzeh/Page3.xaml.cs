using System.Windows;

namespace KediriMazzeh
{
    public partial class Page3 : Window
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Makanan_Click(object sender, RoutedEventArgs e)
        {
            // Set LastPage sebelum membuka Page5
            Page5.LastPage = "Page3";  // Menyimpan informasi bahwa Page3 adalah halaman sebelumnya

            // Arahkan ke halaman 5 dengan informasi makanan yang dipilih
            Page5 page5 = new Page5();
            page5.Show();
            this.Hide();  // Sembunyikan Page3 setelah membuka Page5
        }

        private void KembaliPage2_Click(object sender, RoutedEventArgs e)
        {
            // Kembali ke halaman 2
            Page2 page2 = new Page2();
            page2.Show();
            this.Hide();
        }
    }
}
