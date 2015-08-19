using Aritter.Domain.Aggregates;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Domain.Services
{
	public interface IUserDomainService : IDomainService
	{
		Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType);
	}
}
