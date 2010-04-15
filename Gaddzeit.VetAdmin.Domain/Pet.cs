using System;

namespace Gaddzeit.VetAdmin.Domain
{
    public class Pet : DomainEntity
    {
        public string HealthHistory { get; set; }
        public string Temperament { get; set; }
        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }
    }
}