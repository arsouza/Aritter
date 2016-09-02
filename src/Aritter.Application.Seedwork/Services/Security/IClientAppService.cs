using Aritter.Application.DTO.SecurityModule;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IApplicationAppService : IAppService
    {
        ApplicationDto GetApplicationByUID(GetApplicationDto getApplication);
    }
}
