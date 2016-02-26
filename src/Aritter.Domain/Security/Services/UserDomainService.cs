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
            : base()
        {
            this.userRoleRepository = userRoleRepository;
            this.userRepository = userRepository;
        }

        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            if (!userRepository.Any(UsersSpecifications.FindByUserName(userName)))
            {
                return await Task.FromResult<User>(null);
            }

            User user = userRepository.GetAuthenticationData(userName);

            if (user == null || !user.ValidatePassword(password))
            {
                return await Task.FromResult<User>(null);
            }

            return await Task.FromResult(user);
        }
    }
}
