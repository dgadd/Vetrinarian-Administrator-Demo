using Gaddzeit.VetAdmin.Domain;

namespace Gaddzeit.VetAdmin.Repository
{
    public interface IPetRepository
    {
        void SavePet(Pet pet);
    }
}