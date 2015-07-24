using Aritter.Infrastructure.Configuration.Elements;
using System.Configuration;

namespace Aritter.Infrastructure.Configuration.Sections
{
	public class AritterSection : ConfigurationSection
	{
		[ConfigurationProperty("auditing")]
		public AuditElement AuditSetting
		{
			get { return (AuditElement)this["auditing"]; }
			set { this["auditing"] = value; }
		}

		[ConfigurationProperty("database")]
		public DatabaseElement DatabaseSetting
		{
			get { return (DatabaseElement)this["database"]; }
			set { this["database"] = value; }
		}

		[ConfigurationProperty("logging")]
		public LoggingElement Logging
		{
			get { return (LoggingElement)this["logging"]; }
			set { this["logging"] = value; }
		}

		[ConfigurationProperty("mail")]
		public MailElement Mail
		{
			get { return (MailElement)this["mail"]; }
			set { this["mail"] = value; }
		}
	}
}