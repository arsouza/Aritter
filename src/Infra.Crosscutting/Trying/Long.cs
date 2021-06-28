using System;
using System.Globalization;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Long
    {
        public static Option<long> Parse(string s)
        {
            if (!long.TryParse(s, out long result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }

        public static Option<long> Parse(NumberStyles styles, IFormatProvider format, string s)
        {
            if (!long.TryParse(s, styles, format, out long result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }
    }
}
