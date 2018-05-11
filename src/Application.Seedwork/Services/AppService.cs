using Microsoft.Extensions.Logging;

namespace Ritter.Application.Services
{
    public abstract class AppService : IAppService
    {
        protected readonly ILogger logger;

        protected AppService(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
