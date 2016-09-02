using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.SecurityModule.Aggregates.Specs;
using Aritter.Domain.SecurityModule.Aggregates.Validators;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Application.Services.SecurityModule
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserAccountRepository userAccountRepository;

        public UserAppService(IUserAccountRepository userAccountRepository)
        {
            Check.IsNotNull(userAccountRepository, nameof(userAccountRepository));

            this.userAccountRepository = userAccountRepository;
        }

        public UserAccountDto AddAccount(AddUserAccountDto addAccount)
        {
            if (addAccount == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user account");
            }

            var user = userAccountRepository.Get(UserAccountSpecs.HasUsername(addAccount.Username) |
                                                 UserAccountSpecs.HasEmail(addAccount.Email));

            if (user != null && addAccount.Username == user.Username)
            {
                ThrowHelper.ThrowApplicationException("The username is already registered");
            }

            if (user != null && addAccount.Email == user.Email)
            {
                ThrowHelper.ThrowApplicationException("The e-mail is already registered");
            }

            var newUser = UserAccount.CreateAccount(addAccount.Username,
                                                    addAccount.Email,
                                                    addAccount.Password);

            SaveUserAccount(newUser);
            userAccountRepository.UnitOfWork.Commit();

            return newUser.ProjectedAs<UserAccountDto>();
        }

        public UserAccountDto GetAccount(GetUserAccountDto getAccount)
        {
            if (getAccount == null || string.IsNullOrEmpty(getAccount.Username))
            {
                ThrowHelper.ThrowApplicationException("Invalid user account");
            }

            var user = userAccountRepository.Get(UserAccountSpecs.HasUsername(getAccount.Username));

            return user.ProjectedAs<UserAccountDto>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                userAccountRepository.Dispose();
            }
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
