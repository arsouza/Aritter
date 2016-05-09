using Aritter.Infra.Configuration.Elements;
using Aritter.Infra.Configuration.Sections;
using System;
using System.Configuration;
using System.Globalization;
using System.Security.Principal;
using System.Threading;

namespace Aritter.Infra.Configuration
{
    public static class ApplicationSettings
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

        public static T AppSetting<T>(string key) where T : struct
        {
            var setting = GetSettingValue(key, typeof(T));

            return
                setting == null
                    ? default(T)
                    : (T)setting;
        }

        public static string AppSetting(string key)
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

        private static AritterSection GetConfiguration()
        {
            return (AritterSection)ConfigurationManager.GetSection("aritter");
        }

        #endregion Methods
    }
}