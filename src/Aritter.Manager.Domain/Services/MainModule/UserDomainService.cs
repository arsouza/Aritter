using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Domain.Extensions;
using Aritter.Manager.Infrastructure.Encryption;
using Aritter.Manager.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Authentication;

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
			var mustChangePassword = repository
				.Find<User>(p => p.Id == userId)
				.Select(p => p.MustChangePassword)
				.FirstOrDefault();

			return mustChangePassword;
		}

		public User GetUser(int id)
		{
			return repository.Get<User>(id);
		}

		public int AuthenticateUser(string username, string password)
		{
			var authentication = BeginNewLoginAttempt(null, username);

			try
			{
				var user = repository
					.Find<User>(p => p.Username == username)
					.Select(p => new { p.Id, p.Password })
					.FirstOrDefault();

				if (user == null)
					throw new AuthenticationException(Global.Message_InvalidUserPassword);

				authentication.UserId = user.Id;
				repository.SaveChanges();

				if (!CheckCredentials(user.Password, password))
					throw new AuthenticationException(Global.Message_InvalidUserPassword);

				if (!CheckPasswordAge(user.Id))
					throw new AuthenticationException(Global.Message_UserPasswordExpired);

				if (!CheckLoginAttempts(user.Id))
					throw new AuthenticationException(Global.Message_UserLocked);

				RemoveFailedUserLoginAttempts(authentication);
				authentication.State = AuthenticationState.Success;
				repository.SaveChanges();

				return user.Id;
			}
			catch (Exception)
			{
				authentication.State = AuthenticationState.Fail;
				repository.SaveChanges();
				throw;
			}
		}

		public ResetPasswordResult ResetPassword(string mailAddress)
		{
			var user = repository.Get<User>(p => p.MailAddress == mailAddress);

			if (user == null)
				return null;

			user.SecurityToken = Guid.NewGuid();
			repository.SaveChanges();

			var token = GenerateSecurityToken(user.Username, user.SecurityToken.Value);

			return new ResetPasswordResult
			{
				UserMailAddress = user.MailAddress,
				DisplayName = user.GetFullName(),
				Token = token
			};
		}

		public IEnumerable<Resource> GetMenus(int userId)
		{
			var query = repository.All<Authorization>()
				.Include(p => p.Permission)
				.Include(p => p.Permission.Resource)
				.Include(p => p.User)
				.Where(p =>
					p.Allowed
					&& !p.Denied
					&& p.User.Id == userId)
				.Union(
					repository.All<Authorization>()
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

			return menus;
		}

		public IEnumerable<Rule> GetRules(int userId, string area, string controller, string action)
		{
			var query = repository.All<Authorization>()
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
					repository.All<Authorization>()
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

		public User GetUserBySecurityToken(string token)
		{
			var deserializedToken = DeserializeSecurityToken(token);

			if (deserializedToken == null || !ValidateSecurityToken(deserializedToken))
				return null;

			var user = repository
			   .Find<User>(p => p.Username == deserializedToken.Username)
			   .Select(p => new
			   {
				   p.Id,
				   p.Username,
				   p.FirstName,
				   p.LastName
			   })
			   .First();

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
			var user = repository.Get<User>(p => p.Id == userId && p.Password == currentPassword);

			if (user == null)
				throw new AuthenticationException("Usuário ou senha inválidos.");

			var passwordValidation = ValidatePasswordComplexity(userId, newPassword);

			if (passwordValidation)
			{
				var passwordValidationMessage = GetPasswordValidationMessage();
				throw new InvalidOperationException(passwordValidationMessage);
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

			repository.Add(newHistory);
			repository.SaveChanges();
		}

		private string GetPasswordValidationMessage()
		{
			throw new NotImplementedException();
		}

		private User DeserializeSecurityToken(string token)
		{
			try
			{
				var deserializedToken = Encrypter.Decrypt(token);
				var tokenArray = deserializedToken.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

				if (tokenArray.Count() != 2)
					return null;

				Guid securityToken;
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
			return repository.Any<User>(p => p.Username == user.Username && p.SecurityToken == user.SecurityToken);
		}

		private bool ValidatePasswordComplexity(int userId, string password)
		{
			var passwordComplexity = GetPasswordComplexity(userId);

			if (passwordComplexity == null)
				return true;

			return
				password.Length >= passwordComplexity.RequiredMinimumLength // MinimumLength
				&& password.Length <= passwordComplexity.RequiredMaximumLength // MaximumLength
				&& password.Count(char.IsUpper) >= passwordComplexity.RequiredUppercase // UpperCaseCharLength
				&& password.Count(char.IsLower) >= passwordComplexity.RequiredLowercase // LowerCaseCharLength
				&& password.Count(c => !char.IsLetterOrDigit(c)) >= passwordComplexity.RequiredNonLetterOrDigit // Special_char_length
				&& password.Count(char.IsNumber) >= passwordComplexity.RequiredDigit; // NumericCharLength
		}

		private UserPasswordPolicy GetPasswordComplexity(int userId)
		{
			var passwordComplexity = repository
				.Find<UserPasswordPolicy>(p => p.UserPolicy.Id == userId)
				.Include(p => p.UserPolicy)
				.Select(p => new UserPasswordPolicy
				{
					RequiredMinimumLength = p.RequiredMinimumLength,
					RequiredMaximumLength = p.RequiredMaximumLength,
					RequiredUppercase = p.RequiredUppercase,
					RequiredLowercase = p.RequiredLowercase,
					RequiredNonLetterOrDigit = p.RequiredNonLetterOrDigit,
					RequiredDigit = p.RequiredDigit
				})
				.FirstOrDefault();

			return passwordComplexity;
		}

		private Authentication BeginNewLoginAttempt(int? userId, string userName)
		{
			var authentication = new Authentication
			{
				UserId = userId,
				UserName = userName,
				State = AuthenticationState.Processing,
				Date = DateTime.Now
			};

			repository.Add(authentication);
			repository.SaveChanges();

			return authentication;
		}

		private void RemoveFailedUserLoginAttempts(Authentication authentication)
		{
			// Remove failed user login attempts
			repository.Update<Authentication>(
				p => p.UserId == authentication.UserId.Value && p.State == AuthenticationState.Fail,
				t => new Authentication
				{
					IsActive = false
				});
		}

		private bool CheckLoginAttempts(int userId)
		{
			var authenticationsCount = repository
				.Count<Authentication>(p => p.State == AuthenticationState.Fail);

			var maximumLoginAttempts = repository
				.Find<UserPolicy>(p => p.Id == userId)
				.Select(p => p.MaximumLoginAttempts)
				.FirstOrDefault();

			return maximumLoginAttempts > 0
				|| authenticationsCount < maximumLoginAttempts;
		}

		private bool CheckPasswordAge(int userId)
		{
			var now = DateTime.Now.Date;

			var lastPasswordDate = repository
				.Find<UserPasswordHistory>(p => p.UserId == userId)
				.Select(p => p.Date)
				.OrderByDescending(p => p)
				.FirstOrDefault();

			var maximumPasswordAge = repository
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
			var token = string.Format("{0}||{1}", username, securityToken);
			return Encrypter.Encrypt(token);
		}
	}
}
