using System;

namespace Aritter.Infra.Crosscutting.Exceptions
{
    internal static class ThrowHelper
    {
        public static void Throws(Exception e)
        {
            throw e;
        }

        public static void Throws<TException>(string message) where TException : Exception
        {
            throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void ThrowInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

        public static void ThrowArgumentNullException(string parameterName)
        {
            throw new ArgumentNullException(parameterName);
        }

        public static void ThrowArgumentException(string message)
        {
            throw new ArgumentException(message);
        }
    }
}
