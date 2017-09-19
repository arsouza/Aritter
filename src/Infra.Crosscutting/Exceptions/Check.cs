using System;
using System.Collections.Generic;
using System.Linq;

namespace Ritter.Infra.Crosscutting.Exceptions
{
    public static class Check
    {
        public static void Against<TException>(bool assertion, params string[] args) where TException : Exception
        {
            if (assertion)
                throw (TException)Activator.CreateInstance(typeof(TException), args);
        }

        public static void Against<TException>(Func<bool> assertion, params string[] args) where TException : Exception
        {
            if (assertion())
                throw (TException)Activator.CreateInstance(typeof(TException), args);
        }

        public static void IsTypeOf<TType>(object instance, string message)
        {
            if (typeof(TType) != instance.GetType())
                throw new InvalidOperationException(message);
        }

        public static void AreEquals<TException>(object compare, object instance, string message)
            where TException : Exception
        {
            if (!Equals(compare, instance))
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void IsNotNull(object instance, string parameterName)
        {
            if (ReferenceEquals(instance, null))
                throw new ArgumentException(null, parameterName);
        }

        public static void IsNull(object instance, string message)
        {
            if (!ReferenceEquals(instance, null))
                throw new ArgumentNullException(message);
        }

        public static void IsNotEmpty<T>(IEnumerable<T> value, string parameterName)
        {
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(parameterName);

            if (!value.Any())
                throw new ArgumentException(null, parameterName);
        }

        public static void IsNotEmpty(string value, string parameterName)
        {
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(parameterName);

            if (value.Trim().Length == 0)
                throw new ArgumentException(null, parameterName);
        }
    }
}
