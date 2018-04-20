using System;
using System.ComponentModel;

namespace Ritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue.GetDescription(enumValue.ToString());
        }

        public static string GetDescription(this Enum enumValue, string defaultValue)
        {
            var attribute = enumValue.GetAttributeFromEnumType<DescriptionAttribute>();
            return attribute?.Description ?? defaultValue;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetDisplayName(enumValue.ToString());
        }

        public static string GetDisplayName(this Enum enumValue, string defaultValue)
        {
            var attribute = enumValue.GetAttributeFromEnumType<DisplayNameAttribute>();
            return attribute?.DisplayName ?? defaultValue;
        }

        public static object GetAmbientValue(this Enum enumValue)
        {
            return enumValue.GetAmbientValue(null);
        }

        public static object GetAmbientValue(this Enum enumValue, object defaultValue)
        {
            var attribute = enumValue.GetAttributeFromEnumType<AmbientValueAttribute>();
            return attribute?.Value ?? defaultValue;
        }

        public static TType GetAmbientValue<TType>(this Enum enumValue)
        {
            object value = enumValue.GetAmbientValue();
            return value.ConvertTo<TType>();
        }
    }
}
