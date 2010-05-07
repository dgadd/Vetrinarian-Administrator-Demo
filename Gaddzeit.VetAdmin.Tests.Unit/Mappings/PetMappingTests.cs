using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FluentNHibernate.Mapping.Providers;
using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.Testing;
using Gaddzeit.VetAdmin.Domain;
using Gaddzeit.VetAdmin.Domain.DomainServices;
using MvcContrib.TestHelper;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using Gaddzeit.VetAdmin.Domain.Mappings;

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
            const string name = "Ira";
            const string breed = "pug";
            const int age = 3;
            const string temperament = "gentle";
            const string healthHistory = "breathing issues";

            _pet = new Pet
            {
                Name = name,
                Breed = breed,
                Age = age,
                Temperament = temperament,
                HealthHistory = healthHistory
            };

            var samePetPlacedIntoSession = new Pet
            {
                Name = name,
                Breed = breed,
                Age = age,
                Temperament = temperament,
                HealthHistory = healthHistory
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
