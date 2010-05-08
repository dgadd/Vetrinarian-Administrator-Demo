using System.Collections.Generic;
using Gaddzeit.VetAdmin.Domain.Entities;

namespace Gaddzeit.VetAdmin.Repository
{
    public interface IPetRepository
    {
        void SavePet(Pet pet);
        IList<Pet> FindAll();
    }
}