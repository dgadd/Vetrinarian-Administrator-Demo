using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Domain;
using Gaddzeit.VetAdmin.Repository.NHibernateRepositories;
using NUnit.Framework;
using Gaddzeit.VetAdmin.Repository;

namespace Gaddzeit.VetAdmin.Tests.Integration
{
    [TestFixture]
    public class NHibernatePetRepositoryTests
    {
        [Test]
        public void Constructor_NoInputParams_IsInstanceOfIPetRepository()
        {
            var sut = new NHibernatePetRepository();
            Assert.IsInstanceOfType(typeof(IPetRepository), sut);
        }

        [Test]
        [Ignore("Rather than mapping legacy XML, will switch to FluentNHibernate in next while.")]
        public void FindAllMethod_NoInputParams_ReturnsSandboxedDatabaseValues()
        {
            var expectedPets = new List<Pet>
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
                               }.AsQueryable(); 

            var sut = new NHibernatePetRepository();
            var petsFromDb = sut.FindAll();

            Assert.AreSame(expectedPets, petsFromDb, "Expected sandboxed db values not retrieved.");
        }
    }
}
