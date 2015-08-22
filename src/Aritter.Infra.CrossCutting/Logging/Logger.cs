using Aritter.Infra.CrossCutting.Configuration;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Linq;

namespace Aritter.Infra.CrossCutting.Logging
{
	public class Logger : ILogger
	{
		#region Attributes

		private static ILogger application;
		private static ILogger database;

		private readonly NLog.Logger logger;

		#endregion

		#region Constructors

		public Logger(NLog.Logger logger)
		{
			if (logger == null)
				throw new ArgumentNullException(nameof(logger));

			this.logger = logger;
		}

		#endregion

		#region Properties

		public static ILogger Application
		{
			get
			{
				if (application != null)
					return application;

				ConfigureLoggers();

				var logger = LogManager.GetLogger("application");
				application = new Logger(logger);

				return application;
			}
		}

		public static ILogger Database
		{
			get
			{
				if (database != null)
					return database;

				ConfigureLoggers();

				var logger = LogManager.GetLogger("database");
				database = new Logger(logger);

				return database;
			}
		}

		public bool IsDebugEnabled
		{
			get { return logger.IsDebugEnabled; }
		}

		public bool IsErrorEnabled
		{
			get { return logger.IsErrorEnabled; }
		}

		public bool IsFatalEnabled
		{
			get { return logger.IsFatalEnabled; }
		}

		public bool IsInfoEnabled
		{
			get { return logger.IsInfoEnabled; }
		}

		public bool IsTraceEnabled
		{
			get { return logger.IsTraceEnabled; }
		}

		public bool IsWarnEnabled
		{
			get { return logger.IsWarnEnabled; }
		}

		public string Name
		{
			get { return logger.Name; }
		}

		#endregion

		#region Methods

		#region Debug

		public void Debug(IFormatProvider formatProvider, object value)
		{
			logger.Debug(formatProvider, value);
		}

		public void Debug(IFormatProvider formatProvider, string message, params object[] args)
		{
			logger.Debug(formatProvider, message, args);
		}

		public void Debug(IFormatProvider formatProvider, string message, bool argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, byte argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, char argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, decimal argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, double argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, int argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, long argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, object argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, sbyte argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, float argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, string argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, uint argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, ulong argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug(object value)
		{
			logger.Debug(value);
		}

		public void Debug(string message)
		{
			logger.Debug(message);
		}

		public void Debug(string message, params object[] args)
		{
			logger.Debug(message, args);
		}

		public void Debug(string message, bool argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, byte argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, char argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, decimal argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, double argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, Exception exception, params object[] args)
		{
			logger.Debug(message, exception, args);
		}

		public void Debug(string message, int argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, long argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, object arg1, object arg2)
		{
			logger.Debug(message, arg1, arg2);
		}

		public void Debug(string message, object arg1, object arg2, object arg3)
		{
			logger.Debug(message, arg1, arg2, arg3);
		}

		public void Debug(string message, object argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, sbyte argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, float argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, string argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, uint argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug(string message, ulong argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug<T>(IFormatProvider formatProvider, T value)
		{
			logger.Debug(formatProvider, value);
		}

		public void Debug<T>(T value)
		{
			logger.Debug(value);
		}

		public void Debug<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			logger.Debug(formatProvider, message, argument);
		}

		public void Debug<TArgument>(string message, TArgument argument)
		{
			logger.Debug(message, argument);
		}

		public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Debug(formatProvider, message, argument1, argument2, argument3);
		}

		public void Debug<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Debug(message, argument1, argument2, argument3);
		}

		public void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Debug(formatProvider, message, argument1, argument2);
		}

		public void Debug<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Debug(message, argument1, argument2);
		}

		public void DebugException(string message, Exception exception, params object[] args)
		{
			logger.Debug(message, exception, args);
		}

		#endregion

		#region Error

		public void Error(IFormatProvider formatProvider, object value)
		{
			logger.Error(formatProvider, value);
		}

		public void Error(IFormatProvider formatProvider, string message, params object[] args)
		{
			logger.Error(formatProvider, message, args);
		}

		public void Error(IFormatProvider formatProvider, string message, bool argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, byte argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, char argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, decimal argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, double argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, int argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, long argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, object argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, sbyte argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, float argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, string argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, uint argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, ulong argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error(object value)
		{
			logger.Error(value);
		}

		public void Error(string message)
		{
			logger.Error(message);
		}

		public void Error(string message, params object[] args)
		{
			logger.Error(message, args);
		}

		public void Error(string message, bool argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, byte argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, char argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, decimal argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, double argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, Exception exception, params object[] args)
		{
			logger.Error(message, exception, args);
		}

		public void Error(string message, int argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, long argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, object arg1, object arg2)
		{
			logger.Error(message, arg1, arg2);
		}

		public void Error(string message, object arg1, object arg2, object arg3)
		{
			logger.Error(message, arg1, arg2, arg3);
		}

		public void Error(string message, object argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, sbyte argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, float argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, string argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, uint argument)
		{
			logger.Error(message, argument);
		}

		public void Error(string message, ulong argument)
		{
			logger.Error(message, argument);
		}

		public void Error<T>(IFormatProvider formatProvider, T value)
		{
			logger.Error(formatProvider, value);
		}

		public void Error<T>(T value)
		{
			logger.Error(value);
		}

		public void Error<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			logger.Error(formatProvider, message, argument);
		}

		public void Error<TArgument>(string message, TArgument argument)
		{
			logger.Error(message, argument);
		}

		public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Error(formatProvider, message, argument1, argument2, argument3);
		}

		public void Error<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Error(message, argument1, argument2, argument3);
		}

		public void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Error(formatProvider, message, argument1, argument2);
		}

		public void Error<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Error(message, argument1, argument2);
		}

		public void ErrorException(string message, Exception exception, params object[] args)
		{
			logger.Error(message, exception, args);
		}

		#endregion

		#region Fatal

		public void Fatal(IFormatProvider formatProvider, object value)
		{
			logger.Fatal(formatProvider, value);
		}

		public void Fatal(IFormatProvider formatProvider, string message, params object[] args)
		{
			logger.Fatal(formatProvider, message, args);
		}

		public void Fatal(IFormatProvider formatProvider, string message, bool argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, byte argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, char argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, decimal argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, double argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, int argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, long argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, object argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, sbyte argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, float argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, string argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, uint argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, ulong argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(object value)
		{
			logger.Fatal(value);
		}

		public void Fatal(string message)
		{
			logger.Fatal(message);
		}

		public void Fatal(string message, params object[] args)
		{
			logger.Fatal(message, args);
		}

		public void Fatal(string message, bool argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, byte argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, char argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, decimal argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, double argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, Exception exception, params object[] args)
		{
			logger.Fatal(message, exception, args);
		}

		public void Fatal(string message, int argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, long argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, object arg1, object arg2)
		{
			logger.Fatal(message, arg1, arg2);
		}

		public void Fatal(string message, object arg1, object arg2, object arg3)
		{
			logger.Fatal(message, arg1, arg2, arg3);
		}

		public void Fatal(string message, object argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, sbyte argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, float argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, string argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, uint argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal(string message, ulong argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal<T>(IFormatProvider formatProvider, T value)
		{
			logger.Fatal(formatProvider, value);
		}

		public void Fatal<T>(T value)
		{
			logger.Fatal(value);
		}

		public void Fatal<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal<TArgument>(string message, TArgument argument)
		{
			logger.Fatal(message, argument);
		}

		public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Fatal(formatProvider, message, argument1, argument2, argument3);
		}

		public void Fatal<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Fatal(message, argument1, argument2, argument3);
		}

		public void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Fatal(formatProvider, message, argument1, argument2);
		}

		public void Fatal<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Fatal(message, argument1, argument2);
		}

		public void FatalException(string message, Exception exception, params object[] args)
		{
			logger.Fatal(message, exception, args);
		}

		#endregion

		#region Info

		public void Info(IFormatProvider formatProvider, object value)
		{
			logger.Info(formatProvider, value);
		}

		public void Info(IFormatProvider formatProvider, string message, params object[] args)
		{
			logger.Info(formatProvider, message, args);
		}

		public void Info(IFormatProvider formatProvider, string message, bool argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, byte argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, char argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, decimal argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, double argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, int argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, long argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, object argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, sbyte argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, float argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, string argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, uint argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, ulong argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info(object value)
		{
			logger.Info(value);
		}

		public void Info(string message)
		{
			logger.Info(message);
		}

		public void Info(string message, params object[] args)
		{
			logger.Info(message, args);
		}

		public void Info(string message, bool argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, byte argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, char argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, decimal argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, double argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, Exception exception, params object[] args)
		{
			logger.Info(message, exception, args);
		}

		public void Info(string message, int argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, long argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, object arg1, object arg2)
		{
			logger.Info(message, arg1, arg2);
		}

		public void Info(string message, object arg1, object arg2, object arg3)
		{
			logger.Info(message, arg1, arg2, arg3);
		}

		public void Info(string message, object argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, sbyte argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, float argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, string argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, uint argument)
		{
			logger.Info(message, argument);
		}

		public void Info(string message, ulong argument)
		{
			logger.Info(message, argument);
		}

		public void Info<T>(IFormatProvider formatProvider, T value)
		{
			logger.Info(formatProvider, value);
		}

		public void Info<T>(T value)
		{
			logger.Info(value);
		}

		public void Info<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			logger.Info(formatProvider, message, argument);
		}

		public void Info<TArgument>(string message, TArgument argument)
		{
			logger.Info(message, argument);
		}

		public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Info(formatProvider, message, argument1, argument2, argument3);
		}

		public void Info<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Info(message, argument1, argument2, argument3);
		}

		public void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Info(formatProvider, message, argument1, argument2);
		}

		public void Info<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Info(message, argument1, argument2);
		}

		public void InfoException(string message, Exception exception, params object[] args)
		{
			logger.Info(message, exception, args);
		}

		#endregion

		#region Trace

		public void Trace(IFormatProvider formatProvider, object value)
		{
			logger.Trace(formatProvider, value);
		}

		public void Trace(IFormatProvider formatProvider, string message, params object[] args)
		{
			logger.Trace(formatProvider, message, args);
		}

		public void Trace(IFormatProvider formatProvider, string message, bool argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, byte argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, char argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, decimal argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, double argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, int argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, long argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, object argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, sbyte argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, float argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, string argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, uint argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, ulong argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace(object value)
		{
			logger.Trace(value);
		}

		public void Trace(string message)
		{
			logger.Trace(message);
		}

		public void Trace(string message, params object[] args)
		{
			logger.Trace(message, args);
		}

		public void Trace(string message, bool argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, byte argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, char argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, decimal argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, double argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, Exception exception, params object[] args)
		{
			logger.Trace(message, exception, args);
		}

		public void Trace(string message, int argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, long argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, object arg1, object arg2)
		{
			logger.Trace(message, arg1, arg2);
		}

		public void Trace(string message, object arg1, object arg2, object arg3)
		{
			logger.Trace(message, arg1, arg2, arg3);
		}

		public void Trace(string message, object argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, sbyte argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, float argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, string argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, uint argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace(string message, ulong argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace<T>(IFormatProvider formatProvider, T value)
		{
			logger.Trace(formatProvider, value);
		}

		public void Trace<T>(T value)
		{
			logger.Trace(value);
		}

		public void Trace<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			logger.Trace(formatProvider, message, argument);
		}

		public void Trace<TArgument>(string message, TArgument argument)
		{
			logger.Trace(message, argument);
		}

		public void Trace<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Trace(formatProvider, message, argument1, argument2, argument3);
		}

		public void Trace<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Trace(message, argument1, argument2, argument3);
		}

		public void Trace<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Trace(formatProvider, message, argument1, argument2);
		}

		public void Trace<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Trace(message, argument1, argument2);
		}

		public void TraceException(string message, Exception exception, params object[] args)
		{
			logger.Trace(message, exception, args);
		}

		#endregion

		#region Warn

		public void Warn(IFormatProvider formatProvider, object value)
		{
			logger.Warn(formatProvider, value);
		}

		public void Warn(IFormatProvider formatProvider, string message, params object[] args)
		{
			logger.Warn(formatProvider, message, args);
		}

		public void Warn(IFormatProvider formatProvider, string message, bool argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, byte argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, char argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, decimal argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, double argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, int argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, long argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, object argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, sbyte argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, float argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, string argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, uint argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, ulong argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn(object value)
		{
			logger.Warn(value);
		}

		public void Warn(string message)
		{
			logger.Warn(message);
		}

		public void Warn(string message, params object[] args)
		{
			logger.Warn(message, args);
		}

		public void Warn(string message, bool argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, byte argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, char argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, decimal argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, double argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, Exception exception, params object[] args)
		{
			logger.Warn(message, exception, args);
		}

		public void Warn(string message, int argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, long argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, object arg1, object arg2)
		{
			logger.Warn(message, arg1, arg2);
		}

		public void Warn(string message, object arg1, object arg2, object arg3)
		{
			logger.Warn(message, arg1, arg2, arg3);
		}

		public void Warn(string message, object argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, sbyte argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, float argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, string argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, uint argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn(string message, ulong argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn<T>(IFormatProvider formatProvider, T value)
		{
			logger.Warn(formatProvider, value);
		}

		public void Warn<T>(T value)
		{
			logger.Warn(value);
		}

		public void Warn<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			logger.Warn(formatProvider, message, argument);
		}

		public void Warn<TArgument>(string message, TArgument argument)
		{
			logger.Warn(message, argument);
		}

		public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Warn(formatProvider, message, argument1, argument2, argument3);
		}

		public void Warn<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			logger.Warn(message, argument1, argument2, argument3);
		}

		public void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Warn(formatProvider, message, argument1, argument2);
		}

		public void Warn<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			logger.Warn(message, argument1, argument2);
		}

		public void WarnException(string message, Exception exception, params object[] args)
		{
			logger.Warn(message, exception, args);
		}

		#endregion

		private static void ConfigureLoggers()
		{
			var loggingSettings = ApplicationSettings.Logging;

			var config = new LoggingConfiguration();

			foreach (LoggingTargetElement targetElement in loggingSettings.Targets)
			{
				CreateTarget(config, targetElement);
			}

			foreach (LoggingRuleElement ruleElement in loggingSettings.Rules)
			{
				CreateRule(config, ruleElement);
			}

			LogManager.Configuration = config;
		}

		private static void CreateRule(LoggingConfiguration config, LoggingRuleElement ruleElement)
		{
			switch (ruleElement.MinLevel)
			{
				case LoggingLevel.Debug:
					AddDebugRule(config, ruleElement);
					break;
				case LoggingLevel.Error:
					AddErrorRule(config, ruleElement);
					break;
				case LoggingLevel.Fatal:
					AddFatalRule(config, ruleElement);
					break;
				case LoggingLevel.Info:
					AddInfoRule(config, ruleElement);
					break;
				case LoggingLevel.Off:
					AddOffRule(config, ruleElement);
					break;
				case LoggingLevel.Trace:
					AddTraceRule(config, ruleElement);
					break;
				case LoggingLevel.Warn:
					AddWarnRule(config, ruleElement);
					break;
			}
		}

		private static void AddDebugRule(LoggingConfiguration config, LoggingRuleElement ruleElement)
		{
			AddRule(config, LogLevel.Debug, ruleElement);
		}

		private static void AddErrorRule(LoggingConfiguration config, LoggingRuleElement ruleElement)
		{
			AddRule(config, LogLevel.Error, ruleElement);
		}

		private static void AddFatalRule(LoggingConfiguration config, LoggingRuleElement ruleElement)
		{
			AddRule(config, LogLevel.Fatal, ruleElement);
		}

		private static void AddInfoRule(LoggingConfiguration config, LoggingRuleElement ruleElement)
		{
			AddRule(config, LogLevel.Info, ruleElement);
		}

		private static void AddOffRule(LoggingConfiguration config, LoggingRuleElement ruleElement)
		{
			AddRule(config, LogLevel.Off, ruleElement);
		}

		private static void AddTraceRule(LoggingConfiguration config, LoggingRuleElement ruleElement)
		{
			AddRule(config, LogLevel.Trace, ruleElement);
		}

		private static void AddWarnRule(LoggingConfiguration config, LoggingRuleElement ruleElement)
		{
			AddRule(config, LogLevel.Warn, ruleElement);
		}

		private static void AddRule(LoggingConfiguration config, LogLevel logLevel, LoggingRuleElement ruleElement)
		{
			var target = config.ConfiguredNamedTargets.FirstOrDefault(p => p.Name == ruleElement.WriteTo);

			if (target != null)
			{
				var rule = new LoggingRule(ruleElement.Name, logLevel, target);
				config.LoggingRules.Add(rule);
			}
		}

		private static void CreateTarget(LoggingConfiguration config, LoggingTargetElement targetElement)
		{
			switch (targetElement.Type)
			{
				case "Console":
					AddConsoleTarget(config, targetElement);
					break;

				case "File":
					AddFileTarget(config, targetElement);
					break;
			}
		}

		private static void AddFileTarget(LoggingConfiguration config, LoggingTargetElement targetElement)
		{
			var fileTarget = new FileTarget
			{
				Name = targetElement.Name,
				FileName = targetElement.FileName,
				Layout = targetElement.Layout
			};

			config.AddTarget("file", fileTarget);
		}

		private static void AddConsoleTarget(LoggingConfiguration config, LoggingTargetElement targetElement)
		{
			var consoleTarget = new ColoredConsoleTarget
			{
				Layout = targetElement.Layout
			};

			config.AddTarget("console", consoleTarget);
		}

		#endregion
	}
}