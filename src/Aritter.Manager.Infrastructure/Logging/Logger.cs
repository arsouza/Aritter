using Aritter.Manager.Infrastructure.Configuration;
using Aritter.Manager.Infrastructure.Configuration.Elements;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Linq;

namespace Aritter.Manager.Infrastructure.Logging
{
	public class Logger : ILogger
	{
		#region Attributes

		private static ILogger application = null;
		private static ILogger database = null;

		private readonly NLog.Logger logger = null;

		#endregion

		#region Constructors

		public Logger(NLog.Logger logger)
		{
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
			get { return this.logger.IsDebugEnabled; }
		}

		public bool IsErrorEnabled
		{
			get { return this.logger.IsErrorEnabled; }
		}

		public bool IsFatalEnabled
		{
			get { return this.logger.IsFatalEnabled; }
		}

		public bool IsInfoEnabled
		{
			get { return this.logger.IsInfoEnabled; }
		}

		public bool IsTraceEnabled
		{
			get { return this.logger.IsTraceEnabled; }
		}

		public bool IsWarnEnabled
		{
			get { return this.logger.IsWarnEnabled; }
		}

		public string Name
		{
			get { return this.logger.Name; }
		}

		#endregion

		#region Methods

		#region Debug

		public void Debug(IFormatProvider formatProvider, object value)
		{
			this.logger.Debug(formatProvider, value);
		}

		public void Debug(IFormatProvider formatProvider, string message, params object[] args)
		{
			this.logger.Debug(formatProvider, message, args);
		}

		public void Debug(IFormatProvider formatProvider, string message, bool argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, byte argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, char argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, decimal argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, double argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, int argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, long argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, object argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, sbyte argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, float argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, string argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, uint argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(IFormatProvider formatProvider, string message, ulong argument)
		{
			this.logger.Debug(formatProvider, message, argument);
		}

		public void Debug(object value)
		{
			this.logger.Debug(value);
		}

		public void Debug(string message)
		{
			this.logger.Debug(message);
		}

		public void Debug(string message, params object[] args)
		{
			this.logger.Debug(message, args);
		}

		public void Debug(string message, bool argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, byte argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, char argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, decimal argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, double argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, Exception exception)
		{
			this.logger.Debug(message, exception);
		}

		public void Debug(string message, int argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, long argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, object arg1, object arg2)
		{
			this.logger.Debug(message, arg1, arg2);
		}

		public void Debug(string message, object arg1, object arg2, object arg3)
		{
			this.logger.Debug(message, arg1, arg2, arg3);
		}

		public void Debug(string message, object argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, sbyte argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, float argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, string argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, uint argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug(string message, ulong argument)
		{
			this.logger.Debug(message, argument);
		}

		public void Debug<T>(IFormatProvider formatProvider, T value)
		{
			this.logger.Debug<T>(formatProvider, value);
		}

		public void Debug<T>(T value)
		{
			this.logger.Debug<T>(value);
		}

		public void Debug<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			this.logger.Debug<TArgument>(formatProvider, message, argument);
		}

		public void Debug<TArgument>(string message, TArgument argument)
		{
			this.logger.Debug<TArgument>(message, argument);
		}

		public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Debug<TArgument1, TArgument2, TArgument3>(formatProvider, message, argument1, argument2, argument3);
		}

		public void Debug<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Debug<TArgument1, TArgument2, TArgument3>(message, argument1, argument2, argument3);
		}

		public void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Debug<TArgument1, TArgument2>(formatProvider, message, argument1, argument2);
		}

		public void Debug<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Debug<TArgument1, TArgument2>(message, argument1, argument2);
		}

		public void DebugException(string message, Exception exception)
		{
			this.logger.Debug(message, exception);
		}

		#endregion

		#region Error

		public void Error(IFormatProvider formatProvider, object value)
		{
			this.logger.Error(formatProvider, value);
		}

		public void Error(IFormatProvider formatProvider, string message, params object[] args)
		{
			this.logger.Error(formatProvider, message, args);
		}

		public void Error(IFormatProvider formatProvider, string message, bool argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, byte argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, char argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, decimal argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, double argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, int argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, long argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, object argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, sbyte argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, float argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, string argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, uint argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(IFormatProvider formatProvider, string message, ulong argument)
		{
			this.logger.Error(formatProvider, message, argument);
		}

		public void Error(object value)
		{
			this.logger.Error(value);
		}

		public void Error(string message)
		{
			this.logger.Error(message);
		}

		public void Error(string message, params object[] args)
		{
			this.logger.Error(message, args);
		}

		public void Error(string message, bool argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, byte argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, char argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, decimal argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, double argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, Exception exception)
		{
			this.logger.Error(message, exception);
		}

		public void Error(string message, int argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, long argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, object arg1, object arg2)
		{
			this.logger.Error(message, arg1, arg2);
		}

		public void Error(string message, object arg1, object arg2, object arg3)
		{
			this.logger.Error(message, arg1, arg2, arg3);
		}

		public void Error(string message, object argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, sbyte argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, float argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, string argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, uint argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error(string message, ulong argument)
		{
			this.logger.Error(message, argument);
		}

		public void Error<T>(IFormatProvider formatProvider, T value)
		{
			this.logger.Error<T>(formatProvider, value);
		}

		public void Error<T>(T value)
		{
			this.logger.Error<T>(value);
		}

		public void Error<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			this.logger.Error<TArgument>(formatProvider, message, argument);
		}

		public void Error<TArgument>(string message, TArgument argument)
		{
			this.logger.Error<TArgument>(message, argument);
		}

		public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Error<TArgument1, TArgument2, TArgument3>(formatProvider, message, argument1, argument2, argument3);
		}

		public void Error<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Error<TArgument1, TArgument2, TArgument3>(message, argument1, argument2, argument3);
		}

		public void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Error<TArgument1, TArgument2>(formatProvider, message, argument1, argument2);
		}

		public void Error<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Error<TArgument1, TArgument2>(message, argument1, argument2);
		}

		public void ErrorException(string message, Exception exception)
		{
			this.logger.Error(message, exception);
		}

		#endregion

		#region Fatal

		public void Fatal(IFormatProvider formatProvider, object value)
		{
			this.logger.Fatal(formatProvider, value);
		}

		public void Fatal(IFormatProvider formatProvider, string message, params object[] args)
		{
			this.logger.Fatal(formatProvider, message, args);
		}

		public void Fatal(IFormatProvider formatProvider, string message, bool argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, byte argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, char argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, decimal argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, double argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, int argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, long argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, object argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, sbyte argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, float argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, string argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, uint argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(IFormatProvider formatProvider, string message, ulong argument)
		{
			this.logger.Fatal(formatProvider, message, argument);
		}

		public void Fatal(object value)
		{
			this.logger.Fatal(value);
		}

		public void Fatal(string message)
		{
			this.logger.Fatal(message);
		}

		public void Fatal(string message, params object[] args)
		{
			this.logger.Fatal(message, args);
		}

		public void Fatal(string message, bool argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, byte argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, char argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, decimal argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, double argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, Exception exception)
		{
			this.logger.Fatal(message, exception);
		}

		public void Fatal(string message, int argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, long argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, object arg1, object arg2)
		{
			this.logger.Fatal(message, arg1, arg2);
		}

		public void Fatal(string message, object arg1, object arg2, object arg3)
		{
			this.logger.Fatal(message, arg1, arg2, arg3);
		}

		public void Fatal(string message, object argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, sbyte argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, float argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, string argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, uint argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal(string message, ulong argument)
		{
			this.logger.Fatal(message, argument);
		}

		public void Fatal<T>(IFormatProvider formatProvider, T value)
		{
			this.logger.Fatal<T>(formatProvider, value);
		}

		public void Fatal<T>(T value)
		{
			this.logger.Fatal<T>(value);
		}

		public void Fatal<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			this.logger.Fatal<TArgument>(formatProvider, message, argument);
		}

		public void Fatal<TArgument>(string message, TArgument argument)
		{
			this.logger.Fatal<TArgument>(message, argument);
		}

		public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Fatal<TArgument1, TArgument2, TArgument3>(formatProvider, message, argument1, argument2, argument3);
		}

		public void Fatal<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Fatal<TArgument1, TArgument2, TArgument3>(message, argument1, argument2, argument3);
		}

		public void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Fatal<TArgument1, TArgument2>(formatProvider, message, argument1, argument2);
		}

		public void Fatal<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Fatal<TArgument1, TArgument2>(message, argument1, argument2);
		}

		public void FatalException(string message, Exception exception)
		{
			this.logger.Fatal(message, exception);
		}

		#endregion

		#region Info

		public void Info(IFormatProvider formatProvider, object value)
		{
			this.logger.Info(formatProvider, value);
		}

		public void Info(IFormatProvider formatProvider, string message, params object[] args)
		{
			this.logger.Info(formatProvider, message, args);
		}

		public void Info(IFormatProvider formatProvider, string message, bool argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, byte argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, char argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, decimal argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, double argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, int argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, long argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, object argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, sbyte argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, float argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, string argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, uint argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(IFormatProvider formatProvider, string message, ulong argument)
		{
			this.logger.Info(formatProvider, message, argument);
		}

		public void Info(object value)
		{
			this.logger.Info(value);
		}

		public void Info(string message)
		{
			this.logger.Info(message);
		}

		public void Info(string message, params object[] args)
		{
			this.logger.Info(message, args);
		}

		public void Info(string message, bool argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, byte argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, char argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, decimal argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, double argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, Exception exception)
		{
			this.logger.Info(message, exception);
		}

		public void Info(string message, int argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, long argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, object arg1, object arg2)
		{
			this.logger.Info(message, arg1, arg2);
		}

		public void Info(string message, object arg1, object arg2, object arg3)
		{
			this.logger.Info(message, arg1, arg2, arg3);
		}

		public void Info(string message, object argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, sbyte argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, float argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, string argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, uint argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info(string message, ulong argument)
		{
			this.logger.Info(message, argument);
		}

		public void Info<T>(IFormatProvider formatProvider, T value)
		{
			this.logger.Info<T>(formatProvider, value);
		}

		public void Info<T>(T value)
		{
			this.logger.Info<T>(value);
		}

		public void Info<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			this.logger.Info<TArgument>(formatProvider, message, argument);
		}

		public void Info<TArgument>(string message, TArgument argument)
		{
			this.logger.Info<TArgument>(message, argument);
		}

		public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Info<TArgument1, TArgument2, TArgument3>(formatProvider, message, argument1, argument2, argument3);
		}

		public void Info<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Info<TArgument1, TArgument2, TArgument3>(message, argument1, argument2, argument3);
		}

		public void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Info<TArgument1, TArgument2>(formatProvider, message, argument1, argument2);
		}

		public void Info<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Info<TArgument1, TArgument2>(message, argument1, argument2);
		}

		public void InfoException(string message, Exception exception)
		{
			this.logger.Info(message, exception);
		}

		#endregion

		#region Trace

		public void Trace(IFormatProvider formatProvider, object value)
		{
			this.logger.Trace(formatProvider, value);
		}

		public void Trace(IFormatProvider formatProvider, string message, params object[] args)
		{
			this.logger.Trace(formatProvider, message, args);
		}

		public void Trace(IFormatProvider formatProvider, string message, bool argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, byte argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, char argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, decimal argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, double argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, int argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, long argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, object argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, sbyte argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, float argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, string argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, uint argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(IFormatProvider formatProvider, string message, ulong argument)
		{
			this.logger.Trace(formatProvider, message, argument);
		}

		public void Trace(object value)
		{
			this.logger.Trace(value);
		}

		public void Trace(string message)
		{
			this.logger.Trace(message);
		}

		public void Trace(string message, params object[] args)
		{
			this.logger.Trace(message, args);
		}

		public void Trace(string message, bool argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, byte argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, char argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, decimal argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, double argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, Exception exception)
		{
			this.logger.Trace(message, exception);
		}

		public void Trace(string message, int argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, long argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, object arg1, object arg2)
		{
			this.logger.Trace(message, arg1, arg2);
		}

		public void Trace(string message, object arg1, object arg2, object arg3)
		{
			this.logger.Trace(message, arg1, arg2, arg3);
		}

		public void Trace(string message, object argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, sbyte argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, float argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, string argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, uint argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace(string message, ulong argument)
		{
			this.logger.Trace(message, argument);
		}

		public void Trace<T>(IFormatProvider formatProvider, T value)
		{
			this.logger.Trace<T>(formatProvider, value);
		}

		public void Trace<T>(T value)
		{
			this.logger.Trace<T>(value);
		}

		public void Trace<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			this.logger.Trace<TArgument>(formatProvider, message, argument);
		}

		public void Trace<TArgument>(string message, TArgument argument)
		{
			this.logger.Trace<TArgument>(message, argument);
		}

		public void Trace<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Trace<TArgument1, TArgument2, TArgument3>(formatProvider, message, argument1, argument2, argument3);
		}

		public void Trace<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Trace<TArgument1, TArgument2, TArgument3>(message, argument1, argument2, argument3);
		}

		public void Trace<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Trace<TArgument1, TArgument2>(formatProvider, message, argument1, argument2);
		}

		public void Trace<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Trace<TArgument1, TArgument2>(message, argument1, argument2);
		}

		public void TraceException(string message, Exception exception)
		{
			this.logger.Trace(message, exception);
		}

		#endregion

		#region Warn

		public void Warn(IFormatProvider formatProvider, object value)
		{
			this.logger.Warn(formatProvider, value);
		}

		public void Warn(IFormatProvider formatProvider, string message, params object[] args)
		{
			this.logger.Warn(formatProvider, message, args);
		}

		public void Warn(IFormatProvider formatProvider, string message, bool argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, byte argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, char argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, decimal argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, double argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, int argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, long argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, object argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, sbyte argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, float argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, string argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, uint argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(IFormatProvider formatProvider, string message, ulong argument)
		{
			this.logger.Warn(formatProvider, message, argument);
		}

		public void Warn(object value)
		{
			this.logger.Warn(value);
		}

		public void Warn(string message)
		{
			this.logger.Warn(message);
		}

		public void Warn(string message, params object[] args)
		{
			this.logger.Warn(message, args);
		}

		public void Warn(string message, bool argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, byte argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, char argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, decimal argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, double argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, Exception exception)
		{
			this.logger.Warn(message, exception);
		}

		public void Warn(string message, int argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, long argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, object arg1, object arg2)
		{
			this.logger.Warn(message, arg1, arg2);
		}

		public void Warn(string message, object arg1, object arg2, object arg3)
		{
			this.logger.Warn(message, arg1, arg2, arg3);
		}

		public void Warn(string message, object argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, sbyte argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, float argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, string argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, uint argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn(string message, ulong argument)
		{
			this.logger.Warn(message, argument);
		}

		public void Warn<T>(IFormatProvider formatProvider, T value)
		{
			this.logger.Warn<T>(formatProvider, value);
		}

		public void Warn<T>(T value)
		{
			this.logger.Warn<T>(value);
		}

		public void Warn<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			this.logger.Warn<TArgument>(formatProvider, message, argument);
		}

		public void Warn<TArgument>(string message, TArgument argument)
		{
			this.logger.Warn<TArgument>(message, argument);
		}

		public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Warn<TArgument1, TArgument2, TArgument3>(formatProvider, message, argument1, argument2, argument3);
		}

		public void Warn<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			this.logger.Warn<TArgument1, TArgument2, TArgument3>(message, argument1, argument2, argument3);
		}

		public void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Warn<TArgument1, TArgument2>(formatProvider, message, argument1, argument2);
		}

		public void Warn<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
		{
			this.logger.Warn<TArgument1, TArgument2>(message, argument1, argument2);
		}

		public void WarnException(string message, Exception exception)
		{
			this.logger.Warn(message, exception);
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
				case "Debug":
					AddDebugRule(config, ruleElement);
					break;
				case "Error":
					AddErrorRule(config, ruleElement);
					break;
				case "Fatal":
					AddFatalRule(config, ruleElement);
					break;
				case "Info":
					AddInfoRule(config, ruleElement);
					break;
				case "Off":
					AddOffRule(config, ruleElement);
					break;
				case "Trace":
					AddTraceRule(config, ruleElement);
					break;
				case "Warn":
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
				case "console":
					AddConsoleTarget(config, targetElement);
					break;

				case "file":
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