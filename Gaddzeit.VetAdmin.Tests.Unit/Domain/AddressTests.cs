﻿using System;
using Gaddzeit.VetAdmin.Domain.Entities;
using NUnit.Framework;

namespace Gaddzeit.VetAdmin.Tests.Unit.Domain
{
    [TestFixture]
    public class AddressTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_AllNullOrEmptyParams_ThrowsException()
        {
            var sut = new Address("", "", "", "");
        }

        [Test]
        public void TwoInstances_SameParams_AreEqual()
        {
            var sut1 = new Address("1324 Happy St.", "Winnipeg", "MB", "R3G2A2");
            var sut2 = new Address("1324 Happy St.", "Winnipeg", "MB", "R3G2A2");
            Assert.IsTrue(sut1.Equals(sut2));
        }
    }
}
