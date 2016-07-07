using Aritter.Infra.Configuration.Elements;
using System.Configuration;

namespace Aritter.Infra.Configuration.Collections
{
    public sealed class LoggingRuleCollection : ConfigurationElementCollection
    {
        public LoggingRuleElement this[int index]
        {
            get
            {
                return (LoggingRuleElement)BaseGet(index);
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
        public LoggingRuleElement this[LoggingLevel loggingLevel]
        {
            get
            {
                return (LoggingRuleElement)BaseGet(loggingLevel);
            }

            set
            {
                var element = BaseGet(loggingLevel);

                if (element != null)
                {
                    BaseRemoveAt(BaseIndexOf(element));
                }

                var newElement = (LoggingRuleElement)CreateNewElement(loggingLevel.ToString());
                newElement.MinLevel = loggingLevel;

                BaseAdd(newElement);
            }
        }

        public void Add(LoggingRuleElement target)
        {
            BaseAdd(target);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(LoggingRuleElement target)
        {
            BaseRemove(target);
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
            return new LoggingRuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (LoggingRuleElement)element;
        }
    }
}
