using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace System
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            var dictionary = new Dictionary<string, object>();

            if (!source.IsNull())
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
            var dictionary = new Dictionary<string, TValue>();

            if (!source.IsNull())
            {
                IEnumerable<PropertyInfo> properties = source.GetType().GetTypeInfo().DeclaredProperties;

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

        public static bool Is<TType>(this object obj)
        {
            return obj is TType;
        }

        public static TType As<TType>(this object obj)
            where TType : class
        {
            return obj as TType;
        }

        public static bool IsNull(this object obj)
        {
            return obj is null;
        }
    }
}
