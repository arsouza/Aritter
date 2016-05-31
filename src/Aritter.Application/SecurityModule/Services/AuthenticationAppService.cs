using Aritter.Application.DTO;
using Aritter.Application.Seedwork;
using Aritter.Application.Seedwork.Resources.SecurityModule;
using Aritter.Application.Seedwork.SecurityModule.Services;
using Aritter.Domain.Common.Specs;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs;
using Aritter.Domain.SecurityModule.Services;
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
            Guard.IsNotNull(userRepository, nameof(userRepository));
            Guard.IsNotNull(authenticationService, nameof(authenticationService));

            this.userRepository = userRepository;
            this.authenticationService = authenticationService;
        }

        public AuthorizationDto Authenticate(string userName, string password)
        {
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(userName), Messages.Validation_InvalidUserCredentials);
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(password), Messages.Validation_InvalidUserCredentials);

            return WithTransaction(() =>
            {
                var user = userRepository.Get(new IsEnabledSpec<User>() &
                                              new UserNameEqualsSpec(userName));

                var isAuthenticated = user != null
                    && authenticationService.Authenticate(user, password);

                Guard.Against<ApplicationErrorException>(isAuthenticated, Messages.Validation_InvalidUserCredentials);

                var authorization = userRepository.GetAuthorizations(new IsEnabledSpec<User>() &
                                                                     new IdEqualsSpec<User>(user.Id));

                userRepository.UnitOfWork.Commit();

                return authorization.ProjectedAs<AuthorizationDto>();
            });
        }

        public AuthorizationDto GetAuthorization(string userName)
        {
            return WithTransaction(() =>
            {
                Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(userName), Messages.Validation_InvalidUserCredentials);

                var user = userRepository.Get(new IsEnabledSpec<User>() &
                                              new UserNameEqualsSpec(userName));

                Guard.Against<ApplicationErrorException>(user == null, Messages.Validation_InvalidUserCredentials);

                var authorization = userRepository.GetAuthorizations(new IsEnabledSpec<User>() &
                                                                     new IdEqualsSpec<User>(user.Id));

                return authorization.ProjectedAs<AuthorizationDto>();
            });
        }
    }
}