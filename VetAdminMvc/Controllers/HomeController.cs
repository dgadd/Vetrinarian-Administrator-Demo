using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetAdminMvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = string.Format("Welcome to ASP.NET MVC site. Logged in at {0}", DateTime.Now.ToString());

            return View();
        }
    }
}
