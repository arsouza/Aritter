using Aritter.Application.DTO;
using Aritter.Application.Seedwork;
using Aritter.Application.Seedwork.SecurityModule.Services;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.SecurityModule.Services;
using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Application.SecurityModule.Services
{
    public class AuthenticationAppService : AppService, IAuthenticationAppService
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthenticationService userAuthenticationService;

        public AuthenticationAppService(IUserRepository userRepository,
                                        IAuthenticationService userAuthenticationService)
        {
            ThrowHelper.ThrowArgumentNullException(userRepository, nameof(userRepository));
            ThrowHelper.ThrowArgumentNullException(userAuthenticationService, nameof(userAuthenticationService));

            this.userRepository = userRepository;
            this.userAuthenticationService = userAuthenticationService;
        }

        public AuthorizationDto Authenticate(string userName, string password)
        {
            return WithTransaction(() =>
            {
                ThrowHelper.ThrowApplicationErrorException(string.IsNullOrEmpty(userName), "Messages.InvalidUserIdentifier");
                ThrowHelper.ThrowApplicationErrorException(string.IsNullOrEmpty(password), "Messages.exception_InvalidUserPassword");

                var user = userRepository
                    .Get(UserSpecifications.FindEnabledByUserName(userName));

                ThrowHelper.ThrowApplicationErrorException(user == null, "Messages.exception_CannotFoundUser");

                return null as AuthorizationDto;
            });
        }

        public AuthorizationDto GetAuthorization(string userName)
        {
            throw new NotImplementedException();
        }
    }
}