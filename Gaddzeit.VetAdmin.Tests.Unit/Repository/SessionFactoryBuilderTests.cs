using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Repository.NHibernateRepositories;
using Gaddzeit.VetAdmin.Shared;
using MvcContrib.TestHelper;
using NBehave.Spec.NUnit;
using NHibernate;
using NUnit.Framework;
using Gaddzeit.VetAdmin.Domain.Entities;
using NHibernate.Context;

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

        [Test]
        public void GetSqlServerSessionFactoryMethod_NoInputParams_ReturnsISessionFactory()
        {
            var sut = new SessionFactoryBuilder();
            var result = sut.CreateSqlServerSessionFactory();

            result.ShouldBeInstanceOf<ISessionFactory>();
        }

        [Test]
        public void GetSqlServerSessionFactoryMethod_NoInputParams_ShouldContainConnectionString()
        {
            var sut = new SessionFactoryBuilder();
            var result = sut.CreateSqlServerSessionFactory();
            var session = result.OpenSession();
            CurrentSessionContext.Bind(session);

            session.Connection.ConnectionString.Contains("sql2k803").ShouldBeTrue();
        }

        [Test]
        public void GetSqlServerSessionFactoryMethod_NoInputParams_ShouldContainEntityMappings()
        {
            try
            {
                ICollection<string> expectedContainer = new List<string>
                                            {
                                                "Gaddzeit.VetAdmin.Domain.Entities.Owner",
                                                "Gaddzeit.VetAdmin.Domain.Entities.Pet"
                                            };

                var sut = new SessionFactoryBuilder();
                var result = sut.CreateSqlServerSessionFactory();

                result.GetAllClassMetadata().Keys.ShouldEqual(expectedContainer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
