using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Aritter.Infra.CrossCutting.Extensions
{
    public static class ExtensionHelper
    {
        #region Methods

        public static bool IsNull(this object source)
        {
            return source == null;
        }

        public static IDictionary<string, object> ToDictionary(this object source)
        {
            var res = new Dictionary<string, object>();

            if (source != null)
            {
                var props = TypeDescriptor.GetProperties(source);
                for (var i = 0; i < props.Count; i++)
                {
                    var val = props[i].GetValue(source);
                    res.Add(props[i].Name, val ?? new object());
                }
            }

            return res;
        }

        public static IDictionary<string, TValue> ToDictionary<TValue>(this object source)
        {
            var res = new Dictionary<string, TValue>();

            if (source != null)
            {
                var props = TypeDescriptor.GetProperties(source);
                for (var i = 0; i < props.Count; i++)
                {
                    var val = default(TValue);

                    try
                    {
                        val = (TValue)Convert.ChangeType(props[i].GetValue(source), typeof(TValue));
                    }
                    catch (Exception)
                    {
                    }

                    res.Add(props[i].Name, val);
                }
            }

            return res;
        }

        public static T As<T>(this object obj)
        {
            if (obj == null)
                return default(T);

            return (T)Convert.ChangeType(obj, typeof(T));
        }

        #endregion Methods
    }
}