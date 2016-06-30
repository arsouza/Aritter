using Aritter.Infra.Crosscutting.Logging;
using System;

namespace Aritter.Application.Seedwork.Services
{
    public abstract class AppService : IAppService
    {
        protected readonly ILogger logger;

        public AppService()
        {
            logger = LoggerFactory.CreateLog();
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AppService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion
    }
}