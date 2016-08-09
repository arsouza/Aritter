using Microsoft.Extensions.Logging;

namespace Aritter.Infra.Crosscutting.Logging
{
    public class NLogFactory : ILoggerFactory, Microsoft.Extensions.Logging.ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
        }

        public ILogger Create()
        {
            return new NLogLogger("Aritter");
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return new NLogLogger(categoryName);
        }

        public void Dispose()
        {
        }
    }
}