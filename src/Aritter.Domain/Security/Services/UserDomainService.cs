using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.Services;
using System.Threading.Tasks;

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

        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            return await Task.FromResult(Authenticate(userName, password));
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

        public async Task<User> GetAuthorizationsAsync(string userName)
        {
            return await Task.FromResult(GetAuthorizations(userName));
        }

        public User GetAuthorizations(string userName)
        {
            return userRepository.GetAuthorizations(UsersSpecifications.FindByUserName(userName));
        }
    }
}
