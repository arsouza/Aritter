using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
	public sealed class UsernameEqualsSpec : Specification<User>
	{
		private readonly string username;

		public UsernameEqualsSpec(string username)
		{
			this.username = username;
		}

		public override Expression<Func<User, bool>> SatisfiedBy()
		{
			return (p => p.Username == username);
		}
	}
}
