using Aritter.Application.DTO.Mapping;
using Aritter.Application.DTO.Profiles.Security;
using Aritter.Application.DTO.Security;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.Security;
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

            var mapper = Mapper.CreateMapper<SecurityProfile>();
            return mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetAuthorizationsAsync(string userName)
        {
            var user = await userDomainService.GetAuthorizationsAsync(userName);

            var mapper = Mapper.CreateMapper<SecurityProfile>();
            return mapper.Map<UserDTO>(user);
        }
    }
}