using System.Text;
using System.Text.RegularExpressions;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
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
    }
}
