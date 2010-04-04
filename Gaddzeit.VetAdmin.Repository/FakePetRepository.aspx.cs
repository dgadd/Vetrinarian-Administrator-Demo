using System;
using Gaddzeit.VetAdmin.Domain;

namespace Gaddzeit.VetAdmin.Repository
{
    public class FakePetRepository : IPetRepository
    {
        public void SavePet(Pet pet)
        {
            // call to db or other persitance storage goes here
        }
    }
}