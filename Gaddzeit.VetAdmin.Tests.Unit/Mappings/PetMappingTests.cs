using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Testing;
using Gaddzeit.VetAdmin.Domain;
using Gaddzeit.VetAdmin.Domain.DomainServices;
using MvcContrib.TestHelper;
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

            var identicalPet = new Pet
            {
                Name = name,
                Breed = breed,
                Age = age,
                Temperament = temperament,
                HealthHistory = healthHistory
            };

            var sessionSource = FluentNHibernateMappingTester.GetNHibernateSessionWithWrappedEntity(identicalPet);
            _persistenceSpecification = new PersistenceSpecification<Pet>(sessionSource, new DomainEntityComparer());
        }

        [Test]
        public void IdProperty_Get_MapIsVerified()
        {

            _persistenceSpecification.CheckProperty(p => p.Id, _pet.Id).VerifyTheMappings();
        }

        [Test]
        public void AgeProperty_Get_MapIsVerified()
        {
            _persistenceSpecification.CheckProperty(p => p.Age, _pet.Age).VerifyTheMappings();
        }

        [Test]
        public void BreedProperty_Get_MapIsVerified()
        {
            _persistenceSpecification.CheckProperty(p => p.Breed, _pet.Breed).VerifyTheMappings();
        }

        [Test]
        public void HealthHistoryProperty_Get_MapIsVerified()
        {
            _persistenceSpecification.CheckProperty(p => p.HealthHistory, _pet.HealthHistory).VerifyTheMappings();
        }

        [Test]
        public void NameProperty_Get_MapIsVerified()
        {
            _persistenceSpecification.CheckProperty(p => p.Name, _pet.Name).VerifyTheMappings();
        }

        [Test]
        public void TemperamentProperty_Get_MapIsVerified()
        {
            _persistenceSpecification.CheckProperty(p => p.Temperament, _pet.Temperament).VerifyTheMappings();
        }
    }
}
