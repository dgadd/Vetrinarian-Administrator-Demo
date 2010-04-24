using System.Collections.Generic;
using System.Linq;
using Gaddzeit.VetAdmin.Domain;

namespace Gaddzeit.VetAdmin.Repository
{
    public interface IPetRepository
    {
        void SavePet(Pet pet);
        IList<Pet> FindAll();
    }
}