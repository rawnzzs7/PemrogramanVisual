using System.Windows;

namespace KediriMazzeh
{
    public partial class Page2 : Window
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Kuliner_Click(object sender, RoutedEventArgs e)
        {
            // Arahkan ke halaman 3
            Page3 page3 = new Page3();
            page3.Show();
            this.Close();
        }

        private void Pariwisata_Click(object sender, RoutedEventArgs e)
        {
            // Arahkan ke halaman 4
            Page4 page4 = new Page4();
            page4.Show();
            this.Close();
        }

        private void KembaliMenu_Click(object sender, RoutedEventArgs e)
        {
            // Kembali ke halaman utama (Menu)
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
