using System;
using Aritter.Infra.Crosscutting.Logging;

namespace Aritter.Infra.Crosscutting.Tests.Logging
{
    public class TestLogger : ILogger
    {
        public void Debug(string message, params object[] args)
        {
        }

        public void Debug(Exception exception, string message, params object[] args)
        {
        }

        public void Debug(object item)
        {
        }

        public void Error(string message, params object[] args)
        {
        }

        public void Error(Exception exception, string message, params object[] args)
        {
        }

        public void Fatal(string message, params object[] args)
        {
        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
        }

        public void Info(string message, params object[] args)
        {
        }

        public void Warning(string message, params object[] args)
        {
        }
    }
}