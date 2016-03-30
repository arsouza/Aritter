using System;

namespace Aritter.Infra.CrossCutting.Logging
{
	public interface ILogger
	{
		void Debug<T>(T item);
		void Debug(string message, params object[] args);
		void Debug(string message, Exception exception, params object[] args);
		void Fatal<T>(T item);
		void Fatal(string message, params object[] args);
		void Fatal(string message, Exception exception, params object[] args);
		void Info<T>(T item);
		void Info(string message, params object[] args);
		void Warning<T>(T item);
		void Warning(string message, params object[] args);
		void Error<T>(T item);
		void Error(string message, params object[] args);
		void Error(string message, Exception exception, params object[] args);

	}

}