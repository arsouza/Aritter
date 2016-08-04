using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
	public sealed class ValidUserSpec : Specification<User>
	{
		public override Expression<Func<User, bool>> SatisfiedBy()
		{
			return (p =>
				p != null
				&& p.Username != null
				&& p.Password != null
				&& p.Email != null
				&& p.Profile != null
				&& p.Profile.FirstName != null
				&& p.Profile.LastName != null);
		}
	}
}
