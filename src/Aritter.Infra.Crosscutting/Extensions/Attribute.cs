using System;
using System.Reflection;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        #region Methods

        public static T GetAttributeFromEnumType<T>(this Type type, Enum value) where T : Attribute
        {
            var field = type.GetTypeInfo().GetField(value.ToString());
            return (T)type.GetTypeInfo().GetCustomAttribute(typeof(T));
        }

        #endregion Methods
    }
}
