using System;
using System.Collections.Generic;
using Gaddzeit.VetAdmin.Domain.Entities;
using NHibernate;

namespace Gaddzeit.VetAdmin.Repository.NHibernateRepositories
{
    public class NHibernatePetRepository : IPetRepository
    {
        private SessionFactoryBuilder _factoryBuilder;

        public NHibernatePetRepository()
        {
            _factoryBuilder = new SessionFactoryBuilder();
        }
        public void SavePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public HashSet<Pet> FindAll()
        {
            using (var session = _factoryBuilder.CreateSqlServerSessionFactory().OpenSession())
            {
                // retreive all stores and display them
                using (session.BeginTransaction())
                {
                    const string hqlQuery = "from Pet pet ";

                    HashSet<Pet> petsAsSet = null;

                    var pets = session.CreateQuery(hqlQuery)
                                .List<Pet>();

                    return new HashSet<Pet>(pets);
                }
            }
        }
    }
}