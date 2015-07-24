using Aritter.Infrastructure.Configuration.Collections;
using System.Configuration;

namespace Aritter.Infrastructure.Configuration.Elements
{
	public class LoggingElement : ConfigurationElement
	{
		#region Properties

		[ConfigurationProperty("targets", IsDefaultCollection = false), ConfigurationCollection(typeof(LoggingTargetCollection), AddItemName = "target")]
		public LoggingTargetCollection Targets
		{
			get
			{
				return (LoggingTargetCollection)base["targets"];
			}
		}

		[ConfigurationProperty("rules", IsDefaultCollection = false), ConfigurationCollection(typeof(LoggingRuleCollection), AddItemName = "rule")]
		public LoggingRuleCollection Rules
		{
			get
			{
				return (LoggingRuleCollection)base["rules"];
			}
		}

		#endregion Properties
	}
}