using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Domain.DomainServices;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace Gaddzeit.VetAdmin.Tests.Unit.Domain
{
    [TestFixture]
    public class DomainEntityComparerTests
    {
        [Test]
        public void Constructor_NoInputParams_ImplementsIEqualityComparer()
        {
            var sut = new DomainEntityComparer();
            sut.ShouldBeInstanceOf<IEqualityComparer>();
        }

        [Test]
        public void DomainEntityComparer_ComparedOnString_ReturnsEqualTrue()
        {
            const string stringToCompare = "red";
            var sut = new DomainEntityComparer();
            sut.Equals(stringToCompare, stringToCompare).ShouldBeTrue();
        }

        public class FakeClass { }

        [Test]
        [ExpectedException(typeof(EqualityComparerUnhandledComparisonException))]
        public void DomainEntityComparer_ComparedOnClassNotHandledByEqualsMethod_ThrowsException()
        {
            var fakeClassForTesting = new FakeClass();
            var sut = new DomainEntityComparer();
            sut.Equals(fakeClassForTesting, fakeClassForTesting);
        }
    }
}
