using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Gaddzeit.VetAdmin.Domain
{
    public class Pet : IDataErrorInfo
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

        public string this[string propName]
        {
            get
            {
                if ((propName == "petName") && string.IsNullOrEmpty(_petName))
                    return "Please enter the pet's name.";
                if ((propName == "breed") && string.IsNullOrEmpty(_breed))
                    return "Please enter the pet's breed.";
                if ((propName == "age") && _age == 0)
                    return "Please enter the pet's age.";
                return null;
            }
        }

        public string Error
        {
            get { return null; }
        }
    }
}