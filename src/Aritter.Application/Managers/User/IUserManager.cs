using Aritter.Domain.Aggregates;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Application.Managers
{
	public interface IUserManager : IApplicationManager
	{
		bool CheckChangePasswordRequired(int userId);
		ResetPasswordResult ResetPassword(string mailAddress);
		User GetUser(int id);
		IEnumerable<Resource> GetMenus(int userId);
		IEnumerable<Rule> GetRules(int userId, string area, string controller, string action);
		int AuthenticateUser(string username, string password);
		User GetUserBySecurityToken(string token);
		void ChangePassword(int userId, string currentPassword, string newPassword);
		Task<IUser> FindAsync(string userName, string password);
		Task<ClaimsIdentity> GenerateUserIdentityAsync(string authenticationType);
	}
}