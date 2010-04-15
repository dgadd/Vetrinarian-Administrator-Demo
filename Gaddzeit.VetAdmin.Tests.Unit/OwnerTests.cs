using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Gaddzeit.VetAdmin.Domain;

namespace Gaddzeit.VetAdmin.Tests.Unit
{
    [TestFixture]
    public class OwnerTests
    {
        [Test]
        public void Constructor_NoInput_IsInstanceOfDomainEntity()
        {
            var sut = new Owner();
            Assert.IsInstanceOf(typeof(DomainEntity), sut);
        }

        [Test]
        public void TwoInstances_SetSameId_AreEqual()
        {
            const int idValue = 3527;
            var sut1 = new Owner();
            var sut2 = new Owner();
            sut1.Id = idValue;
            sut2.Id = idValue;
            Assert.IsTrue(sut1.Equals(sut2));
        }

        [Test]
        public void Constructor_WithObjectInitializers_MatchProperties()
        {
            const string firstName = "Julie";
            const string lastName = "Smith";
            var sut = new Owner {FirstName = firstName, LastName = lastName};
            Assert.AreEqual(firstName, sut.FirstName);
            Assert.AreEqual(lastName, sut.LastName);
        }

        [Test]
        public void AddressProperty_Set_ValidatesEquality()
        {
            const string firstName = "Julie";
            const string lastName = "Smith";
            var sut = new Owner { FirstName = firstName, LastName = lastName };
            var address = new Address("1234 Main St.", "Winnipeg", "MB", "R3B 2A2");
            sut.Address = address;
            Assert.IsTrue(sut.Address.Equals(address));
        }

        [Test]
        public void AddPetMethod_PetInput_IncrementsPetsAssociation()
        {
            const string firstName = "Julie";
            const string lastName = "Smith";
            var sut = new Owner { FirstName = firstName, LastName = lastName };

            var pet = new Pet();
            sut.AddPet(pet);

            Assert.AreEqual(1, sut.Pets.Count);
        }

        [Test]
        public void RemovePetMethod_PetInput_IncrementsPetsAssociation()
        {
            const string firstName = "Julie";
            const string lastName = "Smith";
            var sut = new Owner { FirstName = firstName, LastName = lastName };

            var pet1 = new Pet { Id = 1324 };
            var pet2 = new Pet { Id = 1325 };
            sut.AddPet(pet1);
            sut.AddPet(pet2);

            sut.RemovePet(pet1);
            Assert.AreEqual(1, sut.Pets.Count);
        }
    }
}
