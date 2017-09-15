namespace Aritter.Infra.Crosscutting.Logging
{
    public static class LoggerFactory
    {
        static ILoggerFactory currentLogFactory = null;

        public static void SetCurrent(ILoggerFactory logFactory)
        {
            currentLogFactory = logFactory;
        }

        public static ILogger CreateLogger()
        {
            return currentLogFactory?.Create();
        }
    }
}
