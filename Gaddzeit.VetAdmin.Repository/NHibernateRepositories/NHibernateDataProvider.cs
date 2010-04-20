using System;
using NHibernate;
using NHibernate.Cfg;

namespace Gaddzeit.VetAdmin.Repository.NHibernateRepositories
{
    public static class NHibernateDataProvider
    {
        private static readonly ISessionFactory _sessionFactory;
        private static ISession _currentSession;

        static NHibernateDataProvider()
        {
            _sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory;
            }
        }

        public static ISession CurrentSession
        {
            get
            {
                if (_currentSession == null || !_currentSession.IsOpen)
                {
                    _currentSession = _sessionFactory.OpenSession();
                }
                return _currentSession;
            }
        }
    }
}