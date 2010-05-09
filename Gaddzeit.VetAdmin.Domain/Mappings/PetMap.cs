using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Gaddzeit.VetAdmin.Domain.Entities;

namespace Gaddzeit.VetAdmin.Domain.Mappings
{
    public class PetMap : ClassMap<Pet>
    {
        public PetMap()
        {
            Id(x => x.Id).Column("PetID");
            Map(x => x.Age);
            Map(x => x.Breed);
            Map(x => x.HealthHistory);
            Map(x => x.Name);
            Map(x => x.Temperament);
        }
    }
}
