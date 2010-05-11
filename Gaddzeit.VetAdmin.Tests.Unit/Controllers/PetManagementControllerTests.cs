using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gaddzeit.VetAdmin.Domain.Entities;
using Gaddzeit.VetAdmin.Repository;
using MvcContrib.TestHelper;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using Rhino.Mocks;
using VetAdminMvc2.Controllers;
using VetAdminMvc2.Models;

namespace Gaddzeit.VetAdmin.Tests.Unit.Controllers
{
    [TestFixture]
    public class PetManagementControllerTests
    {
        private IPetRepository _petRepository;

        [SetUp]
        public void SetUp()
        {
            _petRepository = MockRepository.GenerateStub<IPetRepository>();
        }

        [Test]
        public void FindAllMethod_PageInput_ReturnsPageOfRowResults()
        {
            var petsList = new List<Pet>
                               {
                                   new Pet {Name = "Fido", Breed = "beagle", Age = 3, Temperament = "gentle"},
                                   new Pet {Name = "Ira", Breed = "pug", Age = 5, Temperament = "gentle"},
                                   new Pet {Name = "Clarence", Breed = "beagle mix", Age = 2, Temperament = "gentle"},
                                   new Pet {Name = "Sandy", Breed = "mixed", Age = 9, Temperament = "gentle"},
                                   new Pet
                                       {Name = "Melody", Breed = "american shorthair", Age = 4, Temperament = "gentle"},
                                   new Pet {Name = "Skinny", Breed = "barn cat", Age = 10, Temperament = "gentle"},
                                   new Pet {Name = "Jenny", Breed = "blue heeler", Age = 2, Temperament = "gentle"},
                                   new Pet {Name = "Roger", Breed = "calico", Age = 14, Temperament = "gentle"},
                               };

            var petsSet = new HashSet<Pet>(petsList);

            _petRepository.Stub(petRep => petRep.FindAll()).Return(petsSet);


            const int howManyRowsPerPage = 3;
            const int whichPage = 2;
            var petsSubset = _petRepository.FindAll()
                .Skip((whichPage - 1) * howManyRowsPerPage)
                .Take(howManyRowsPerPage)
                .ToList();

            var sut = new PetManagementController(_petRepository);
            var viewResult = (ViewResult) sut.FindAll(howManyRowsPerPage, whichPage);

            viewResult.ViewData.Model.ShouldEqual(petsSubset);
            viewResult.AssertViewRendered().ViewName.ShouldEqual("");
        }

        [Test]
        public void AddPetMethod_NoInput_ReturnsInstructionalMessage()
        {
            var sut = new PetManagementController(_petRepository);
            var viewResult = (ViewResult)sut.AddPet();

            viewResult.ViewData["Message"].ShouldBe("Please enter details for this pet.");
            viewResult.AssertViewRendered().ViewName.ShouldEqual("");
        }

        [Test]
        public void SavePetMethod_AddPetFormReponseInputsAreValid_SavesToRepository()
        {
            var apfr = new AddPetFormResponse
                                          {Name = "Fido", Breed = "pug", Age = 3, HealthHistory = "breathing problems"};

            var pet = new Pet
            {
                Name = apfr.Name,
                Breed = apfr.Breed,
                Age = apfr.Age.HasValue ? apfr.Age.Value : 0,
                HealthHistory = apfr.HealthHistory,
                ModifiedBy = "unit test"
            };
            _petRepository.SavePet(pet);
            
            var sut = new PetManagementController(_petRepository);
            var viewResult = (ViewResult) sut.SavePet(apfr);

            viewResult.ViewData["Message"].ShouldBe(string.Format("{0} has been added to VetAdmin.", apfr.Name));
            viewResult.AssertViewRendered().ViewName.ShouldEqual("");
        }
    }
}
