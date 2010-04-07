using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Gaddzeit.VetAdmin.Domain;
using Gaddzeit.VetAdmin.Repository;
using NUnit.Framework;
using Rhino.Mocks;
using VetAdminMvc.Controllers;
using VetAdminMvc.Models;

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
        public void AddPetMethod_NoInput_ReturnsInstructionalMessage()
        {
            _mockRepository.ReplayAll();

            var sut = new PetManagementController(_petRepository);
            var viewResult = (ViewResult)sut.AddPet();

            Assert.AreEqual("Please enter details for this pet.", viewResult.ViewData["Message"]);
        }

        [Test]
        public void SavePetMethod_FormFieldsInput_SavesToRepository()
        {
            var apfr = new AddPetFormResponse
                                          {Name = "Fido", Breed = "pug", Age = 3, HealthHistory = "breathing problems"};
            var id = Guid.NewGuid();

            var pet = new Pet(apfr.Name, apfr.Breed, apfr.Age.Value) { HealthHistory = apfr.HealthHistory };

            _petRepository.SavePet(pet);
            
            _mockRepository.ReplayAll();

            var sut = new PetManagementController(_petRepository);
            var viewResult = (ViewResult) sut.SavePet(apfr);

            Assert.AreEqual("Pet details have been saved.", viewResult.ViewData["message"]);
        }
    }
}
