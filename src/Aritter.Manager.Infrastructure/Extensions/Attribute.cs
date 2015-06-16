using System;

namespace Aritter.Manager.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static T GetAttributeFromEnumType<T>(this Type type, Enum value) where T : Attribute
		{
			var field = type.GetField(value.ToString());
			return (T)Attribute.GetCustomAttribute(field, typeof(T));
		}

		#endregion Methods
	}
}