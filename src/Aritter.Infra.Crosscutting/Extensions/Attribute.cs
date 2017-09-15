using System;
using System.Reflection;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        public static T GetAttributeFromEnumType<T>(this Enum value)
            where T : Attribute
        {
            Type type = value.GetType();
            MemberInfo[] members = type.GetMember(value.ToString());
            T attribute = members[0].GetCustomAttribute<T>(false);

            return attribute;
        }
    }
}
