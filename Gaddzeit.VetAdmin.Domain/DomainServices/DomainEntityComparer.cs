using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gaddzeit.VetAdmin.Domain.DomainServices
{
    public class DomainEntityComparer : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x is DomainEntity && y is DomainEntity)
                return ((DomainEntity)x).Id == ((DomainEntity)y).Id;
            if (x is string && y is string)
                return x.ToString().Equals(y.ToString());
            if (x is decimal && y is decimal)
                return Convert.ToDecimal(x).Equals(Convert.ToDecimal(y));
            if (x is int && y is int)
                return int.Parse(x.ToString()).Equals(int.Parse(y.ToString()));
            throw new EqualityComparerUnhandledComparisonException();
        }

        public int GetHashCode(object obj)
        {
            if (obj is DomainEntity)
                return ((DomainEntity)obj).GetHashCode();
            if (obj is string)
                return obj.ToString().GetHashCode();
            if (obj is decimal)
                return Convert.ToDecimal(obj).GetHashCode();
            if (obj is int)
                return int.Parse(obj.ToString()).GetHashCode();
            throw new EqualityComparerUnhandledComparisonException();
        }
    }

}
