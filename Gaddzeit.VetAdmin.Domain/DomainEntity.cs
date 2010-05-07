namespace Gaddzeit.VetAdmin.Domain
{
    public class DomainEntity
    {
        public virtual int Id { get; set; }

        public override bool Equals(object obj)
        {
            var other = (DomainEntity) obj;
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}