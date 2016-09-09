using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Specs;
using Aritter.Domain.Security.Aggregates.Validators;
using Aritter.Infra.Crosscutting.Encryption;
using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Application.Services.Security
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserRepository userRepository;
        private readonly IApplicationRepository applicationRepository;
        private readonly IPermissionRepository permissionRepository;

        public UserAppService(IUserRepository userRepository,
                              IApplicationRepository applicationRepository,
                              IPermissionRepository permissionRepository)
        {
            Check.IsNotNull(userRepository, nameof(userRepository));
            Check.IsNotNull(applicationRepository, nameof(applicationRepository));
            Check.IsNotNull(applicationRepository, nameof(permissionRepository));

            this.userRepository = userRepository;
            this.applicationRepository = applicationRepository;
            this.permissionRepository = permissionRepository;
        }

        public UserDto AddUser(AddUserDto addUser)
        {
            return userRepository.UnitOfWork.TransactScope(() =>
            {
                if (addUser == null)
                {
                    ThrowHelper.ThrowApplicationException("Invalid user user");
                }

                userRepository.UnitOfWork.BeginTransaction();

                var user = userRepository.Get(UserSpecs.HasUsername(addUser.Username) |
                                              UserSpecs.HasEmail(addUser.Email));

                if (user != null && addUser.Username == user.Username)
                {
                    ThrowHelper.ThrowApplicationException("The username is already registered");
                }

                if (user != null && addUser.Email == user.Email)
                {
                    ThrowHelper.ThrowApplicationException("The e-mail is already registered");
                }

                var newUser = new User(addUser.Username,
                                       addUser.Password,
                                       addUser.Email);

                var validator = new UserValidator();
                var validation = validator.Validate(user);

                if (!validation.IsValid)
                {
                    ThrowHelper.ThrowApplicationException(validation.Errors.Select(p => p.Message));
                }

                userRepository.Save(user);

                return newUser.ProjectedAs<UserDto>();
            });
        }

        public AuthenticationDto AuthenticateUser(AuthenticateUserDto authenticateUser)
        {
            return userRepository.UnitOfWork.TransactScope(() =>
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
                    .FirstOrDefault();

                if (application == null)
                {
                    authentication.IsAuthenticated = false;
                    authentication.Errors.Add("Invalid application");

                    return authentication;
                }

                var user = userRepository.Get(UserSpecs.HasUsername(authenticateUser.Username));

                if (user == null)
                {
                    authentication.IsAuthenticated = false;
                    authentication.Errors.Add("Invalid username or password");

                    return authentication;
                }

                if (!user.Authenticate(Encrypter.Encrypt(authenticateUser.Password)))
                {
                    authentication.IsAuthenticated = false;
                    authentication.Errors.Add("Invalid username or password");

                    return authentication;
                }

                userRepository.Save(user);
                userRepository.UnitOfWork.Commit();

                authentication.IsAuthenticated = true;
                authentication.User = user.ProjectedAs<UserDto>();
                authentication.Errors.Clear();

                return authentication;
            });
        }

        public UserDto GetUser(GetUserDto getUser)
        {
            if (getUser == null || string.IsNullOrEmpty(getUser.Username))
            {
                ThrowHelper.ThrowApplicationException("Invalid user user");
            }

            var user = userRepository.Get(UserSpecs.HasUsername(getUser.Username));

            return user.ProjectedAs<UserDto>();
        }

        public ICollection<PermissionDto> ListPermissions(UserDto user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username))
            {
                ThrowHelper.ThrowApplicationException("The user is invalid");
            }

            var permissions = permissionRepository.ListPermissions(PermissionSpecs.FromUser(user.Username));

            return permissions.ProjectedAsCollection<PermissionDto>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                userRepository.Dispose();
            }
        }
    }
}
