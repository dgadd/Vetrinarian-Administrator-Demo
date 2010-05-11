using System.Collections.Generic;
using System.Linq;
using Gaddzeit.VetAdmin.Domain.Entities;
using Gaddzeit.VetAdmin.Repository;
using Gaddzeit.VetAdmin.Repository.NHibernateRepositories;
using MvcContrib.TestHelper;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace Gaddzeit.VetAdmin.Tests.Integration
{
    [TestFixture]
    public class PetRepositoryNHbnTests
    {
        [Test]
        public void Constructor_NoInputParams_IsInstanceOfIPetRepository()
        {
            var sut = new PetRepositoryNHbn();
            Assert.IsInstanceOfType(typeof(IPetRepository), sut);
        }

        [Test]
        public void SaveMethod_PetInput_IsSuccessful()
        {
            var sut = new PetRepositoryNHbn();
            var pet = new Pet() {Age = 8, Breed = "pug", Name = "Integration Test Record", Temperament = "cheery", ModifiedBy = "unit test"};
            sut.SavePet(pet);
            pet.Id.ShouldBeGreaterThan(0);
        }

        [Test]
        public void FindAllMethod_NoInputParams_ReturnsSandboxedDatabaseValues()
        {
            var expectedPetsList = new List<Pet>
                                   {
                                       new Pet {Id = 1},
                                       new Pet {Id = 2},
                                       new Pet {Id = 3},
                                       new Pet {Id = 4},
                                       new Pet {Id = 5},
                                       new Pet {Id = 6},
                                       new Pet {Id = 7},
                                       new Pet {Id = 8},
                                       new Pet {Id = 9},
                                       new Pet {Id = 10},
                                       new Pet {Id = 11},
                                       new Pet {Id = 12},
                                       new Pet {Id = 13},
                                       new Pet {Id = 14},
                                       new Pet {Id = 15},
                                       new Pet {Id = 16},
                                       new Pet {Id = 17},
                                       new Pet {Id = 18},
                                       new Pet {Id = 19}
                                   };

            var expectedPetsSet = new HashSet<Pet>(expectedPetsList);

            var sut = new PetRepositoryNHbn();
            var petsFromRepository = sut.FindAll();

            foreach(var pet in expectedPetsSet)
            {
                petsFromRepository.ShouldContain(pet);
            }
        }
    }
}
