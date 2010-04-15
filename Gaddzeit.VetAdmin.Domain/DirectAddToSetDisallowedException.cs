using System;

namespace Gaddzeit.VetAdmin.Domain
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