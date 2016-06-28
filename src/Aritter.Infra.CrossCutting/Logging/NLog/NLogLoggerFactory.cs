namespace Aritter.Infra.Crosscutting.Logging.NLog
{
    public class NLogLoggerFactory : ILoggerFactory
	{
		public ILogger Create()
		{
			return new NLogLogger();
		}
	}
}