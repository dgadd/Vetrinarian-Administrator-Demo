using Gaddzeit.VetAdmin.Domain.Entities;
using NUnit.Framework;

namespace Gaddzeit.VetAdmin.Tests.Unit.Domain
{
    [TestFixture]
    public class PetTests
    {
        [Test]
        public void Constructor_NoInput_IsInstanceOfDomainEntity()
        {
            var sut = new Pet();
            Assert.IsInstanceOfType(typeof(DomainEntity), sut);
        }

        [Test]
        public void TwoInstances_SetSameId_AreEqual()
        {
            const int idValue = 3527;
            var sut1 = new Pet();
            var sut2 = new Pet();
            sut1.Id = idValue;
            sut2.Id = idValue;
            Assert.IsTrue(sut1.Equals(sut2));
        }

        [Test]
        public void Constructor_WithObjectInitializers_MatchProperties()
        {
            const string name = "Ira";
            const string breed = "pug";
            const int age = 3;
            const string temperament = "gentle";
            const string healthHistory = "breathing issues";

            var sut = new Pet
                          {
                              Name = name,
                              Breed = breed,
                              Age = age,
                              Temperament = temperament,
                              HealthHistory = healthHistory
                          };

            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(breed, sut.Breed );
            Assert.AreEqual(age, sut.Age);
            Assert.AreEqual(temperament, sut.Temperament);
            Assert.AreEqual(healthHistory, sut.HealthHistory);            
        }
    }
}
