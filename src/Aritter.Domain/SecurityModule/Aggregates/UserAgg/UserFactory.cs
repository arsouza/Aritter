using Aritter.Domain.SecurityModule.Aggregates.MainAgg;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
	public static class UserFactory
	{
		public static User CreateUser(Person person, string username, string password, string email)
		{
			var user = new User(person, username, email);
			user.ChangePassword(password);

			return user;
		}
	}
}
