using Ritter.Infra.Crosscutting;
using System.ComponentModel;
using System.Reflection;

namespace System
{
    public static class EnumExtensions
    {
        public static TAttribute GetAttributeFromEnumType<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            Type type = value.GetType();
            MemberInfo[] members = type.GetMember(value.ToString());
            TAttribute attribute = members[0].GetCustomAttribute<TAttribute>(false);

            return attribute;
        }

        public static string GetDescription(this Enum enumValue)
            => enumValue.GetDescription(enumValue.ToString());

        public static string GetDescription(this Enum enumValue, string defaultValue)
        {
            var attribute = enumValue.GetAttributeFromEnumType<DescriptionAttribute>();
            return attribute?.Description ?? defaultValue;
        }

        public static string GetDisplayName(this Enum enumValue)
            => enumValue.GetDisplayName(enumValue.ToString());

        public static string GetDisplayName(this Enum enumValue, string defaultValue)
        {
            var attribute = enumValue.GetAttributeFromEnumType<DisplayNameAttribute>();
            return attribute?.DisplayName ?? defaultValue;
        }

        public static object GetAmbientValue(this Enum enumValue)
            => enumValue.GetAmbientValue(default);

        public static object GetAmbientValue(this Enum enumValue, object defaultValue)
        {
            var attribute = enumValue.GetAttributeFromEnumType<AmbientValueAttribute>();
            return attribute?.Value ?? defaultValue;
        }

        public static TType GetAmbientValue<TType>(this Enum enumValue)
        {
            object value = enumValue.GetAmbientValue();
            Ensure.That<InvalidCastException>(value.Is<TType>(), $"The value must be an '{typeof(TType).Name}' type");

            return value.ConvertTo<TType>();
        }
    }
}
