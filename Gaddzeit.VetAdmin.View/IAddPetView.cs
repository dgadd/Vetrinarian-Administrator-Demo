using System;

namespace Gaddzeit.VetAdmin.View
{
    public interface IAddPetView
    {
        event EventHandler SavePet;
        string Name { get; }
        string Breed { get; }
        int Age { get; }
        string HealthHistory { get; }
        string Message { set; get; }
    }
}