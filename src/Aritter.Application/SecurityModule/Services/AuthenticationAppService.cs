using Aritter.Application.DTO;
using Aritter.Application.Seedwork;
using Aritter.Application.Seedwork.Resources.SecurityModule;
using Aritter.Application.Seedwork.SecurityModule.Services;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.SecurityModule.Services;
using Aritter.Domain.Seedwork.Validation;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Application.SecurityModule.Services
{
	public class AuthenticationAppService : AppService, IAuthenticationAppService
	{
		private readonly IUserRepository userRepository;
		private readonly IAuthenticationService authenticationService;

		public AuthenticationAppService(IUserRepository userRepository,
										IAuthenticationService authenticationService)
		{
			ThrowHelper.ThrowArgumentNullException(userRepository, nameof(userRepository));
			ThrowHelper.ThrowArgumentNullException(authenticationService, nameof(authenticationService));

			this.userRepository = userRepository;
			this.authenticationService = authenticationService;
		}

		public AuthorizationDto Authenticate(string userName, string password)
		{
			return WithTransaction(() =>
			{
				if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
				{
					ThrowHelper.ThrowApplicationErrorException(Messages.Validation_InvalidUserCredentials);
				}

				var user = userRepository
					.Get(UserSpecifications.FindEnabledByUserName(userName));

				if (user == null)
				{
					ThrowHelper.ThrowApplicationErrorException(Messages.Validation_InvalidUserCredentials);
				}

				var validator = EntityValidator.CreateValidator();

				var result = validator.Validate(user);

				if (!authenticationService.Authenticate(user, password))
				{
					ThrowHelper.ThrowApplicationErrorException(Messages.Validation_InvalidUserCredentials);
				}

				var authorization = userRepository.GetAuthorizations(UserSpecifications.FindEnabledById(user.Id));

				userRepository.UnitOfWork.Commit();

				return authorization.ProjectedAs<AuthorizationDto>();
			});
		}

		public AuthorizationDto GetAuthorization(string userName)
		{
			return WithTransaction(() =>
			{
				if (string.IsNullOrEmpty(userName))
				{
					ThrowHelper.ThrowApplicationErrorException(Messages.Validation_InvalidUserCredentials);
				}

				var user = userRepository
					.Get(UserSpecifications.FindEnabledByUserName(userName));

				if (user == null)
				{
					ThrowHelper.ThrowApplicationErrorException(Messages.Validation_InvalidUserCredentials);
				}

				var authorization = userRepository.GetAuthorizations(UserSpecifications.FindEnabledById(user.Id));

				return authorization.ProjectedAs<AuthorizationDto>();
			});
		}
	}
}