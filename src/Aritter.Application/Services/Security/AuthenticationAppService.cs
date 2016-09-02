using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Specs;
using Aritter.Domain.Security.Aggregates.Validators;
using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Application.Services.Security
{
    public class AuthenticationAppService : AppService, IAuthenticationAppService
    {
        private readonly IPermissionRepository permissionRepository;
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IApplicationRepository applicationRepository;

        public AuthenticationAppService(IUserAccountRepository userAccountRepository,
                                        IPermissionRepository permissionRepository,
                                        IApplicationRepository applicationRepository)
        {
            Check.IsNotNull(userAccountRepository, nameof(userAccountRepository));
            Check.IsNotNull(permissionRepository, nameof(permissionRepository));
            Check.IsNotNull(applicationRepository, nameof(applicationRepository));

            this.userAccountRepository = userAccountRepository;
            this.permissionRepository = permissionRepository;
            this.applicationRepository = applicationRepository;
        }

        public AuthenticationDto AuthenticateUser(AuthenticateUserDto authenticateUser)
        {
            AuthenticationDto authentication = new AuthenticationDto();

            if (authenticateUser == null
                || string.IsNullOrEmpty(authenticateUser.Username)
                || string.IsNullOrEmpty(authenticateUser.Password)
                || authenticateUser.ApplicationId == null
                || authenticateUser.ApplicationId == Guid.Empty)
            {
                authentication.IsAuthenticated = false;
                authentication.Errors.Add("Invalid username or password");

                return authentication;
            }

            var application = applicationRepository
                .Find(ApplicationSpecs.HasUID(authenticateUser.ApplicationId))
                .First();

            var user = userAccountRepository.Get(UserAccountSpecs.HasUsername(authenticateUser.Username) & UserAccountSpecs.HasApplicationId(application.Id));

            if (user == null)
            {
                authentication.IsAuthenticated = false;
                authentication.Errors.Add("Invalid username or password");

                return authentication;
            }

            var validator = new UserAccountValidator();
            var validation = validator.ValidateCredentials(user, authenticateUser.Password);

            if (!validation.IsValid)
            {
                user.HasInvalidLoginAttempt();

                authentication.IsAuthenticated = false;
                authentication.Errors = validation.Errors.Select(p => p.Message).ToList();
            }
            else
            {
                user.HasValidLoginAttempt();

                authentication.IsAuthenticated = true;
                authentication.User = user.ProjectedAs<UserAccountDto>();
                authentication.Errors.Clear();
            }

            SaveUserAccount(user);
            userAccountRepository.UnitOfWork.Commit();

            return authentication;
        }

        public ICollection<PermissionDto> ListAccountPermissions(UserAccountDto account)
        {
            if (account == null || string.IsNullOrEmpty(account.Username))
            {
                ThrowHelper.ThrowApplicationException("The user is invalid");
            }

            var permissions = permissionRepository.ListPermissions(PermissionSpecs.FromUserAccount(account.Username));

            return permissions.ProjectedAsCollection<PermissionDto>();
        }

        private void SaveUserAccount(UserAccount account)
        {
            var validator = new UserAccountValidator();
            var validation = validator.ValidateAccount(account);

            if (!validation.IsValid)
            {
                ThrowHelper.ThrowApplicationException(validation.Errors.Select(p => p.Message));
            }

            if (account.IsTransient())
            {
                userAccountRepository.Add(account);
            }
            else
            {
                userAccountRepository.Update(account);
            }
        }
    }
}