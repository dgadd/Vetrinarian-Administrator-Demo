using System;
using System.Collections.Generic;
using System.Linq;
using Gaddzeit.VetAdmin.Domain;

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