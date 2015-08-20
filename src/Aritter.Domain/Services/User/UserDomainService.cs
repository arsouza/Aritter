using Aritter.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Domain.Services
{
	public class UserDomainService : DomainService, IUserDomainService
	{
		public UserDomainService(IRepository repository)
			: base(repository)
		{
		}

		public virtual async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType)
		{
			var roles = repository
				.Find<User>(p => p.Id == user.Id)
				.Include(p => p.UserRoles)
				.Include(p => p.UserRoles.Select(x => x.Role))
				.SelectMany(p => p.UserRoles.Select(x => x.Role))
				.ToList();

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
			};

			claims.AddRange(roles.Select(p => new Claim(ClaimTypes.Role, p.Name)));

			var identity = new ClaimsIdentity(claims, authenticationType);

			return await Task.FromResult(identity);
		}
	}
}
