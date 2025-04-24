using System.Windows;

namespace KediriMazzeh
{
    public partial class Page4 : Window
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void Pariwisata_Click(object sender, RoutedEventArgs e)
        {
            // Arahkan ke halaman 5 dengan informasi pariwisata yang dipilih
            Page5 page5 = new Page5();
            page5.Show();
            this.Close();
        }

        private void KembaliPage2_Click(object sender, RoutedEventArgs e)
        {
            // Kembali ke halaman 2
            Page2 page2 = new Page2();
            page2.Show();
            this.Close();
        }
    }
}
