using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.Common.Specs;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs;
using Aritter.Domain.SecurityModule.Services;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Application.Services.SecurityModule
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

        public AuthenticationDto Authenticate(string userName, string password)
        {
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(userName), "Username or password are invalid.");
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(password), "Username or password are invalid.");

            var user = userRepository.GetWithPassword(new IsEnabledSpec<User>() &
                                                      new UserHasUsernameEqualsSpec(userName));

            var isAuthenticated = user != null
                && authenticationService.Authenticate(user, password);

            Guard.Against<ApplicationErrorException>(!isAuthenticated, "Username or password are invalid.");

            var authorization = userRepository.GetWithAuthorizations(new IsEnabledSpec<User>() &
                                                                     new IdIsEqualsSpec<User>(user.Id));

            userRepository.UnitOfWork.CommitChanges();

            return authorization.ProjectedAs<AuthenticationDto>();
        }

        public AuthenticationDto GetAuthorization(string userName)
        {
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(userName), "Username or password are invalid.");

            var user = userRepository.Get(new IsEnabledSpec<User>() &
                                          new UserHasUsernameEqualsSpec(userName));

            Guard.Against<ApplicationErrorException>(user == null, "Username or password are invalid.");

            var authorization = userRepository.GetWithAuthorizations(new IsEnabledSpec<User>() &
                                                                 new IdIsEqualsSpec<User>(user.Id));

            return authorization.ProjectedAs<AuthenticationDto>();
        }
    }
}