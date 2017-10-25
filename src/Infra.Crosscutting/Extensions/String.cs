using System.Collections.Generic;
using System.Text;

namespace Ritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
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

        public static string Join(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values);
        }

        public static string Join<T>(this IEnumerable<T> values, string separator)
        {
            return string.Join(separator, values);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
