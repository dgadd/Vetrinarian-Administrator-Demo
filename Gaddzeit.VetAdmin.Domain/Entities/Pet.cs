
using System;

namespace Gaddzeit.VetAdmin.Domain.Entities
{
    public class Pet : DomainEntity
    {
        public virtual string HealthHistory { get; set; }
        public virtual string Temperament { get; set; }
        public virtual string Name { get; set; }

        public virtual string Breed { get; set; }

        public virtual int Age { get; set; }

        public virtual string ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}