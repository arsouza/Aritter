using Aritter.Manager.Domain.Aggregates;
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
				throw new InvalidOperationException("The first name is required.");

			if (string.IsNullOrEmpty(user.LastName))
				return user.FirstName;

			return string.Format("{0} {1}", user.FirstName, user.LastName);
		}
	}
}
