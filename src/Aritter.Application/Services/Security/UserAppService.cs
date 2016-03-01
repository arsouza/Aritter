using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Services;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Aritter.Application.Services.Security
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserDomainService userDomainService;

        public UserAppService(
            IUserDomainService userDomainService)
        {
            Contract.Requires(userDomainService != null);

            this.userDomainService = userDomainService;
        }

        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            return await userDomainService.AuthenticateAsync(userName, password);
        }

        public async Task<User> GetUserClaimsAsync(string userName)
        {
            return await userDomainService.GetUserClaimsAsync(userName);
        }
    }
}