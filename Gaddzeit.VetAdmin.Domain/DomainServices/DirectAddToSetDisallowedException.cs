using System;

namespace Gaddzeit.VetAdmin.Domain.DomainServices
{
    public class DirectAddToSetDisallowedException : Exception
    {
        public override string Message
        {
            get
            {
                return "Use AddAssociatedEntityToParentWithinDomain(T) instead.";
            }
        }
    }
}