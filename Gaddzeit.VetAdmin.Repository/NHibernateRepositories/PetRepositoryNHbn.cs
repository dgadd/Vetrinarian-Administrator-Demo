using System;
using System.Collections.Generic;
using Gaddzeit.VetAdmin.Domain.Entities;
using NHibernate;

namespace Gaddzeit.VetAdmin.Repository.NHibernateRepositories
{
    public class PetRepositoryNHbn : IPetRepository
    {
        private readonly SessionFactoryBuilder _factoryBuilder;

        public PetRepositoryNHbn()
        {
            _factoryBuilder = new SessionFactoryBuilder();
        }
        public void SavePet(Pet pet)
        {
            using (var session = _factoryBuilder.CreateSqlServerSessionFactory().OpenSession())
            {
                using (session.BeginTransaction())
                {
                    pet.ModifiedDate = DateTime.Now;
                    session.Save(pet);
                    session.Transaction.Commit();
                }
            }
        }

        public HashSet<Pet> FindAll()
        {
            using (var session = _factoryBuilder.CreateSqlServerSessionFactory().OpenSession())
            {
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