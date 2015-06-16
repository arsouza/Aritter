using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Domain.Extensions;
using Aritter.Manager.Infrastructure.Exceptions;
using Aritter.Manager.Infrastructure.Resources;
using Aritter.Manager.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Aritter.Manager.Domain.Services.MainModule
{
	public class UserDomainService : DomainService, IUserDomainService
	{
		public UserDomainService(
			IRepository repository)
			: base(repository)
		{
		}

		public bool CheckChangePasswordRequired(int userId)
		{
			var mustChangePassword = this.repository
				.Find<User>(p => p.Id == userId)
				.Select(p => p.MustChangePassword)
				.FirstOrDefault();

			return mustChangePassword;
		}

		public User GetUser(int id)
		{
			return this.repository.Get<User>(id);
		}

		public int AuthenticateUser(string username, string password)
		{
			Authentication authentication = null;

			try
			{
				var user = this.repository
					.Find<User>(p => p.Username == username)
					.Select(p => new { Id = p.Id, Password = p.Password })
					.FirstOrDefault();

				if (user == null)
				{
					authentication = this.CreateLogin(null, username);
					throw new ManagerException(Global.Message_InvalidUserPassword);
				}

				authentication = this.CreateLogin(user.Id, null);

				if (!this.CheckCredentials(user.Password, password))
					throw new ManagerException(Global.Message_InvalidUserPassword);

				if (!this.CheckPasswordAge(user.Id))
					throw new ManagerException(Global.Message_UserPasswordExpired);

				if (!this.CheckLoginAttempts(user.Id))
					throw new ManagerException(Global.Message_UserLocked);

				this.ConfirmLogin(authentication);

				return user.Id;
			}
			catch (ManagerException)
			{
				this.FailAuthentication(authentication);
				throw;
			}
			catch (Exception)
			{
				this.FailAuthentication(authentication);
				throw;
			}
			finally
			{
				this.repository.SaveChanges();
			}
		}

		public ResetPasswordResult ResetPassword(string mailAddress)
		{
			var user = this.repository.Get<User>(p => p.MailAddress == mailAddress);

			if (user == null)
				return null;

			user.SecurityToken = Guid.NewGuid();
			this.repository.SaveChanges();

			var token = this.GenerateSecurityToken(user.Username, user.SecurityToken.Value);

			return new ResetPasswordResult
			{
				UserMailAddress = user.MailAddress,
				DisplayName = user.GetFullName(),
				Token = token
			};
		}

		public IEnumerable<Resource> GetMenus(int userId)
		{
			var query = this.repository.All<Authorization>()
				.Include(p => p.Permission)
				.Include(p => p.Permission.Resource)
				.Include(p => p.User)
				.Where(p =>
					p.Allowed
					&& !p.Denied
					&& p.User.Id == userId)
				.Union(
					this.repository.All<Authorization>()
					.Include(p => p.Permission)
					.Include(p => p.Role)
					.Include(p => p.Role.UserRoles)
					.Include(p => p.Role.UserRoles.Select(x => x.User))
					.Where(p =>
						p.Allowed
						&& !p.Denied
						&& p.Role.UserRoles
							.Select(x => x.User)
							.Any(o => p.Id == userId)))
				.Select(p => new Resource
				{
					Id = p.Permission.Resource.Id,
					Title = p.Permission.Resource.Title,
					Description = p.Permission.Resource.Description,
					Action = p.Permission.Resource.Action,
					Controller = p.Permission.Resource.Controller,
					Area = p.Permission.Resource.Area,
					Order = p.Permission.Resource.Order,
					Type = p.Permission.Resource.Type
				})
				.ToList();

			var menus = query
				.Where(p => p.Type == ResourceType.Menu)
				.Select(p => new Resource
				{
					Id = p.Id,
					Title = p.Title,
					Description = p.Description,
					Action = p.Action,
					Controller = p.Controller,
					Area = p.Area,
					Order = p.Order,
					Type = p.Type,
					Children = query
						.Where(x => x.Type == ResourceType.Form && x.ParentId == p.Id)
						.ToList()
				});

			return query;
		}

		public IEnumerable<Rule> GetRules(int userId, string area, string controller, string action)
		{
			var query = this.repository.All<Authorization>()
				.Include(p => p.Permission)
				.Include(p => p.Permission.Resource)
				.Include(p => p.User)
				.Where(p =>
					p.Permission.Resource.Type == ResourceType.Form
					&& p.Allowed
					&& !p.Denied
					&& p.User.Id == userId
					&& p.Permission.Resource.Area == area
					&& p.Permission.Resource.Controller == controller
					&& p.Permission.Resource.Action == action)
				.Union(
					this.repository.All<Authorization>()
					.Include(p => p.Permission)
					.Include(p => p.Permission.Resource)
					.Include(p => p.Role)
					.Include(p => p.Role.UserRoles)
					.Include(p => p.Role.UserRoles.Select(x => x.User))
					.Where(p =>
						p.Permission.Resource.Type == ResourceType.Form
						&& p.Allowed
						&& !p.Denied
						&& p.Role.UserRoles
							.Select(x => x.User)
							.Any(o => p.Id == userId)
						&& p.Permission.Resource.Area == area
						&& p.Permission.Resource.Controller == controller
						&& p.Permission.Resource.Action == action))
				.Select(p => (Rule)p.Permission.OperationId)
			.ToList();

			return query;
		}

		public User GetUserToChangePassword(string token)
		{
			var deserializedToken = this.DeserializeSecurityToken(token);

			if (deserializedToken == null || !this.ValidateSecurityToken(deserializedToken))
				return null;

			var user = this.repository
			   .Find<User>(p => p.Username == deserializedToken.Username)
			   .Select(p => new
			   {
				   Id = p.Id,
				   Username = p.Username,
				   FirstName = p.FirstName,
				   LastName = p.LastName
			   })
			   .FirstOrDefault();

			return new User
			{
				Id = user.Id,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName
			};
		}

		public void ChangePassword(int userId, string currentPassword, string newPassword)
		{
			var user = this.repository.Get<User>(p => p.Id == userId && p.Password == currentPassword);

			if (user == null)
				throw new ManagerException("Usuário ou senha inválidos.");

			var passwordValidation = this.ValidatePasswordComplexity(userId, newPassword);

			if (passwordValidation == null)
			{
				var passwordValidationMessage = this.GetPasswordValidationMessage(userId);
				throw new ManagerException(passwordValidationMessage);
			}

			user.Password = Encrypter.Encrypt(newPassword);
			user.SecurityToken = null;
			user.MustChangePassword = false;

			var newHistory = new UserPasswordHistory
			{
				Date = DateTime.Now,
				Password = user.Password,
				UserId = user.Id
			};

			this.repository.Add(newHistory);
			this.repository.SaveChanges();
		}

		private string GetPasswordValidationMessage(int userId)
		{
			throw new NotImplementedException();
		}

		private User DeserializeSecurityToken(string token)
		{
			try
			{
				var deserializedToken = Encrypter.Decrypt(token);
				var tokenArray = deserializedToken.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

				if (tokenArray.Count() != 2)
					return null;

				Guid securityToken = Guid.Empty;
				var username = tokenArray[0];

				if (!Guid.TryParse(tokenArray[1], out securityToken))
					return null;

				return new User
				{
					Username = username,
					SecurityToken = securityToken
				};
			}
			catch
			{
				return null;
			}
		}

		private bool ValidateSecurityToken(User user)
		{
			return this.repository.Any<User>(p => p.Username == user.Username && p.SecurityToken == user.SecurityToken);
		}

		private void FailAuthentication(Authentication authentication)
		{
			authentication.State = AuthenticationState.Fail;
			this.repository.Add(authentication);
		}

		private PasswordComplexityValidation ValidatePasswordComplexity(int userId, string password)
		{
			var passwordComplexity = this.repository
				.Find<UserPasswordPolicy>(p => p.UserPolicy.Id == userId)
				.Include(p => p.UserPolicy)
				.Select(p => new PasswordComplexityValidation
				{
					RequiredMinimumLength = p.RequiredMinimumLength,
					RequiredMaximumLength = p.RequiredMaximumLength,
					RequiredUppercase = p.RequiredUppercase,
					RequiredLowercase = p.RequiredLowercase,
					RequiredNonLetterOrDigit = p.RequiredNonLetterOrDigit,
					RequiredDigit = p.RequiredDigit
				})
				.FirstOrDefault();

			if (passwordComplexity == null)
				return null;

			// MinimumLength
			if (password.Length < passwordComplexity.RequiredMinimumLength)
				passwordComplexity.IsInvalid = true;

			// MaximumLength
			if (password.Length > passwordComplexity.RequiredMaximumLength)
				passwordComplexity.IsInvalid = true;

			// UpperCaseCharLength
			var upperCaseCharLength = 0;

			foreach (var c in password)
			{
				if (char.IsUpper(c))
					upperCaseCharLength++;
			}

			if (upperCaseCharLength < passwordComplexity.RequiredUppercase)
				passwordComplexity.IsInvalid = true;

			// LowerCaseCharLength
			var lowerCaseCharLength = 0;

			foreach (var c in password)
			{
				if (char.IsUpper(c))
					lowerCaseCharLength++;
			}

			if (lowerCaseCharLength < passwordComplexity.RequiredLowercase)
				passwordComplexity.IsInvalid = true;

			// Special_char_length
			var specialCharLength = 0;

			foreach (var c in password)
			{
				if (!char.IsLetterOrDigit(c))
					specialCharLength++;
			}

			if (specialCharLength < passwordComplexity.RequiredNonLetterOrDigit)
				passwordComplexity.IsInvalid = true;

			// NumericCharLength
			var numericCharLength = 0;

			foreach (var c in password)
			{
				if (char.IsNumber(c))
					numericCharLength++;
			}

			if (numericCharLength != passwordComplexity.RequiredDigit)
				passwordComplexity.IsInvalid = true;

			return passwordComplexity;
		}

		private void ConfirmLogin(Authentication authentication)
		{
			this.repository.Update<Authentication>(
				p => p.UserId == authentication.UserId.Value && p.State == AuthenticationState.Fail,
				t => new Authentication
				{
					IsActive = false
				});

			// Change the current login attempt as success
			authentication.State = AuthenticationState.Success;
			this.repository.Add(authentication);
		}

		private Authentication CreateLogin(int? userId, string userName)
		{
			var authentication = new Authentication
			{
				UserId = userId,
				UserName = userName,
				State = AuthenticationState.Processing,
				Date = DateTime.Now
			};

			return authentication;
		}

		private bool CheckLoginAttempts(int userId)
		{
			var authenticationsCount = this.repository
				.Count<Authentication>(p => p.State == AuthenticationState.Fail);

			var maximumLoginAttempts = this.repository
				.Find<UserPolicy>(p => p.Id == userId)
				.Select(p => p.MaximumLoginAttempts)
				.FirstOrDefault();

			return maximumLoginAttempts > 0
				|| authenticationsCount < maximumLoginAttempts;
		}

		private bool CheckPasswordAge(int userId)
		{
			var now = DateTime.Now.Date;

			var lastPasswordDate = this.repository
				.Find<UserPasswordHistory>(p => p.UserId == userId)
				.Select(p => p.Date)
				.OrderByDescending(p => p)
				.FirstOrDefault();

			var maximumPasswordAge = this.repository
				.Find<UserPolicy>(p => p.Id == userId)
				.Select(p => p.MaximumPasswordAge)
				.FirstOrDefault();

			return now <= lastPasswordDate.Date.AddDays(maximumPasswordAge).Date;
		}

		private bool CheckCredentials(string userPassword, string newPassword)
		{
			return userPassword == Encrypter.Encrypt(newPassword);
		}

		private string GenerateSecurityToken(string username, Guid securityToken)
		{
			var token = string.Format("{0}||{1}", username, securityToken.ToString());
			return Encrypter.Encrypt(token);
		}
	}
}
