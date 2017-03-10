using System;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Exceptions
{
    public static class ThrowHelper
    {
        public static void ThrowsException<TException>(params object[] args) where TException : Exception
        {
            throw (TException)Activator.CreateInstance(typeof(TException), args);
        }

        public static void ThrowsInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

        public static void ThrowsArgumentNullException(string parameterName)
        {
            throw new ArgumentNullException(parameterName);
        }

        public static void ThrowsArgumentNullException(string parameterName, string message)
        {
            throw new ArgumentNullException(parameterName, message);
        }

        public static void ThrowsArgumentException(string message)
        {
            throw new ArgumentException(message);
        }

        public static void ThrowsArgumentException(string message, string parameterName)
        {
            throw new ArgumentException(message, parameterName);
        }

        public static void ThrowBusinessException(IEnumerable<string> errors)
        {
            throw new BusinessException(errors);
        }

        public static void ThrowBusinessException(params string[] errors)
        {
            throw new BusinessException(errors);
        }
    }
}
