using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Gaddzeit.VetAdmin.Repository;
using NUnit.Framework;
using Rhino.Mocks;
using VetAdminMvc.Controllers;

namespace Gaddzeit.VetAdmin.Tests.Unit
{
    [TestFixture]
    public class PetManagementControllerTests
    {
        private MockRepository _mockRepository;
        private IPetRepository _petRepository;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _petRepository = _mockRepository.StrictMock<IPetRepository>();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.ReplayAll();
            _mockRepository.VerifyAll();
        }

        [Test]
        public void AddPetMethod_PetInstanceInput_RedirectsToRouteResult()
        {


            _mockRepository.ReplayAll();

            var sut = new PetManagementController(_petRepository);
            var viewResult = (ViewResult)sut.AddPet();

            Assert.AreEqual("Please enter details for this pet.", viewResult.ViewData["Message"]);
        }
    }
}
