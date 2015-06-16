using Aritter.Manager.Infrastructure.Configuration.Elements;
using System.Configuration;

namespace Aritter.Manager.Infrastructure.Configuration.Collections
{
	public class LoggingRuleCollection : ConfigurationElementCollection
	{
		public LoggingRuleElement this[int index]
		{
			get
			{
				return (LoggingRuleElement)BaseGet(index);
			}

			set
			{
				if (this.BaseGet(index) != null)
				{
					this.BaseRemoveAt(index);
				}

				this.BaseAdd(index, value);
			}
		}

		public void Add(LoggingRuleElement target)
		{
			this.BaseAdd(target);
		}

		public void Clear()
		{
			this.BaseClear();
		}

		public void Remove(LoggingRuleElement target)
		{
			this.BaseRemove(target);
		}

		public void RemoveAt(int index)
		{
			this.BaseRemoveAt(index);
		}

		public void Remove(string name)
		{
			this.BaseRemove(name);
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new LoggingRuleElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return (LoggingRuleElement)element;
		}
	}
}
