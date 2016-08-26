using Aritter.Application.DTO.SecurityModule;

namespace Aritter.Application.Seedwork.Services.SecurityModule
{
    public interface IClientAppService : IAppService
    {
        ClientDto GetClientByUID(GetClientDto getClientDto);
    }
}
