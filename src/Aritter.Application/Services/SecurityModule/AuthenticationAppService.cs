using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.SecurityModule.Aggregates.Permissions.Specs;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.SecurityModule.Aggregates.Users.Specs;
using Aritter.Domain.SecurityModule.Aggregates.Users.Validators;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Application.Services.SecurityModule
{
    public class AuthenticationAppService : AppService, IAuthenticationAppService
    {
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IUserRoleRepository userRoleRepository;

        public AuthenticationAppService(IUserAccountRepository userAccountRepository,
                                        IUserRoleRepository userRoleRepository)
        {
            Check.IsNotNull(userAccountRepository, nameof(userAccountRepository));
            Check.IsNotNull(userRoleRepository, nameof(userRoleRepository));

            this.userAccountRepository = userAccountRepository;
            this.userRoleRepository = userRoleRepository;
        }

        public AuthenticationDto Authenticate(string userName, string password)
        {
            Check.Against<ApplicationException>(string.IsNullOrEmpty(userName), "Invalid username or password.");
            Check.Against<ApplicationException>(string.IsNullOrEmpty(password), "Invalid username or password.");

            var validator = new UserAccountValidator();

            var user = userAccountRepository.Get(UserAccountSpecs.HasUsername(userName));

            Check.Against<ApplicationException>(user == null, "Invalid username or password.");

            var validation = validator.ValidateCredentials(user, password);

            if (!validation.IsValid)
            {
                user.HasInvalidAttemptsCount();
                userAccountRepository.UnitOfWork.Commit();
                throw new ApplicationException(validation.Errors.Select(p => p.Message).ToArray());
            }

            user.HasValidAttemptsCount();
            userAccountRepository.UnitOfWork.Commit();

            user.Assignments = userAccountRepository.FindAllowedAssigns(UserAssignmentSpecs.HasUserAccountId(user.Id) &
                                                                        UserAssignmentSpecs.HasAllowedPermissions());

            return user.ProjectedAs<AuthenticationDto>();
        }

        public AuthenticationDto GetAuthorization(string userName)
        {
            Check.Against<ApplicationException>(string.IsNullOrEmpty(userName), "Username or password are invalid.");

            var validator = new UserAccountValidator();

            var user = userAccountRepository
                .Find(UserAccountSpecs.HasUsername(userName))
                .FirstOrDefault();

            var validation = validator.ValidateAccount(user);

            if (!validation.IsValid)
            {
                throw new ApplicationException("Invalid user account");
            }

            user.Assignments = userAccountRepository.FindAllowedAssigns(UserAssignmentSpecs.HasUserAccountId(user.Id) &
                                                                        UserAssignmentSpecs.HasAllowedPermissions());

            return user.ProjectedAs<AuthenticationDto>();
        }
    }
}