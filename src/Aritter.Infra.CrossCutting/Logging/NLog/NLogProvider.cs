using Microsoft.Extensions.Logging;

namespace Aritter.Infra.Crosscutting.Logging
{
    public class NLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new NLogLogger(categoryName);
        }

        public void Dispose()
        {
        }
    }
}