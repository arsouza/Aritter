using System;
using System.Globalization;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Float
    {
        public static Option<float> Parse(string s)
        {
            if (!float.TryParse(s, out float result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }

        public static Option<float> Parse(NumberStyles styles, IFormatProvider format, string s)
        {
            if (!float.TryParse(s, styles, format, out float result))
            {
                return Helpers.None;
            }
            return Helpers.Some(result);
        }
    }
}
