using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Repository.NHibernateRepositories;
using NUnit.Framework;
using System.Threading;
using System.Reflection;

namespace Gaddzeit.VetAdmin.Tests.Integration
{
    [TestFixture]
    public class NHibernateDataProviderTests
    {
        [Test]
        public void Class_IsStatic()
        {
            Assert.IsTrue(IsStatic(typeof(NHibernateDataProvider)));
        }

        public bool IsStatic(Type type)
        {
            return type.IsAbstract && type.IsSealed;
        }


        [Test]
        public void SessionFactoryProperty_Get_IsNotNull()
        {
            Assert.IsNotNull(NHibernateDataProvider.SessionFactory);
        }

        [Test]
        public void CurrentSessionProperty_Get_IsOpen()
        {
            Assert.IsNotNull(NHibernateDataProvider.CurrentSession.IsOpen);
        }

        [Test]
        public void CurrentSessionProperty_Get_IsStatic()
        {
            var matchingMethods =
                typeof (NHibernateDataProvider).GetMethods().Where(
                    methodInfo => methodInfo.Name.Equals("CurrentSession"));

            foreach(var methodInfo in matchingMethods)
            {
                Assert.IsTrue(methodInfo.IsStatic);
            }
        }

    }
}
