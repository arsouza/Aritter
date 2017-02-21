using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Reflection;

namespace Aritter.Infra.Crosscutting.Extensions
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
            var padding = new StringBuilder();

            for (int i = 0; i < totalWidth; i++)
            {
                padding.Append(paddingString);
            }

            padding.Append(text);

            return padding.ToString();
        }

        public static string PadRight(this string text, int totalWidth, string paddingString)
        {
            var padding = new StringBuilder();

            padding.Append(text);

            for (int i = 0; i < totalWidth; i++)
            {
                padding.Append(paddingString);
            }

            return padding.ToString();
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
            var typeInfo = typeof(TEnum).GetTypeInfo();

            Check.Against<InvalidOperationException>(!typeInfo.IsEnum, "O tipo informado n�o � uma enumera��o.");

            TEnum enumValue;
            Enum.TryParse(value, out enumValue);

            return enumValue;
        }

        #endregion Methods
    }
}