using FluentNHibernate.Mapping;
using Gaddzeit.VetAdmin.Domain.Entities;

namespace Gaddzeit.VetAdmin.Domain.Mappings
{
    public class OwnerMap : ClassMap<Owner>
    {
        public OwnerMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Pets)
                .Cascade.All()
                .Inverse()
                .Table("Pet");

            Component(x => x.Address, m =>
            {
                m.Map(x => x.Street);
                m.Map(x => x.City);
                m.Map(x => x.Province);
                m.Map(x => x.PostalCode);
            });
        }
    }
}