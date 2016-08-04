using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
	public sealed class DuplicatedUserSpec : Specification<User>
	{
		private readonly string Username;
		private readonly string Email;

		public DuplicatedUserSpec(string username, string email)
		{
			Username = username;
			Email = email;
		}

		public override Expression<Func<User, bool>> SatisfiedBy()
		{
			return (p => p.Username == Username || p.Email == Email);
		}
	}
}
