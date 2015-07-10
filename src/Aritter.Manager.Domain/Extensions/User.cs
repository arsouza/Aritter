using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Exceptions;
using System;

namespace Aritter.Manager.Domain.Extensions
{
	public static class ExtensionManager
	{
		public static string GetFullName(this User user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			if (string.IsNullOrEmpty(user.FirstName))
				throw new ManagerException("The first name is required.");

			if (string.IsNullOrEmpty(user.LastName))
				return user.FirstName;

			return string.Format("{0} {1}", user.FirstName, user.LastName);
		}
	}
}
