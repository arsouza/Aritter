using System.Configuration;

namespace Aritter.Infra.CrossCutting.Configuration
{
	public class LoggingTargetElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsRequired = true, IsKey = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("type", IsRequired = true)]
		public string Type
		{
			get { return (string)this["type"]; }
			set { this["type"] = value; }
		}

		[ConfigurationProperty("layout", IsRequired = true)]
		public string Layout
		{
			get { return (string)this["layout"]; }
			set { this["layout"] = value; }
		}

		[ConfigurationProperty("fileName", IsRequired = false)]
		public string FileName
		{
			get { return (string)this["fileName"]; }
			set { this["fileName"] = value; }
		}
	}
}
