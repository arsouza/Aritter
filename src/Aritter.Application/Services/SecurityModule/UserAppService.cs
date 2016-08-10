using Aritter.Application.DTO.SecurityModule.Users;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.SecurityModule.Aggregates.Users.Specs;
using Aritter.Domain.SecurityModule.Aggregates.Users.Validators;
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

        public UserAccountDto AddUserAccount(AddUserAccountDto userDto)
        {
            UserAccountValidator validator = new UserAccountValidator();

            var user = userAccountRepository.Get(UserAccountSpecs.HasUsername(userDto.Username) | UserAccountSpecs.HasEmail(userDto.Email));

            var validation = validator.ValidateUserDuplicatated(user);

            if (!validation.IsValid)
            {
                ThrowHelper.ThrowApplicationException(validation.Errors.Select(p => p.Message));
            }

            user = UserFactory.CreateAccount(userDto.Username, userDto.Password, userDto.Email);

            validation = validator.ValidateAccount(user);

            if (!validation.IsValid)
            {
                ThrowHelper.ThrowApplicationException(validation.Errors.Select(p => p.Message));
            }

            userAccountRepository.Add(user);
            userAccountRepository.UnitOfWork.Commit();

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
    }
}
