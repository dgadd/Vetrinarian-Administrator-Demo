using Gaddzeit.VetAdmin.View;

namespace Gaddzeit.VetAdmin.Presenter
{
    public class HomePresenter
    {
        private readonly IHomeView _homeView;

        public HomePresenter(IHomeView homeView)
        {
            _homeView = homeView;

            _homeView.Initialize += new System.EventHandler(HomeViewInitialize);
        }

        static void HomeViewInitialize(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}