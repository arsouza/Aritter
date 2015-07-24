using Aritter.Domain.Aggregates;
using System.Collections.Generic;

namespace Aritter.Application.Services
{
	public interface IUserAppService : IAppService
	{
		bool CheckChangePasswordRequired(int userId);
		ResetPasswordResult ResetPassword(string mailAddress);
		User GetUser(int id);
		IEnumerable<Resource> GetMenus(int userId);
		IEnumerable<Rule> GetRules(int userId, string area, string controller, string action);
		int AuthenticateUser(string username, string password);
		User GetUserBySecurityToken(string token);
		void ChangePassword(int userId, string currentPassword, string newPassword);
	}
}