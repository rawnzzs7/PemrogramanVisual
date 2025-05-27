using Aplikasi_Kediri_Mazzeh.Views;
using Kediri_mazzeh;
using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Controllers
{
    public class MainController
    {
        private MainWindow _view;

        public MainController(MainWindow view)
        {
            _view = view;
            _view.MasukMenuClicked += OnMasukMenuClicked;
        }

        private void OnMasukMenuClicked()
        {
            var menuView = new Page2();
            var menuController = new MenuController(menuView);
            menuView.Show();
            _view.Close();
        }
    }
}