using Microsoft.Extensions.Logging;
using System;

namespace Ritter.Application.Seedwork.Services
{
    public abstract class AppService : IAppService
    {
        private bool disposed = false;
        protected ILogger logger;

        public AppService(ILogger logger)
        {
            this.logger = logger;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                logger = null;
                disposed = true;
            }
        }

        ~AppService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
