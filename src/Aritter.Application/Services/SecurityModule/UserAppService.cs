using Aritter.Application.DTO.SecurityModule.Users;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.SecurityModule.Aggregates.Users.Specs;
using Aritter.Domain.SecurityModule.Services.Users;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Application.Services.SecurityModule
{
	public class UserAppService : AppService, IUserAppService
	{
		private readonly IUserAccountService userAccountService;
		private readonly IUserAccountRepository userAccountRepository;

		public UserAppService(IUserAccountRepository userAccountRepository,
							  IUserAccountService userAccountService)
		{
			Check.IsNotNull(userAccountService, nameof(userAccountService));
			Check.IsNotNull(userAccountRepository, nameof(userAccountRepository));

			this.userAccountService = userAccountService;
			this.userAccountRepository = userAccountRepository;
		}

		public UserAccountDto AddUserAccount(AddUserAccountDto userAccountDto)
		{
			if (userAccountDto == null)
			{
				ThrowHelper.ThrowApplicationException("Invalid user account");
			}

			var user = userAccountRepository.Get(UserAccountSpecs.HasUsername(userAccountDto.Username) |
												 UserAccountSpecs.HasEmail(userAccountDto.Email));

			if (user != null && userAccountDto.Username == user.Username)
			{
				ThrowHelper.ThrowApplicationException("The username is already registered");
			}

			if (user != null && userAccountDto.Email == user.Email)
			{
				ThrowHelper.ThrowApplicationException("The e-mail is already registered");
			}

			var newUser = UserFactory.CreateAccount(userAccountDto.Username,
													userAccountDto.Password,
													userAccountDto.Email);

			userAccountService.SaveUserAccount(newUser);
			userAccountRepository.UnitOfWork.Commit();

			return newUser.ProjectedAs<UserAccountDto>();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				userAccountRepository.Dispose();
			}
		}
	}
}
