using Aritter.Infra.CrossCutting.Configuration.Elements;
using System.Configuration;

namespace Aritter.Infra.CrossCutting.Configuration.Collections
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
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}

				BaseAdd(index, value);
			}
		}

		public void Add(LoggingTargetElement target)
		{
			BaseAdd(target);
		}

		public void Clear()
		{
			BaseClear();
		}

		public void Remove(LoggingTargetElement target)
		{
			BaseRemove(target.Name);
		}

		public void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}

		public void Remove(string name)
		{
			BaseRemove(name);
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
