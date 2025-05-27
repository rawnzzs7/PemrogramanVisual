using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Views
{
    public partial class Page4 : Window
    {
        public delegate void PariwisataHandler();
        public delegate void KembaliHandler();

        public event PariwisataHandler PariwisataClicked;
        public event KembaliHandler KembaliClicked;

        public Page4()
        {
            InitializeComponent();
        }

        private void Pariwisata_Click(object sender, RoutedEventArgs e)
        {
            PariwisataClicked?.Invoke();
        }

        private void KembaliPage2_Click(object sender, RoutedEventArgs e)
        {
            KembaliClicked?.Invoke();
        }
    }
}