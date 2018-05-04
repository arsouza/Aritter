using Microsoft.Extensions.Logging;
using Ritter.Infra.Crosscutting.TypeAdapter;

namespace Ritter.Application.Services
{
    public abstract class AppService : IAppService
    {
        protected readonly ITypeAdapter typeAdapter;
        protected readonly ILogger logger;

        protected AppService(ITypeAdapter typeAdapter, ILogger logger)
        {
            this.typeAdapter = typeAdapter;
            this.logger = logger;
        }
    }
}
