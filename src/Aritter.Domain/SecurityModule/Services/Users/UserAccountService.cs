using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.SecurityModule.Aggregates.Users.Validators;
using Aritter.Domain.Seedwork.Services;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Services.Users
{
    public sealed class UserAccountService : DomainService, IUserAccountService
    {
        private readonly IUserAccountRepository userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            Check.IsNotNull(userAccountRepository, nameof(userAccountRepository));

            this.userAccountRepository = userAccountRepository;
        }

        public void SaveUserAccount(UserAccount userAccount)
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
