using Microsoft.Extensions.Logging;

namespace Aritter.Infra.Crosscutting.Logging
{
    public class NLogProvider : ILoggerProvider
    {
        private ILogger logger;

        public ILogger CreateLogger(string categoryName)
        {
            if (logger == null)
            {
                logger = new NLogLogger(categoryName);
            }

            return logger;
        }

        public void Dispose()
        {
            logger = null;
        }
    }
}