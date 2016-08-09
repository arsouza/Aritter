using NLog;
using System;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Logging
{
    public class NLogLogger : ILogger, Microsoft.Extensions.Logging.ILogger
    {
        private readonly Logger logger;

        private static Dictionary<Microsoft.Extensions.Logging.LogLevel, LogLevel> loggingLevels = new Dictionary<Microsoft.Extensions.Logging.LogLevel, LogLevel>
        {
            { Microsoft.Extensions.Logging.LogLevel.Trace, LogLevel.Trace },
            { Microsoft.Extensions.Logging.LogLevel.Debug, LogLevel.Debug },
            { Microsoft.Extensions.Logging.LogLevel.Information, LogLevel.Info },
            { Microsoft.Extensions.Logging.LogLevel.Warning, LogLevel.Warn },
            { Microsoft.Extensions.Logging.LogLevel.Error, LogLevel.Error },
            { Microsoft.Extensions.Logging.LogLevel.Critical, LogLevel.Fatal },
            { Microsoft.Extensions.Logging.LogLevel.None, LogLevel.Off }
        };

        public NLogLogger(string name)
        {
            logger = LogManager.GetLogger(name);
        }

        #region Microsoft.Extensions.Logging.ILogger Members

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            try
            {
                var nlogLevel = loggingLevels[logLevel];
                return logger.IsEnabled(nlogLevel);
            }
            catch
            {
                return false;
            }
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, Microsoft.Extensions.Logging.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            logger.Log(loggingLevels[logLevel], exception, formatter(state, exception), state);
        }

        #endregion

        public void Debug(string message, params object[] args)
        {
            logger.Debug(message, args);
        }

        public void Debug(Exception exception, string message, params object[] args)
        {
            logger.Debug(exception, message, args);
        }

        public void Debug(object item)
        {
            logger.Debug(item);
        }

        public void Fatal(string message, params object[] args)
        {
            logger.Fatal(message, args);
        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
            logger.Fatal(exception, message, args);
        }

        public void Info(string message, params object[] args)
        {
            logger.Info(message, args);
        }

        public void Warning(string message, params object[] args)
        {
            logger.Warn(message, args);
        }

        public void Error(string message, params object[] args)
        {
            logger.Error(message, args);
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            logger.Error(exception, message, args);
        }
    }
}