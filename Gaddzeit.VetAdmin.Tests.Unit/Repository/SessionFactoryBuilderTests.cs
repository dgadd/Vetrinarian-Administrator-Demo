using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Repository.NHibernateRepositories;
using MvcContrib.TestHelper;
using NBehave.Spec.NUnit;
using NHibernate;
using NUnit.Framework;
using Gaddzeit.VetAdmin.Domain.Entities;

namespace Gaddzeit.VetAdmin.Tests.Unit.Repository
{
    [TestFixture]
    public class SessionFactoryBuilderTests
    {

        [Test]
        public void GetSqlLiteSessionFactoryMethod_NoInputParams_ReturnsISessionFactory()
        {
            var sut = new SessionFactoryBuilder();
            var result = sut.CreateSqlLiteSessionFactory();

            result.ShouldBeInstanceOf<ISessionFactory>();
        }

        [Test]
        public void GetSqlLiteSessionFactoryMethod_NoInputParams_ShouldContainEntityMappings()
        {
            try
            {
                ICollection<string> expectedContainer = new List<string>
                                            {
                                                "Gaddzeit.VetAdmin.Domain.Entities.Owner",
                                                "Gaddzeit.VetAdmin.Domain.Entities.Pet"
                                            };

                var sut = new SessionFactoryBuilder();
                var result = sut.CreateSqlLiteSessionFactory();

                result.GetAllClassMetadata().Keys.ShouldEqual(expectedContainer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
