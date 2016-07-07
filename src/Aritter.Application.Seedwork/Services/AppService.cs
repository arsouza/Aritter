using Microsoft.Extensions.Logging;
using System;

namespace Aritter.Application.Seedwork.Services
{
    public abstract class AppService : IAppService
    {
        protected readonly ILogger logger;

        public AppService()
        {
            logger = Infra.Crosscutting.Logging.LoggerFactory.CurrentFactory.CreateLogger(this.GetType().Name);
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