using Aritter.Manager.Infrastructure.Configuration.Elements;
using System.Configuration;

namespace Aritter.Manager.Infrastructure.Configuration.Collections
{
	public class LoggingTargetCollection : ConfigurationElementCollection
	{
		public LoggingTargetElement this[int index]
		{
			get
			{
				return (LoggingTargetElement)BaseGet(index);
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

		public void Add(LoggingTargetElement target)
		{
			this.BaseAdd(target);
		}

		public void Clear()
		{
			this.BaseClear();
		}

		public void Remove(LoggingTargetElement target)
		{
			this.BaseRemove(target.Name);
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
			return new LoggingTargetElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((LoggingTargetElement)element).Name;
		}
	}
}
