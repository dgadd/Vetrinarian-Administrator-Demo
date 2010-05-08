using System.Collections.Generic;
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
    public class OwnerMappingTests
    {
        private PersistenceSpecification<Owner> _persistenceSpecification;
        private Owner _owner;

        [SetUp]
        public void SetUp()
        {
            const int id = 4765;
            const string firstName = "Julie";
            const string lastName = "Li";
            var pet = new Pet {Id = 4987};
            var address = new Address("1234 Happy St", "Winnipeg", "MB", "R3B 2A2");                       

            _owner = new Owner
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Address =address
            };

            _owner.AddPet(pet);

            var sameOwnerPlacedIntoSession = new Owner
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };

            sameOwnerPlacedIntoSession.AddPet(pet);

            var sessionSource = FluentNHibernateMappingTester.GetNHibernateSessionWithWrappedEntity(sameOwnerPlacedIntoSession);
            _persistenceSpecification = new PersistenceSpecification<Owner>(sessionSource, new DomainEntityComparer());
        }

        [Test]
        public void Constructor_NoInputs_IsInstanceOfClassMappingOwner()
        {
            var sut = new OwnerMap();
            sut.ShouldBeInstanceOf<ClassMap<Owner>>();
        }

        [Test]
        public void AllProperties_CompareByType_MapIsVerified()
        {
            _persistenceSpecification
                .CheckProperty(c => c.Id, _owner.Id)
                .CheckProperty(c => c.FirstName, _owner.FirstName)
                .CheckProperty(c => c.LastName, _owner.LastName)
                .CheckProperty(c => c.Pets, _owner.Pets)
                .CheckProperty(c => c.Address, _owner.Address)
                .VerifyTheMappings();
        }

    }
}
