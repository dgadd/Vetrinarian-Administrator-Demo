using System;
using System.Collections.Generic;
using Gaddzeit.VetAdmin.Domain.Entities;

namespace Gaddzeit.VetAdmin.Repository
{
    public class FakePetRepository : IPetRepository
    {
        public void SavePet(Pet pet)
        {
            // call to db or other persitance storage goes here
            throw new NotImplementedException("Next up: Add ORM to save data to database.");
        }

        public IList<Pet> FindAll()
        {
            var petsList = new List<Pet> { 
                                            new Pet { Name = "Fido", Breed = "beagle", Age = 3, Temperament = "gentle" },
                                            new Pet { Name = "Ira", Breed = "pug", Age = 5, Temperament = "gentle" },
                                            new Pet { Name = "Clarence", Breed = "beagle mix", Age = 2, Temperament = "gentle" },
                                            new Pet { Name = "Sandy", Breed = "mixed", Age = 9, Temperament = "gentle" },
                                            new Pet { Name = "Melody", Breed = "american shorthair", Age = 4, Temperament = "gentle" },
                                            new Pet { Name = "Skinny", Breed = "barn cat", Age = 10, Temperament = "gentle" },
                                            new Pet { Name = "Jenny", Breed = "blue heeler", Age = 2, Temperament = "gentle" },
                                            new Pet { Name = "Roger", Breed = "calico", Age = 14, Temperament = "gentle" },
            };                                            

            return petsList;
        }
    }
}