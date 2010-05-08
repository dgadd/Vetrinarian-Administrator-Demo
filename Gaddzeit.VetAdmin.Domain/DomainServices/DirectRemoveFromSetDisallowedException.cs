using System;

namespace Gaddzeit.VetAdmin.Domain.DomainServices
{
    public class DirectRemoveFromSetDisallowedException : Exception
    {
        public override string Message
        {
            get
            {
                return "Use RemoveAssociatedEntityFromParentWithinDomain(T) instead.";
            }
        }

    }
}