using Aritter.Domain.Seedwork.Specs;
using System;

namespace Aritter.Domain.Security.Aggregates.Specs
{
    public static class ClientSpecs
    {
        public static Specification<Client> HasUID(Guid uid)
        {
            return new DirectSpecification<Client>(p => p.UID == uid);
        }
    }
}
