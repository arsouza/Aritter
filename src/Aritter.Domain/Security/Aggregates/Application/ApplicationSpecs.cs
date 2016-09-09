using Aritter.Domain.Seedwork.Specs;
using System;

namespace Aritter.Domain.Security.Aggregates.Specs
{
    public static class ApplicationSpecs
    {
        public static Specification<Application> HasUID(Guid uid)
        {
            return new DirectSpecification<Application>(p => p.UID == uid);
        }
    }
}
