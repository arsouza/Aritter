using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace System
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            if (!(source is null))
            {
                IEnumerable<PropertyInfo> properties = source.GetType().GetTypeInfo().DeclaredProperties;

                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(source);
                    dictionary.Add(property.Name, value ?? default);
                }
            }

            return dictionary;
        }

        public static IDictionary<string, TValue> ToDictionary<TValue>(this object source)
        {
            Dictionary<string, TValue> dictionary = new Dictionary<string, TValue>();

            if (!(source is null))
            {
                IEnumerable<PropertyInfo> properties = source
                    .GetType()
                    .GetTypeInfo()
                    .DeclaredProperties;

                dictionary = new Dictionary<string, TValue>(
                    properties.Select(
                        p => new KeyValuePair<string, TValue>(
                            p.Name,
                            p.GetValue(source).ConvertTo(default(TValue)))));
            }

            return dictionary;
        }

        public static TType ConvertTo<TType>(this object value)
        {
            return (TType)Convert.ChangeType(value, typeof(TType));
        }

        public static TType ConvertTo<TType>(this object value, TType defaultValue)
        {
            try
            {
                return value.ConvertTo<TType>();
            }
            catch
            {
                return defaultValue;
            }
        }

        public static TAttribute GetAttribute<TAttribute>(this object source)
            where TAttribute : Attribute
        {
            Attribute attr = source.GetType().GetCustomAttribute(typeof(TAttribute), false);
            return attr is null ? null : (TAttribute)attr;
        }

        public static bool IsDefined<TAttribute>(this object source)
            where TAttribute : Attribute
        {
            return source.GetAttribute<TAttribute>() != null;
        }

        public static string SerializeToJsonString<T>(this T obj, bool camelCase = false)
            where T : class
        {
            if (obj == null)
                return string.Empty;

            return JsonConvert.SerializeObject(
                obj,
                Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = camelCase
                        ? new CamelCasePropertyNamesContractResolver()
                        : null
                });
        }
    }
}
