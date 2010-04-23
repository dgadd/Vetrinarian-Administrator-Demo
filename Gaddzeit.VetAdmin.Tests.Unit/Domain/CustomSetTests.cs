using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Domain;
using NUnit.Framework;

namespace Gaddzeit.VetAdmin.Tests.Unit.Domain
{
    [TestFixture]
    public class CustomSetTests
    {
        [Test]
        public void Constructor_NoInputParams_ImplementsICollection_T()
        {
            var sut = new CustomSet<DummyClass>();
            Assert.IsInstanceOfType(typeof(ICollection<DummyClass>), sut);
        }

        [Test]
        [ExpectedException(typeof(DirectAddToSetDisallowedException), ExpectedMessage = "Use AddAssociatedEntityToParentWithinDomain(T) instead.")]
        public void AddMethod_TInputParam_ThrowsDirectAddNotAllowedException()
        {
            var dummyClass = new DummyClass("fake");

            var sut = new CustomSet<DummyClass>();
            sut.Add(dummyClass);
        }

        [Test]
        public void AddAssociatedEntityToParentWithinDomainMethod_TInputParam_IncrementsCollection()
        {
            var dummyClass1 = new DummyClass("fake1");
            var dummyClass2 = new DummyClass("fake2");

            var sut = new CustomSet<DummyClass>();
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass1);
            Assert.AreEqual(1, sut.Count);
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass2);
            Assert.AreEqual(2, sut.Count);
        }

        [Test]
        [ExpectedException(typeof(DirectRemoveFromSetDisallowedException), ExpectedMessage = "Use RemoveAssociatedEntityFromParentWithinDomain(T) instead.")]
        public void RemoveMethod_TInputParam_ThrowsDirectRemoveNotAllowedException()
        {
            var dummyClass = new DummyClass("fake");

            var sut = new CustomSet<DummyClass>();
            sut.Remove(dummyClass);
        }

        [Test]
        public void RemoveAssociatedEntityFromParentWithinDomainMethod_TInputParam_IncrementsCollection()
        {
            var dummyClass1 = new DummyClass("fake1");
            var dummyClass2 = new DummyClass("fake2");

            var sut = new CustomSet<DummyClass>();
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass1);
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass2);

            sut.RemoveAssociatedEntityFromParentWithinDomain(dummyClass1);
            Assert.AreEqual(1, sut.Count);
        }

        [Test]
        public void GetEnumeratorMethod_NoInputParams_ReturnsIEnumerator_T()
        {
            var dummyClass1 = new DummyClass("fake1");
            var dummyClass2 = new DummyClass("fake2");

            var sut = new CustomSet<DummyClass>();
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass1);
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass2);

            Assert.IsInstanceOfType(typeof(IEnumerator<DummyClass>), sut.GetEnumerator());
        }

        [Test]
        public void ClearMethod_NoInputParams_ClearsTheCollection()
        {
            var dummyClass1 = new DummyClass("fake1");
            var dummyClass2 = new DummyClass("fake2");

            var sut = new CustomSet<DummyClass>();
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass1);
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass2);

            sut.Clear();
            Assert.AreEqual(0, sut.Count);
        }

        [Test]
        public void ContainsMethod_PreviouslyAddedInstance_IsFoundInSet()
        {
            var dummyClass1 = new DummyClass("fake1");
            var dummyClass2 = new DummyClass("fake2");

            var sut = new CustomSet<DummyClass>();
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass1);
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass2);

            Assert.IsTrue(sut.Contains(dummyClass1));
            Assert.IsTrue(sut.Contains(dummyClass2));
        }

        [Test]
        public void CopyToMethod_EmptyArrayAndFirstPositionInputs_FirstClassInSetEqualsArrayPositionZero()
        {
            var dummyClass1 = new DummyClass("fake1");
            var dummyClass2 = new DummyClass("fake2");

            var sut = new CustomSet<DummyClass>();
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass1);
            sut.AddAssociatedEntityToParentWithinDomain(dummyClass2);

            var dummyClassArray = new DummyClass[10];

            sut.CopyTo(dummyClassArray, 0);

            Assert.IsTrue(dummyClass1.Equals(dummyClassArray[0]));
            Assert.IsTrue(dummyClass2.Equals(dummyClassArray[1]));
        }

        [Test]
        public void IsReadOnlyProperty_Get_ReturnsFalse()
        {
            var sut = new CustomSet<DummyClass>();
            Assert.IsFalse(sut.IsReadOnly);
        }
    }

    public class DummyClass
    {
        private readonly string _name;

        public DummyClass(string name)
        {
            _name = name;
        }

        public override bool Equals(object obj)
        {
            var other = (DummyClass)obj;
            return this._name.Equals(other._name);
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }
    }
}
