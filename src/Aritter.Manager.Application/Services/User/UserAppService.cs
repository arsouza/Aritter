using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Domain.Services.MainModule;
using System;
using System.Collections.Generic;

namespace Aritter.Manager.Application.Services
{
	public class UserAppService : AppService, IUserAppService
	{
		private readonly IUserDomainService userDomainService;

		public UserAppService(IUserDomainService userDomainService)
		{
			if (userDomainService == null)
				throw new ArgumentNullException("userDomainService");

			this.userDomainService = userDomainService;
		}

		public bool CheckChangePasswordRequired(int userId)
		{
			return this.userDomainService.CheckChangePasswordRequired(userId);
		}

		public User GetUser(int id)
		{
			return this.userDomainService.GetUser(id);
		}

		public IEnumerable<Resource> GetMenus(int userId)
		{
			return this.userDomainService
				.GetMenus(userId);
		}

		public IEnumerable<Rule> GetRules(int userId, string area, string controller, string action)
		{
			return this.userDomainService
				.GetRules(userId, area, controller, action);
		}

		public int AuthenticateUser(string username, string password)
		{
			return this.userDomainService
				.AuthenticateUser(username, password);
		}

		public ResetPasswordResult ResetPassword(string mailAddress)
		{
			return this.userDomainService.ResetPassword(mailAddress);
		}

		public User GetUserToChangePassword(string token)
		{
			return this.userDomainService.GetUserToChangePassword(token);
		}

		public void ChangePassword(int userId, string currentPassword, string newPassword)
		{
			this.userDomainService.ChangePassword(userId, currentPassword, newPassword);
		}
	}
}