using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Views
{
    public partial class MainWindow : Window
    {
        public delegate void MasukMenuHandler();
        public event MasukMenuHandler MasukMenuClicked;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MasukMenu_Click(object sender, RoutedEventArgs e)
        {
            MasukMenuClicked?.Invoke();
        }
    }
}