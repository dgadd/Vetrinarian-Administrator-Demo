using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using Gaddzeit.VetAdmin.Domain;
using NHibernate;
using Rhino.Mocks;

namespace Gaddzeit.VetAdmin.Tests.Unit.Mappings
{

    public static class FluentNHibernateMappingTester
    {
        public static ISessionSource GetNHibernateSessionWithWrappedEntity<T>(T tMappedEntityWithinSession) where T : DomainEntity
        {
            var transaction = MockRepository.GenerateStub<ITransaction>();
            var session = MockRepository.GenerateStub<ISession>();
            session.Stub(s => s.BeginTransaction()).Return(transaction);
            session.Stub(s => s.Get<T>(null)).IgnoreArguments().Return(tMappedEntityWithinSession);
            session.Stub(s => s.GetIdentifier(tMappedEntityWithinSession)).Return(tMappedEntityWithinSession.Id);

            var sessionSource = MockRepository.GenerateStub<ISessionSource>();
            sessionSource.Stub(ss => ss.CreateSession()).Return(session);
            return sessionSource;
        }
    }
}
