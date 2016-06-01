using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
    public class HaveUserNameSpec : Specification<User>
    {
        private readonly string userName;

        public HaveUserNameSpec(string userName)
        {
            this.userName = userName;
        }

        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            return (p => p.UserName == userName);
        }
    }
}
