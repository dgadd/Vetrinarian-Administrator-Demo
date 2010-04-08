using System;
using System.Collections.Generic;
using System.Linq;
using Gaddzeit.VetAdmin.Domain;

namespace Gaddzeit.VetAdmin.Repository
{
    public class FakePetRepository : IPetRepository
    {
        public void SavePet(Pet pet)
        {
            // call to db or other persitance storage goes here
            throw new NotImplementedException("Next up: Add ORM to save data to database.");
        }

        public IQueryable<Pet> FindAll()
        {
            var petsList = new List<Pet> { 
                                            new Pet("Fido", "golden retriever", 3),
                                            new Pet("Ira", "pug", 8),
                                            new Pet("Clarence", "beagle mix", 10),
                                            new Pet("Sandy", "mixed", 12),
                                            new Pet("Melody", "american shorthair", 14),
                                            new Pet("Skinny", "barn cat", 4),
                                            new Pet("Jenny", "blue heeler", 5),
                                            new Pet("Roger", "calico", 12)
            };

            return petsList.AsQueryable();
        }
    }
}