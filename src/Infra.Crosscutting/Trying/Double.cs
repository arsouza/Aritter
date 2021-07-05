using System;
using System.Globalization;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Double
    {
        public static Option<double> Parse(string s)
        {
            if (!double.TryParse(s, out double result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }

        public static Option<double> Parse(NumberStyles styles, IFormatProvider format, string s)
        {
            if (!double.TryParse(s, styles, format, out double result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }
    }
}
