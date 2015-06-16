using Aritter.Manager.Domain.Aggregates;
using System.Collections.Generic;

namespace Aritter.Manager.Domain.Services.MainModule
{
	public interface IUserDomainService : IDomainService
	{
		int AuthenticateUser(string username, string password);
		ResetPasswordResult ResetPassword(string mailAddress);
		User GetUser(int id);
		bool CheckChangePasswordRequired(int userId);
		IEnumerable<Resource> GetMenus(int userId);
		IEnumerable<Rule> GetRules(int userId, string area, string controller, string action);
		User GetUserToChangePassword(string token);
		void ChangePassword(int userId, string currentPassword, string newPassword);
	}
}
