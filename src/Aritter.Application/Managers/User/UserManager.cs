using Aritter.Domain;
using Aritter.Domain.Aggregates;
using Aritter.Domain.Services;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Application.Managers
{
	public class UserManager : ApplicationManager, IUserManager
	{
		private readonly IUserDomainService userDomainService;
		private readonly IRepository repository;

		public UserManager(IUserDomainService userDomainService)
		{
			if (userDomainService == null)
				throw new ArgumentNullException(nameof(userDomainService));

			this.userDomainService = userDomainService;
		}

		public async Task<User> FindAsync(string userName, string password)
		{
			return await repository.GetAsync<User>(p => p.UserName == userName && p.PasswordHash == password);
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(string authenticationType)
		{
			return await Task.FromException<ClaimsIdentity>(new NotImplementedException());
		}
	}
}