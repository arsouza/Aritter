using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            var dictionary = new Dictionary<string, object>();

            if (!(source is null))
            {
                var properties = source.GetType().GetTypeInfo().DeclaredProperties;

                foreach (var property in properties)
                {
                    var value = property.GetValue(source);
                    dictionary.Add(property.Name, value ?? default(object));
                }
            }

            return dictionary;
        }

        public static IDictionary<string, TValue> ToDictionary<TValue>(this object source)
        {
            var dictionary = new Dictionary<string, TValue>();

            if (!(source is null))
            {
                var properties = source.GetType().GetTypeInfo().DeclaredProperties;

                foreach (var property in properties)
                {
                    TValue value;

                    try
                    {
                        value = (TValue)Convert.ChangeType(property.GetValue(source), typeof(TValue));
                    }
                    catch
                    {
                        value = default(TValue);
                    }

                    dictionary.Add(property.Name, value);
                }
            }

            return dictionary;
        }
    }
}
