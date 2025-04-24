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
            // Arahkan ke halaman 5 dengan informasi makanan yang dipilih
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
