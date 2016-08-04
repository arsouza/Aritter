using Aritter.Application.DTO.SecurityModule.Authentication;
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
        private readonly IUserAccountRepository userRepository;

        public UserAppService(IUserAccountRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserAccountDto AddUserAccount(AddUserAccountDto userDto)
        {
            UserAccountValidator validator = new UserAccountValidator();

            var user = userRepository.Get(new UsernameEqualsSpec(userDto.Username) | new EmailEqualsSpec(userDto.Email));

            var validation = validator.ValidateUserDuplicatated(user);

            if (!validation.IsValid)
            {
                throw new ApplicationErrorException(validation.Errors.Select(p => $"{p.Message}").ToArray());
            }

            user = UserFactory.CreateAccount(userDto.Username, userDto.Password, userDto.Email);

            validation = validator.ValidateUserAccount(user);

            if (!validation.IsValid)
            {
                throw new ApplicationErrorException(validation.Errors.Select(p => $"{p.Message}").ToArray());
            }

            userRepository.Add(user);
            userRepository.UnitOfWork.CommitChanges();

            return user.ProjectedAs<UserAccountDto>();
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
