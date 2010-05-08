using System;
using System.Collections.Generic;
using Gaddzeit.VetAdmin.Domain.Entities;

namespace Gaddzeit.VetAdmin.Repository.NHibernateRepositories
{
    public class NHibernatePetRepository : IPetRepository
    {
        public void SavePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public IList<Pet> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}