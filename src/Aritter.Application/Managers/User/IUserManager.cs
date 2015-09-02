using Aritter.Domain.Aggregates;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Application.Managers
{
	public interface IUserManager : IApplicationManager
	{
		Task<User> FindAsync(string userName, string password);
		Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType);
	}
}