using Aritter.Infra.Configuration;
using Aritter.Infra.Configuration.Elements;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Logging
{
    public class NLogLogger : Microsoft.Extensions.Logging.ILogger
    {
        private readonly Logger logger;

        private Dictionary<Microsoft.Extensions.Logging.LogLevel, NLog.LogLevel> logLevelMap = new Dictionary<Microsoft.Extensions.Logging.LogLevel, NLog.LogLevel>
        {
            { Microsoft.Extensions.Logging.LogLevel.Trace, NLog.LogLevel.Trace },
            { Microsoft.Extensions.Logging.LogLevel.Debug, NLog.LogLevel.Debug },
            { Microsoft.Extensions.Logging.LogLevel.Information, NLog.LogLevel.Info },
            { Microsoft.Extensions.Logging.LogLevel.Warning, NLog.LogLevel.Warn },
            { Microsoft.Extensions.Logging.LogLevel.Error, NLog.LogLevel.Error },
            { Microsoft.Extensions.Logging.LogLevel.Critical, NLog.LogLevel.Fatal },
            { Microsoft.Extensions.Logging.LogLevel.None, NLog.LogLevel.Off },
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
            var nlogLevel = logLevelMap[logLevel];
            var loggingLevel = (LoggingLevel)Enum.Parse(typeof(LoggingLevel), nlogLevel.Name);

            return ApplicationSettings.Logging.Rules.Cast<LoggingRuleElement>().Any(p => p.MinLevel == loggingLevel);
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            logger.Log(logLevelMap[logLevel], exception, formatter(state, exception), state);
            Debug.WriteLine(formatter(state, exception));
        }

        #endregion
    }
}