using Aritter.Manager.Infrastructure.Configuration.Elements;
using Aritter.Manager.Infrastructure.Configuration.Sections;
using System;
using System.Configuration;
using System.Globalization;
using System.Security.Principal;
using System.Threading;

namespace Aritter.Manager.Infrastructure.Configuration
{
	public class ApplicationSettings
	{
		#region Properties

		public static IIdentity CurrentUser
		{
			get
			{
				return Thread.CurrentPrincipal.Identity;
			}
		}

		public static AuditElement Auditing
		{
			get
			{
				var configuration = GetConfiguration();
				return configuration.AuditSetting;
			}
		}

		public static CultureInfo CurrentCulture
		{
			get { return Thread.CurrentThread.CurrentCulture; }
		}

		public static DatabaseElement Database
		{
			get
			{
				var configuration = GetConfiguration();
				return configuration.DatabaseSetting;
			}
		}

		public static LoggingElement Logging
		{
			get
			{
				var configuration = GetConfiguration();
				return configuration.Logging;
			}
		}

		public static MailElement Mail
		{
			get
			{
				var configuration = GetConfiguration();
				return configuration.Mail;
			}
		}

		#endregion Properties

		#region Methods

		public static string ConnectionString(string name)
		{
			return ConfigurationManager.ConnectionStrings[name].ConnectionString;
		}

		private static T AppSetting<T>(string key) where T : struct
		{
			var setting = GetSettingValue(key, typeof(T));

			return
				setting == null
					? default(T)
					: (T)setting;
		}

		private static string AppSetting(string key)
		{
			var setting = GetSettingValue(key, typeof(string));

			if (setting == null)
				return null;

			return Convert.ToString(setting);
		}

		private static object GetSettingValue(string key, Type type)
		{
			try
			{
				var value = ConfigurationManager.AppSettings[key];

				if (string.IsNullOrEmpty(value))
					return null;
				return Convert.ChangeType(value, type);
			}
			catch
			{
				return null;
			}
		}

		private static ManagerSection GetConfiguration()
		{
			return (ManagerSection)ConfigurationManager.GetSection("managerSettings");
		}

		#endregion Methods
	}
}