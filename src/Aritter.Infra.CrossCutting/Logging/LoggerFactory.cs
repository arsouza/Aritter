namespace Aritter.Infra.Crosscutting.Logging
{
    public static class LoggerFactory
    {
        #region Members

        static ILoggerFactory currentLogFactory = null;

        #endregion

        #region Public Methods

        public static void SetCurrent(ILoggerFactory logFactory)
        {
            currentLogFactory = logFactory;
        }

        public static ILoggerFactory Current()
        {
            return currentLogFactory;
        }

        public static ILogger CreateLogger()
        {
            return currentLogFactory?.Create();
        }

        #endregion
    }
}
