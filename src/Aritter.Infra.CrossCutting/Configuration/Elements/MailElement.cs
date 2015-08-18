using System.Configuration;

namespace Aritter.Infra.CrossCutting.Configuration.Elements
{
	public class MailElement : ConfigurationElement
	{
		#region Properties

		[ConfigurationProperty("useDefaultCredentials", DefaultValue = false, IsRequired = false)]
		public bool UseDefaultCredentials
		{
			get { return (bool)this["useDefaultCredentials"]; }
			set { this["useDefaultCredentials"] = value; }
		}

		[ConfigurationProperty("enableSsl", DefaultValue = true, IsRequired = false)]
		public bool EnableSsl
		{
			get { return (bool)this["enableSsl"]; }
			set { this["enableSsl"] = value; }
		}

		[ConfigurationProperty("host", DefaultValue = "", IsRequired = true)]
		public string Host
		{
			get { return (string)this["host"]; }
			set { this["host"] = value; }
		}

		[ConfigurationProperty("port", DefaultValue = 0, IsRequired = true)]
		public int Port
		{
			get { return (int)this["port"]; }
			set { this["port"] = value; }
		}

		[ConfigurationProperty("displayName", DefaultValue = "", IsRequired = true)]
		public string DisplayName
		{
			get { return (string)this["displayName"]; }
			set { this["displayName"] = value; }
		}

		[ConfigurationProperty("userName", DefaultValue = "", IsRequired = true)]
		public string UserName
		{
			get { return (string)this["userName"]; }
			set { this["userName"] = value; }
		}

		[ConfigurationProperty("password", DefaultValue = "", IsRequired = true)]
		public string Password
		{
			get { return (string)this["password"]; }
			set { this["password"] = value; }
		}

		#endregion Properties
	}
}