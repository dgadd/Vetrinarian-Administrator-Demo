using System;
using FluentNHibernate.Mapping;
using FluentNHibernate.Testing;
using Gaddzeit.VetAdmin.Domain.DomainServices;
using Gaddzeit.VetAdmin.Domain.Entities;
using Gaddzeit.VetAdmin.Domain.Mappings;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace Gaddzeit.VetAdmin.Tests.Unit.Mappings
{
    [TestFixture]
    public class PetMappingTests
    {
        private PersistenceSpecification<Pet> _persistenceSpecification;
        private Pet _pet;

        [SetUp]
        public void SetUp()
        {
            const int id = 3527;
            const string name = "Ira";
            const string breed = "pug";
            const int age = 3;
            const string temperament = "gentle";
            const string healthHistory = "breathing issues";
            var modifiedBy = "unit test";
            var modifiedDate = DateTime.Today;

            _pet = new Pet
            {
                Id = id,
                Name = name,
                Breed = breed,
                Age = age,
                Temperament = temperament,
                HealthHistory = healthHistory,
                ModifiedBy = modifiedBy,
                ModifiedDate = modifiedDate
            };

            var samePetPlacedIntoSession = new Pet
            {
                Id = id,
                Name = name,
                Breed = breed,
                Age = age,
                Temperament = temperament,
                HealthHistory = healthHistory,
                ModifiedBy = modifiedBy,
                ModifiedDate = modifiedDate
            };

            var sessionSource = FluentNHibernateMappingTester.GetNHibernateSessionWithWrappedEntity(samePetPlacedIntoSession);
            _persistenceSpecification = new PersistenceSpecification<Pet>(sessionSource, new DomainEntityComparer());
        }

        [Test]
        public void Constructor_NoInputs_IsInstanceOfClassMappingPet()
        {
            var sut = new PetMap();
            sut.ShouldBeInstanceOf<ClassMap<Pet>>();
        }

        [Test]
        public void AllProperties_CompareByType_MapIsVerified()
        {
            _persistenceSpecification
                .CheckProperty(c => c.Id, _pet.Id)
                .CheckProperty(c => c.Age, _pet.Age)
                .CheckProperty(c => c.Breed, _pet.Breed)
                .CheckProperty(c => c.HealthHistory, _pet.HealthHistory)
                .CheckProperty(c => c.Name, _pet.Name)
                .CheckProperty(c => c.Temperament, _pet.Temperament)
                .VerifyTheMappings();
        }

    }
}
