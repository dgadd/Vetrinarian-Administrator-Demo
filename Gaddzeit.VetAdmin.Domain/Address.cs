using System;

namespace Gaddzeit.VetAdmin.Domain
{
    public class Address
    {
        private readonly string _street;
        private readonly string _city;
        private readonly string _province;
        private readonly string _postalCode;

        public Address(string street, string city, string province, string postalCode)
        {
            RejectNullParams(street, city, province, postalCode);

            _street = street;
            _city = city;
            _province = province;
            _postalCode = postalCode;
        }

        private static void RejectNullParams(string street, string city, string province, string postalCode)
        {
            if(string.IsNullOrEmpty(street)
               && string.IsNullOrEmpty(city)
               && string.IsNullOrEmpty(province)
               && string.IsNullOrEmpty(postalCode))
                throw new ArgumentNullException();
        }

        public string PostalCode
        {
            get { return _postalCode; }
        }

        public string Province
        {
            get { return _province; }
        }

        public string City
        {
            get { return _city; }
        }

        public string Street
        {
            get { return _street; }
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