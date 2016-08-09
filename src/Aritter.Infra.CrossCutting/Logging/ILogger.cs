using System;

namespace Aritter.Infra.Crosscutting.Logging
{
    public interface ILogger
    {
        void Debug(string message, params object[] args);

        void Debug(Exception exception, string message, params object[] args);

        void Debug(object item);

        void Info(string message, params object[] args);

        void Warning(string message, params object[] args);

        void Error(string message, params object[] args);

        void Error(Exception exception, string message, params object[] args);

        void Fatal(string message, params object[] args);

        void Fatal(Exception exception, string message, params object[] args);
    }
}
