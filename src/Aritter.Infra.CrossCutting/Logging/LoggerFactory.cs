namespace Aritter.Infra.Crosscutting.Logging
{
    public static class LoggerFactory
    {
        #region Members

        private static ILoggerFactory currentLogFactory;

        #endregion

        #region Public Methods

        public static void SetCurrent(ILoggerFactory logFactory)
        {
            currentLogFactory = logFactory;
        }

        public static ILogger CreateLog()
        {
            return currentLogFactory?.Create();
        }

        #endregion
    }
}