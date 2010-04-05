using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using VetAdminMvc.Controllers;

namespace Gaddzeit.VetAdmin.Tests.Unit
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexMethod_NoInput_ReturnsGreeting()
        {
            var message = string.Format("Welcome to ASP.NET MVC site. Logged in at {0}", DateTime.Now.ToString());
            var sut = new HomeController();
            var viewResult = (ViewResult)sut.Index();
            Assert.AreEqual(message, viewResult.ViewData["message"]);
        }
    }
}
