using System;
using System.Collections.Generic;
using System.Reflection;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        #region Methods

        public static IDictionary<string, object> ToDictionary(this object source)
        {
            var res = new Dictionary<string, object>();

            if (source != null)
            {
                var properties = source.GetType().GetTypeInfo().DeclaredProperties;

                foreach (var property in properties)
                {
                    var val = property.GetValue(source);
                    res.Add(property.Name, val ?? new object());
                }
            }

            return res;
        }

        public static IDictionary<string, TValue> ToDictionary<TValue>(this object source)
        {
            var res = new Dictionary<string, TValue>();

            if (source != null)
            {
                var properties = source.GetType().GetTypeInfo().DeclaredProperties;

                foreach (var property in properties)
                {
                    var value = default(TValue);

                    try
                    {
                        value = (TValue)Convert.ChangeType(property.GetValue(source), typeof(TValue));
                    }
                    catch (Exception)
                    {
                    }

                    res.Add(property.Name, value);
                }
            }

            return res;
        }

        #endregion Methods
    }
}