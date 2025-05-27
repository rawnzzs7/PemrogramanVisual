using Aplikasi_Kediri_Mazzeh.Views;
using Kediri_mazzeh;
using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Controllers
{
    public class MenuController
    {
        private Page2 _view;

        public MenuController(Page2 view)
        {
            _view = view;
            _view.KulinerClicked += OnKulinerClicked;
            _view.PariwisataClicked += OnPariwisataClicked;
            _view.KembaliClicked += OnKembaliClicked;
        }

        private void OnKulinerClicked()
        {
            var kulinerView = new Page3();
            var kulinerController = new KulinerController(kulinerView);
            kulinerView.Show();
            _view.Hide();
        }

        private void OnPariwisataClicked()
        {
            var pariwisataView = new Page4();
            var pariwisataController = new PariwisataController(pariwisataView);
            pariwisataView.Show();
            _view.Hide();
        }

        private void OnKembaliClicked()
        {
            var mainView = new MainWindow();
            var mainController = new MainController(mainView);
            mainView.Show();
            _view.Close();
        }
    }
}