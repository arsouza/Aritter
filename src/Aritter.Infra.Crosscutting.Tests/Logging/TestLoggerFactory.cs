using Aritter.Infra.Crosscutting.Logging;

namespace Aritter.Infra.Crosscutting.Tests.Logging
{
    public class TestLoggerFactory : ILoggerFactory
    {
        private ILogger Logger;
        private Microsoft.Extensions.Logging.ILoggerProvider provider;

        public void AddProvider(Microsoft.Extensions.Logging.ILoggerProvider provider)
        {
            this.provider = provider;
        }

        public ILogger Create()
        {
            return Logger ?? (Logger = new TestLogger());
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return provider.CreateLogger(categoryName);
        }

        public void Dispose()
        {
            Logger = null;
            provider = null;
        }
    }
}