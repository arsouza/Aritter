using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aritter.Manager.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static bool IsNullOrEmpty(this string text)
		{
			return string.IsNullOrEmpty(text);
		}

		public static bool IsValidMailAddress(this string email)
		{
			if (string.IsNullOrEmpty(email))
				return false;

			return Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
		}

		public static string PadLeft(this string text, int totalWidth, string paddingString)
		{
			var padding = string.Empty;

			for (int i = 0; i < totalWidth; i++)
			{
				padding += paddingString;
			}

			return padding + text;
		}

		public static string PadRight(this string text, int totalWidth, string paddingString)
		{
			var padding = string.Empty;

			for (int i = 0; i < totalWidth; i++)
			{
				padding += paddingString;
			}

			return text + padding;
		}

		public static string ToSingleLine(this string text)
		{
			return text.Replace(Environment.NewLine, string.Empty);
		}

		public static string Pluralize(this string value)
		{
			if (value.Last() == 'y')
				return string.Format("{0}ies", value.Remove(value.Length - 1, 1));

			return string.Format("{0}s", value);
		}

		public static TEnum AsEnum<TEnum>(this string value) where TEnum : struct
		{
			var type = typeof(TEnum);

			if (!type.IsEnum)
				throw new InvalidOperationException("O tipo informado não é uma enumeração.");

			TEnum enumValue;
			Enum.TryParse(value, out enumValue);

			return enumValue;
		}

		#endregion Methods
	}
}