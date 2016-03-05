using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.Services;

namespace Aritter.Domain.Security.Services
{
    public class UserDomainService : DomainService, IUserDomainService
    {
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IUserRepository userRepository;

        public UserDomainService(
            IUserRoleRepository userRoleRepository,
            IUserRepository userRepository)
        {
            this.userRoleRepository = userRoleRepository;
            this.userRepository = userRepository;
        }

        public User Authenticate(string userName, string password)
        {
            var user = userRepository.GetUserPassword(UsersSpecifications.FindByUserName(userName));

            if (user == null || !user.ValidatePassword(password))
            {
                return null;
            }

            return userRepository.GetAuthorizations(UsersSpecifications.FindByUserName(userName));
        }
    }
}
