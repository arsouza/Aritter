using Aritter.Domain;
using Aritter.Domain.Aggregates;
using Aritter.Domain.Services;
using Aritter.Infra.CrossCutting.Encryption;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Application.Managers
{
	public class UserManager : ApplicationManager, IUserManager
	{
		private readonly IUserDomainService userDomainService;
		private readonly IRepository repository;

		public UserManager(
			IUserDomainService userDomainService,
			IRepository repository)
		{
			if (userDomainService == null)
				throw new ArgumentNullException(nameof(userDomainService));

			if (repository == null)
				throw new ArgumentNullException(nameof(repository));

			this.userDomainService = userDomainService;
			this.repository = repository;
		}

		public async Task<User> FindAsync(string userName, string password)
		{
			var passwordHash = Encrypter.Encrypt(password);
			var user = repository.Get<User>(p => p.UserName == userName && p.PasswordHash == passwordHash);
			return await Task.FromResult(user);
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType)
		{
			return await userDomainService.GenerateUserIdentityAsync(user, authenticationType);
		}
	}
}