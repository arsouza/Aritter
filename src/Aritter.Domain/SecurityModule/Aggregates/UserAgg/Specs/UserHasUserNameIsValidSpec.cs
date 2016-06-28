using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
    public sealed class UserHasUserNameIsValidSpec : Specification<User>
	{
		public override Expression<Func<User, bool>> SatisfiedBy()
		{
			return (p => !string.IsNullOrEmpty(p.UserName));
		}
	}
}
