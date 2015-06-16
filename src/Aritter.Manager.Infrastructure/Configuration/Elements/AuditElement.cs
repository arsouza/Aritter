using System.Configuration;

namespace Aritter.Manager.Infrastructure.Configuration.Elements
{
	public class AuditElement : ConfigurationElement
	{
		#region Properties

		[ConfigurationProperty("enabled", DefaultValue = false, IsRequired = false)]
		public bool Enabled
		{
			get { return (bool)this["enabled"]; }
			set { this["enabled"] = value; }
		}

		#endregion Properties
	}
}