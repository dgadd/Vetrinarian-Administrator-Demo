using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Repository.NHibernateRepositories;
using MvcContrib.TestHelper;
using NBehave.Spec.NUnit;
using NHibernate;
using NUnit.Framework;

namespace Gaddzeit.VetAdmin.Tests.Unit.Repository
{
    [TestFixture]
    public class SessionFactoryBuilderTests
    {
        private const string ProductQualifiedName = "Gaddzeit.VetAdmin.Domain.Pet";

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
                var sut = new SessionFactoryBuilder();
                var result = sut.CreateSqlLiteSessionFactory();

                result.GetAllClassMetadata().Keys.ShouldContain(ProductQualifiedName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
