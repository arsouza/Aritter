using System;
using System.ComponentModel;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        #region Methods

        public static string GetDescription(this Enum value)
        {
            return GetDescription(value, string.Empty);
        }

        public static string GetDescription(this Enum value, string defaultValue)
        {
            var attribute = value.GetAttributeFromEnumType<DescriptionAttribute>();

            return attribute == null
                ? defaultValue
                : attribute.Description;
        }

        #endregion Methods
    }
}