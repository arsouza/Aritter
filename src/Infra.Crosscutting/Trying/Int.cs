using System;
using System.Globalization;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Int
    {
        public static Option<int> Parse(string s)
        {
            if (!int.TryParse(s, out int result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }

        public static Option<int> Parse(NumberStyles styles, IFormatProvider format, string s)
        {
            if (!int.TryParse(s, styles, format, out int result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }
    }
}
