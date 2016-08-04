using Aritter.Domain.SecurityModule.Aggregates.Users;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
	public static class UserFactory
	{
		public static User CreateUser(Profile person, string username, string password, string email)
		{
			var user = new User(person, username, email);
			user.ChangePassword(password);

			return user;
		}
	}
}
