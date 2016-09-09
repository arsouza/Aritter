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
        private readonly IUserRepository userRepository;
        private readonly IApplicationRepository applicationRepository;

        public AuthenticationAppService(IUserRepository userRepository,
                                        IPermissionRepository permissionRepository,
                                        IApplicationRepository applicationRepository)
        {
            Check.IsNotNull(userRepository, nameof(userRepository));
            Check.IsNotNull(permissionRepository, nameof(permissionRepository));
            Check.IsNotNull(applicationRepository, nameof(applicationRepository));

            this.userRepository = userRepository;
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

            var user = userRepository.Get(UserSpecs.HasUsername(authenticateUser.Username));

            if (user == null)
            {
                authentication.IsAuthenticated = false;
                authentication.Errors.Add("Invalid username or password");

                return authentication;
            }

            var validator = new UserValidator();
            var validation = validator.ValidateCredentials(user, authenticateUser.Password);

            if (!validation.IsValid)
            {
                user.IncreaseLoginAttempt();

                authentication.IsAuthenticated = false;
                authentication.Errors = validation.Errors.Select(p => p.Message).ToList();
            }
            else
            {
                user.ResetLoginAttempt();

                authentication.IsAuthenticated = true;
                authentication.User = user.ProjectedAs<UserDto>();
                authentication.Errors.Clear();
            }

            validation = validator.ValidateUser(user);

            if (!validation.IsValid)
            {
                ThrowHelper.ThrowApplicationException(validation.Errors.Select(p => p.Message));
            }

            userRepository.Save(user);
            userRepository.UnitOfWork.Commit();

            return authentication;
        }

        public ICollection<PermissionDto> ListUserPermissions(UserDto user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username))
            {
                ThrowHelper.ThrowApplicationException("The user is invalid");
            }

            var permissions = permissionRepository.ListPermissions(PermissionSpecs.FromUser(user.Username));

            return permissions.ProjectedAsCollection<PermissionDto>();
        }
    }
}