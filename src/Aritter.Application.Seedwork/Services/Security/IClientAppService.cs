using Aritter.Application.DTO.SecurityModule;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IClientAppService : IAppService
    {
        ClientDto GetClientByUID(GetClientDto getClient);
    }
}
