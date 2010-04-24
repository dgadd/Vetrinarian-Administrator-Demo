using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gaddzeit.VetAdmin.View;
using Gaddzeit.VetAdmin.Presenter;

namespace VetAdmin
{
    public partial class _Default : System.Web.UI.Page, IHomeView
    {
        private HomePresenter _homePresenter;

        protected override void OnInit(EventArgs e)
        {
            _homePresenter = new HomePresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Initialize != null) this.Initialize(this, EventArgs.Empty);
        }

        public event EventHandler Initialize;

        public string PageTitle
        {
            set 
            {
                this.Title = value;
                lblWelcome.Text = value;
            }
        }
    }
}
