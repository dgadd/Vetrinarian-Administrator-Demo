using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VetAdminMvc2.Models;

namespace Gaddzeit.VetAdmin.Tests.Unit.Controllers
{
    [TestFixture]
    public class AddPetFormResponseTests
    {
        [Test]
        public void Constructor_NullOrEmptyProperties_ErrorPropertyReportsMissingValues()
        {
            var apfr = new AddPetFormResponse { Name = "", Breed = "", Age = 0, HealthHistory = "breathing problems" };

            var nameCheck = apfr["Name"];
            var breekCheck = apfr["Breed"];
            var ageCheck = apfr["Age"];

            const string expectedErrorMessage = "Please enter the pet's name.Please enter the pet's breed.Please enter the pet's age.";

            Assert.AreEqual(expectedErrorMessage, apfr.Error);
        }

    }
}
