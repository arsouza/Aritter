using Aritter.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Domain.Services
{
	public class UserDomainService : DomainService, IUserDomainService
	{
		public UserDomainService(
			IRepository repository)
			: base(repository)
		{
		}

		public virtual async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
			};

			var identity = new ClaimsIdentity(claims, authenticationType);

			return await Task.FromResult(identity);
		}
	}
}
