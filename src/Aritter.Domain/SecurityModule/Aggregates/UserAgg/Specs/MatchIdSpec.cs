using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
    public class MatchIdSpec : Specification<User>
    {
        private readonly int id;

        public MatchIdSpec(int id)
        {
            this.id = id;
        }

        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            return (p => p.Id == id);
        }
    }
}
