using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Views
{
    public partial class Page3 : Window
    {
        public delegate void MakananHandler();
        public delegate void KembaliHandler();

        public event MakananHandler MakananClicked;
        public event KembaliHandler KembaliClicked;

        public Page3()
        {
            InitializeComponent();
        }

        private void Makanan_Click(object sender, RoutedEventArgs e)
        {
            MakananClicked?.Invoke();
        }

        private void KembaliPage2_Click(object sender, RoutedEventArgs e)
        {
            KembaliClicked?.Invoke();
        }
    }
}