using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
	public sealed class UserIsValidSpec : Specification<User>
	{
		public override Expression<Func<User, bool>> SatisfiedBy()
		{
			return (p =>
				p != null
				&& p.Username != null
				&& p.Password != null
				&& p.Email != null
				&& p.Person != null
				&& p.Person.FirstName != null
				&& p.Person.LastName != null);
		}
	}
}
