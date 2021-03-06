﻿using System;
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

        public void HomeViewInitialize(object sender, System.EventArgs e)
        {
            _homeView.PageTitle = string.Format("Welcome to M-V-P site. Logged in at {0}", DateTime.Now.ToString());
        }
    }
}