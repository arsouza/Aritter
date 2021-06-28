using System;
using System.Globalization;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Decimal
    {
        public static Option<decimal> Parse(string s)
        {
            if (!decimal.TryParse(s, out decimal result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }

        public static Option<decimal> Parse(NumberStyles styles, IFormatProvider format, string s)
        {
            if (!decimal.TryParse(s, styles, format, out decimal result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }
    }
}
