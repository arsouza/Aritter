using Microsoft.Extensions.Logging;

namespace Ritter.Application.Seedwork.Services
{
    public abstract class AppService : IAppService
    {
        protected ILogger logger;

        protected AppService(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
