using System;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Exceptions
{
    public static class ThrowHelper
    {
        public static void ThrowArgumentNullException(object value, string valueName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(valueName);
            }
        }
        public static void ThrowArgumentNullException(bool condition, string valueName)
        {
            if (condition)
            {
                throw new ArgumentNullException(valueName);
            }
        }

        public static void ThrowApplicationErrorException(string message)
        {
            ThrowApplicationErrorException(true, message);
        }

        public static void ThrowApplicationErrorException(bool condition, string message)
        {
            ThrowApplicationErrorException(true, new[] { message });
        }

        public static void ThrowApplicationErrorException(bool condition, IEnumerable<string> applicationErrors)
        {
            if (condition)
            {
                throw new ApplicationErrorException(applicationErrors);
            }
        }

        public static void ThrowArgumentException(bool condition, string message)
        {
            if (condition)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowInvalidOperationException(bool condition, string message)
        {
            if (condition)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}