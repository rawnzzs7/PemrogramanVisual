using System.Windows;

namespace KediriMazzeh
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MasukMenu_Click(object sender, RoutedEventArgs e)
        {
            // Arahkan ke halaman 2
            Page2 page2 = new Page2();
            page2.Show();
            this.Close();  // Menutup halaman 1
        }
    }
}
