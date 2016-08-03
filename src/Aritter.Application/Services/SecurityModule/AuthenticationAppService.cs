using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.Common.Specs;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg.Validators;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Application.Services.SecurityModule
{
    public class AuthenticationAppService : AppService, IAuthenticationAppService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public AuthenticationAppService(IUserRepository userRepository,
                                        IRoleRepository roleRepository)
        {
            Guard.IsNotNull(userRepository, nameof(userRepository));
            Guard.IsNotNull(roleRepository, nameof(roleRepository));

            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public AuthenticationDto Authenticate(string userName, string password)
        {
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(userName), "Username or password are invalid.");
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(password), "Username or password are invalid.");

            var findByUsernameSpec = new IsEnabledSpec<User>() &
                                     new UsernameEqualsSpec(userName);

            var user = userRepository.Get(findByUsernameSpec);

            UserValidator validator = new UserValidator();

            var userValidation = validator.ValidateCredentials(user, password);

            if (!userValidation.IsValid)
            {
                user.HasInvalidAttemptsCount();
                userRepository.UnitOfWork.CommitChanges();
                throw new ApplicationErrorException(userValidation.Errors.Select(p => p.Message).ToArray());
            }

            user.HasValidAttemptsCount();
            userRepository.UnitOfWork.CommitChanges();

            var findUserAuthorizationsSpec = new IsEnabledSpec<User>() &
                                             new IdIsEqualsSpec<User>(user.Id) &
                                             new AllowedUserPermissionsSpec();

            user = userRepository.FindAuthorizations(findUserAuthorizationsSpec);

            return user.ProjectedAs<AuthenticationDto>();
        }

        public AuthenticationDto GetAuthorization(string userName)
        {
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(userName), "Username or password are invalid.");

            var findByUsernameSpec = new IsEnabledSpec<User>() &
                                     new UsernameEqualsSpec(userName);

            var user = userRepository.Find(findByUsernameSpec)
                                     .FirstOrDefault();

            UserValidator validator = new UserValidator();

            var userValidation = validator.ValidateUser(user);

            if (!userValidation.IsValid)
            {
                throw new ApplicationErrorException(userValidation.Errors.Select(p => p.Message).ToArray());
            }

            var findUserAuthorizationsSpec = new IsEnabledSpec<User>() &
                                             new IdIsEqualsSpec<User>(user.Id) &
                                             new AllowedUserPermissionsSpec();

            user = userRepository.FindAuthorizations(findUserAuthorizationsSpec);

            return user.ProjectedAs<AuthenticationDto>();
        }
    }
}