using Aritter.Application.DTO.Mapping;
using Aritter.Application.DTO.Security;
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

        public async Task<UserDTO> AuthenticateAsync(string userName, string password)
        {
            var user = await userDomainService.AuthenticateAsync(userName, password);

            var mapper = Mapper.CreateMapper<User, UserDTO>();
            return mapper.Map<User, UserDTO>(user);
        }

        public async Task<UserDTO> GetUserClaimsAsync(string userName)
        {
            var user = await userDomainService.GetUserClaimsAsync(userName);

            var mapper = Mapper.CreateMapper<User, UserDTO>();
            return mapper.Map<User, UserDTO>(user);
        }
    }
}