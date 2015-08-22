using System.Configuration;

namespace Aritter.Infra.CrossCutting.Configuration
{
	public class LoggingRuleElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsRequired = true, IsKey = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("minlevel", IsRequired = true)]
		public LoggingLevel MinLevel
		{
			get { return (LoggingLevel)this["minlevel"]; }
			set { this["minlevel"] = value; }
		}

		[ConfigurationProperty("writeTo", IsRequired = true)]
		public string WriteTo
		{
			get { return (string)this["writeTo"]; }
			set { this["writeTo"] = value; }
		}
	}
}