using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Domain;
using NUnit.Framework;

namespace Gaddzeit.VetAdmin.Tests.Unit
{
    [TestFixture]
    public class PetTests
    {
        [Test]
        public void Constructor_NameBreedAgeIdInput_MatchesProperties()
        {
            const string petName = "Fido";
            const string breed = "pug";
            const int age = 8;
            var id = Guid.NewGuid();
            var sut = new Pet(petName, breed, age, id);
            Assert.AreEqual(petName, sut.PetName);
            Assert.AreEqual(breed, sut.Breed);
            Assert.AreEqual(age, sut.Age);
            Assert.AreEqual(id, sut.Id);
        }

        [Test]
        public void ConstructorForTwoInstances_SameInputs_AreEqual()
        {
            const string petName = "Fido";
            const string breed = "pug";
            const int age = 8;
            var id = Guid.NewGuid();
            var sut1 = new Pet(petName, breed, age, id);
            var sut2 = new Pet(petName, breed, age, id);
            Assert.IsTrue(sut1.Equals(sut2));
        }
    }
}
