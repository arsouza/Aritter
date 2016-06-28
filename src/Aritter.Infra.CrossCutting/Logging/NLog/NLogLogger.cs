using NLog;
using System;

namespace Aritter.Infra.Crosscutting.Logging.NLog
{
    public class NLogLogger : ILogger
	{
		private readonly Logger logger;

		public NLogLogger()
		{
			logger = LogManager.GetLogger("application");
		}

		public void Debug(string message, params object[] args)
		{
			logger.Debug(message, args);
		}

		public void Debug(string message, Exception exception, params object[] args)
		{
			logger.Debug(exception, message, args);
		}

		public void Debug<T>(T item)
		{
			logger.Debug(item);
		}

		public void Error(string message, params object[] args)
		{
			logger.Error(message, args);
		}

		public void Error(string message, Exception exception, params object[] args)
		{
			logger.Error(exception, message, args);
		}

		public void Error<T>(T item)
		{
			logger.Error(item);
		}

		public void Fatal(string message, params object[] args)
		{
			logger.Fatal(message, args);
		}

		public void Fatal(string message, Exception exception, params object[] args)
		{
			logger.Fatal(exception, message, args);
		}

		public void Fatal<T>(T item)
		{
			logger.Fatal(item);
		}

		public void Info(string message, params object[] args)
		{
			logger.Info(message, args);
		}

		public void Info<T>(T item)
		{
			logger.Info(item);
		}

		public void Warning(string message, params object[] args)
		{
			logger.Warn(message, args);
		}

		public void Warning<T>(T item)
		{
			logger.Warn(item);
		}
	}
}