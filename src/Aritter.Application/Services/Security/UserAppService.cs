using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Domain.Aggregates.Security;
using Aritter.Domain.Services.Security;
using Aritter.Infra.CrossCutting.Encryption;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Application.Services.Security
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserDomainService userDomainService;
        private readonly IUserRepository userRepository;

        public UserAppService(
            IUserDomainService userDomainService,
            IUserRepository userRepository)
        {
            Contract.Requires(userDomainService != null);
            Contract.Requires(userRepository != null);

            this.userDomainService = userDomainService;
            this.userRepository = userRepository;
        }

        public async Task<User> FindAsync(string userName, string password)
        {
            string passwordHash = Encrypter.Encrypt(password);
            var user = userRepository.FindByUsernameAndPassword(userName, passwordHash);

            var lastPassword = user.PasswordHistory.LastOrDefault();

            if (lastPassword.PasswordHash != passwordHash)
            {
                return await Task.FromResult((User)null);
            }

            return await Task.FromResult(user);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType)
        {
            return await userDomainService.GenerateUserIdentityAsync(user, authenticationType);
        }
    }
}