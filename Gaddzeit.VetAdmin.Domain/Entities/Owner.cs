using System.Collections.Generic;
using Gaddzeit.VetAdmin.Domain.DomainServices;

namespace Gaddzeit.VetAdmin.Domain.Entities
{
    public class Owner : DomainEntity
    {
        public Owner()
        {
            Pets = new HashSet<Pet>();
        }

        public virtual Address Address { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual HashSet<Pet> Pets { get; private set; }

        public virtual void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        public virtual void RemovePet(Pet pet)
        {
            Pets.Remove(pet);
        }
    }
}