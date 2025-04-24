using System.Windows;

namespace KediriMazzeh
{
    public partial class Page5 : Window
    {
        public Page5()
        {
            InitializeComponent();
        }

        private void KembaliHalaman_Click(object sender, RoutedEventArgs e)
        {
            // Kembali ke halaman sebelumnya
            Page3 page3 = new Page3();
            page3.Show();
            this.Close();
        }
    }
}
