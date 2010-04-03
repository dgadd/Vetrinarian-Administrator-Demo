using System;

namespace Gaddzeit.VetAdmin.Domain
{
    public class Pet
    {
        private readonly string _petName;
        private readonly string _breed;
        private readonly int _age;
        private readonly Guid _id;

        public Pet(string petName, string breed, int age, Guid id)
        {
            _petName = petName;
            _breed = breed;
            _age = age;
            _id = id;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public int Age
        {
            get { return _age; }
        }

        public string Breed
        {
            get { return _breed; }
        }

        public string PetName
        {
            get { return _petName; }
        }

        public override bool Equals(object obj)
        {
            var other = (Pet) obj;
            return this.PetName.Equals(other.PetName)
                   && this.Breed.Equals(other.Breed)
                   && this.Age.Equals(other.Age)
                   && this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.PetName.GetHashCode() + this.Breed.GetHashCode() + this.Age.GetHashCode() +
                   this.Id.GetHashCode();
        }
    }
}