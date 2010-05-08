using System;

namespace Gaddzeit.VetAdmin.Domain.Entities
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string PostalCode { get; private set; }

        // required by NHibernate
        private Address()
        {
        }

        public Address(string street, string city, string province, string postalCode)
        {
            RejectNullParams(street, city, province, postalCode);

            Street = street;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }

        private static void RejectNullParams(string street, string city, string province, string postalCode)
        {
            if(string.IsNullOrEmpty(street)
               && string.IsNullOrEmpty(city)
               && string.IsNullOrEmpty(province)
               && string.IsNullOrEmpty(postalCode))
                throw new ArgumentNullException();
        }

        public override bool Equals(object obj)
        {
            var other = (Address) obj;
            return this.Street.Equals(other.Street)
                   && this.City.Equals(other.City)
                   && this.Province.Equals(other.Province)
                   && this.PostalCode.Equals(other.PostalCode);
        }

        public override int GetHashCode()
        {
            return this.Street.GetHashCode()
                   + this.City.GetHashCode()
                   + this.Province.GetHashCode()
                   + this.PostalCode.GetHashCode();
        }
    }
}