namespace Aritter.Infra.CrossCutting.Logging.NLog
{
	public class NLogLoggerFactory : ILoggerFactory
	{
		public ILogger Create()
		{
			return new NLogLogger();
		}
	}
}