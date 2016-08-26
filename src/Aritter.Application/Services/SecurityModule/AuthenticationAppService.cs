using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.SecurityModule.Aggregates.Specs;
using Aritter.Domain.SecurityModule.Aggregates.Validators;
using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Application.Services.SecurityModule
{
    public class AuthenticationAppService : AppService, IAuthenticationAppService
    {
        private readonly IAuthorizationRepository authorizationRepository;
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IClientRepository clientRepository;

        public AuthenticationAppService(IUserAccountRepository userAccountRepository,
                                        IAuthorizationRepository authorizationRepository,
                                        IClientRepository clientRepository)
        {
            Check.IsNotNull(userAccountRepository, nameof(userAccountRepository));
            Check.IsNotNull(authorizationRepository, nameof(authorizationRepository));
            Check.IsNotNull(clientRepository, nameof(clientRepository));

            this.userAccountRepository = userAccountRepository;
            this.authorizationRepository = authorizationRepository;
            this.clientRepository = clientRepository;
        }

        public AuthenticationDto AuthenticateUser(AuthenticateUserDto authenticateUserDto)
        {
            AuthenticationDto authentication = new AuthenticationDto();

            if (authenticateUserDto == null
                || string.IsNullOrEmpty(authenticateUserDto.Username)
                || string.IsNullOrEmpty(authenticateUserDto.Password)
                || authenticateUserDto.ClientId == null
                || authenticateUserDto.ClientId == Guid.Empty)
            {
                authentication.IsAuthenticated = false;
                authentication.Errors.Add("Invalid username or password");

                return authentication;
            }

            var client = clientRepository
                .Find(ClientSpecs.HasUID(authenticateUserDto.ClientId))
                .First();

            var user = userAccountRepository.Get(UserAccountSpecs.HasUsername(authenticateUserDto.Username) & UserAccountSpecs.HasClientId(client.Id));

            if (user == null)
            {
                authentication.IsAuthenticated = false;
                authentication.Errors.Add("Invalid username or password");

                return authentication;
            }

            var validator = new UserAccountValidator();
            var validation = validator.ValidateCredentials(user, authenticateUserDto.Password);

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

        public ICollection<AuthorizationDto> ListUserAuthorizations(UserAccountDto userAccountDto)
        {
            if (userAccountDto == null || string.IsNullOrEmpty(userAccountDto.Username))
            {
                ThrowHelper.ThrowApplicationException("The user is invalid");
            }

            var authorizations = authorizationRepository.ListAuthorizations(AuthorizationSpecs.FromUserAccount(userAccountDto.Username) &
                                                                            AuthorizationSpecs.HasAllowed());

            return authorizations.ProjectedAsCollection<AuthorizationDto>();
        }

        private void SaveUserAccount(UserAccount userAccount)
        {
            var validator = new UserAccountValidator();
            var validation = validator.ValidateAccount(userAccount);

            if (!validation.IsValid)
            {
                ThrowHelper.ThrowApplicationException(validation.Errors.Select(p => p.Message));
            }

            if (userAccount.IsTransient())
            {
                userAccountRepository.Add(userAccount);
            }
            else
            {
                userAccountRepository.Update(userAccount);
            }
        }
    }
}