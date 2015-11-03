using Aritter.Application.Contracts;
using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.SecurityModule.Services;
using Aritter.Infra.CrossCutting.Encryption;
using System.Diagnostics.Contracts;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Application.SecurityModule.Services
{
    public class AuthenticationAppService : AppService, IAuthenticationAppService
    {
        private readonly IAuthenticationDomainService authenticationDomainService;
        private readonly IUserRepository userRepository;

        public AuthenticationAppService(
            IAuthenticationDomainService authenticationDomainService,
            IUserRepository userRepository)
        {
            Contract.Requires(authenticationDomainService != null);
            Contract.Requires(userRepository != null);

            this.authenticationDomainService = authenticationDomainService;
            this.userRepository = userRepository;
        }

        public async Task<User> FindAsync(string userName, string password)
        {
            string passwordHash = Encrypter.Encrypt(password);
            var user = userRepository.FindByUsernameAndPassword(userName, passwordHash);

            return await Task.FromResult(user);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType)
        {
            return await authenticationDomainService.GenerateUserIdentityAsync(user, authenticationType);
        }
    }
}