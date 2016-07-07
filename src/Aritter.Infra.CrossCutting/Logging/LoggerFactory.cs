using Microsoft.Extensions.Logging;

namespace Aritter.Infra.Crosscutting.Logging
{
    public class LoggerFactory : ILoggerFactory
    {
        #region Members

        private static ILoggerFactory currentFactory;
        private ILoggerProvider provider;

        #endregion

        #region Properties

        public static ILoggerFactory CurrentFactory
        {
            get
            {
                if (currentFactory == null)
                {
                    currentFactory = new LoggerFactory();
                }

                return currentFactory;
            }
        }

        #endregion

        #region Public Methods

        public void AddProvider(ILoggerProvider provider)
        {
            this.provider = provider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return provider?.CreateLogger(categoryName);
        }

        public void Dispose()
        {
            provider?.Dispose();
            provider = null;
        }

        #endregion
    }
}