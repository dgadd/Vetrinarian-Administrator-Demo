using System;

namespace Gaddzeit.VetAdmin.Domain
{
    public class Pet
    {
        private readonly string _petName;
        private readonly string _breed;
        private readonly int _age;

        public Pet(string petName, string breed, int age)
        {
            _petName = petName;
            _breed = breed;
            _age = age;
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

        public string HealthHistory { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Pet) obj;
            return this.PetName.Equals(other.PetName)
                   && this.Breed.Equals(other.Breed)
                   && this.Age.Equals(other.Age);
        }

        public override int GetHashCode()
        {
            return this.PetName.GetHashCode() + this.Breed.GetHashCode() + this.Age.GetHashCode();
        }
    }
}