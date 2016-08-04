using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.DTO.SecurityModule.Users;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.SecurityModule.Aggregates.Users.Specs;
using Aritter.Domain.SecurityModule.Aggregates.Users.Validators;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Application.Services.SecurityModule
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserRepository userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserDto CreateUser(AddUserDto userDto)
        {
            if (userRepository.Any(new DuplicatedUserSpec(userDto.Username, userDto.Email)))
            {
                throw new ApplicationErrorException("User already exists");
            }

            var person = ProfileFactory.CreateProfile(userDto.FirstName, userDto.LastName);
            var user = UserFactory.CreateUser(person, userDto.Username, userDto.Password, userDto.Email);

            UserValidator validator = new UserValidator();
            var validation = validator.ValidateUser(user);

            if (!validation.IsValid)
            {
                throw new ApplicationErrorException(validation.Errors.Select(p => $"{p.Message}").ToArray());
            }

            userRepository.Add(user);
            userRepository.UnitOfWork.CommitChanges();

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
