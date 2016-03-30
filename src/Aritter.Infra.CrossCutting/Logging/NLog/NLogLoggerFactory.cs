using Aritter.Infra.CrossCutting.Logging;
using Aritter.Infra.CrossCutting.Logging.NLog;

namespace Aritter.Infra.CrossCutting.NetFramework.Logging
{
	public class NLogLoggerFactory : ILoggerFactory
	{
		public ILogger Create()
		{
			return new NLogLogger();
		}
	}
}