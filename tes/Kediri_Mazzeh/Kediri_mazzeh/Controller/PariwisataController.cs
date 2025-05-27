using Aplikasi_Kediri_Mazzeh.Views;
using System.Windows;

namespace Aplikasi_Kediri_Mazzeh.Controllers
{
    public class PariwisataController
    {
        private Page4 _view;

        public PariwisataController(Page4 view)
        {
            _view = view;
            _view.PariwisataClicked += OnPariwisataClicked;
            _view.KembaliClicked += OnKembaliClicked;
        }

        private void OnPariwisataClicked()
        {
            var komentarView = new Page5();
            var komentarController = new KomentarController(komentarView, "Pariwisata");
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