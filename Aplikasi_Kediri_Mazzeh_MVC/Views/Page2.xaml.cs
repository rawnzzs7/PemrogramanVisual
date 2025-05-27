using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Views
{
    public partial class Page2 : Window
    {
        public delegate void KulinerHandler();
        public delegate void PariwisataHandler();
        public delegate void KembaliHandler();

        public event KulinerHandler KulinerClicked;
        public event PariwisataHandler PariwisataClicked;
        public event KembaliHandler KembaliClicked;

        public Page2()
        {
            InitializeComponent();
        }

        private void Kuliner_Click(object sender, RoutedEventArgs e)
        {
            KulinerClicked?.Invoke();
        }

        private void Pariwisata_Click(object sender, RoutedEventArgs e)
        {
            PariwisataClicked?.Invoke();
        }

        private void KembaliMenu_Click(object sender, RoutedEventArgs e)
        {
            KembaliClicked?.Invoke();
        }
    }
}