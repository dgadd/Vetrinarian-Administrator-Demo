using System;

namespace Gaddzeit.VetAdmin.Domain
{
    public class Owner : DomainEntity
    {
        private readonly CustomSet<Pet> _pets;

        public Owner()
        {
            _pets = new CustomSet<Pet>();
        }

        public Address Address { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public void AddPet(Pet pet)
        {
            _pets.AddAssociatedEntityToParentWithinDomain(pet);
        }

        public void RemovePet(Pet pet)
        {
            _pets.RemoveAssociatedEntityFromParentWithinDomain(pet);
        }

        public CustomSet<Pet> Pets
        {
            get { return _pets; }
        }

    }
}