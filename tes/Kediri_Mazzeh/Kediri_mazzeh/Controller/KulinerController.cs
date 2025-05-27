using Aplikasi_Kediri_Mazzeh.Views;
using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Controllers
{
    public class KulinerController
    {
        private Page3 _view;

        public KulinerController(Page3 view)
        {
            _view = view;
            _view.MakananClicked += OnMakananClicked;
            _view.KembaliClicked += OnKembaliClicked;
        }

        private void OnMakananClicked()
        {
            var komentarView = new Page5();
            var komentarController = new KomentarController(komentarView, "Kuliner");
            komentarView.Show();
            _view.Hide();
        }

        private void OnKembaliClicked()
        {
            var menuView = new Page2();
            var menuController = new MenuController(menuView);
            menuView.Show();
            _view.Close();
        }
    }
}