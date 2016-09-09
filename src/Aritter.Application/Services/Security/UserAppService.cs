using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Specs;
using Aritter.Domain.Security.Aggregates.Validators;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Application.Services.Security
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserRepository userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            Check.IsNotNull(userRepository, nameof(userRepository));

            this.userRepository = userRepository;
        }

        public UserDto AddUser(AddUserDto addUser)
        {
            if (addUser == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user user");
            }

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
            var validation = validator.ValidateUser(user);

            if (!validation.IsValid)
            {
                ThrowHelper.ThrowApplicationException(validation.Errors.Select(p => p.Message));
            }

            userRepository.Save(user);
            userRepository.UnitOfWork.Commit();

            return newUser.ProjectedAs<UserDto>();
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
