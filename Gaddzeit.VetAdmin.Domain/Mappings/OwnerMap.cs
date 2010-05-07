using FluentNHibernate.Mapping;

namespace Gaddzeit.VetAdmin.Domain.Mappings
{
    public class OwnerMap : ClassMap<Owner>
    {
        public OwnerMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            References(x => x.Pets);

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