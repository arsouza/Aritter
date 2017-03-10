using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aritter.Infra.Crosscutting.Exceptions
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

        public static void InheritsFrom<TBase>(object instance, string message)
        {
            InheritsFrom<TBase>(instance.GetType(), message);
        }

        public static void InheritsFrom<TBase>(Type type, string message)
        {
            if (type.GetTypeInfo().BaseType != typeof(TBase))
                throw new InvalidOperationException(message);
        }

        public static void Implements<TInterface>(object instance, string message)
        {
            Implements<TInterface>(instance.GetType(), message);
        }

        public static void Implements<TInterface>(Type type, string message)
        {
            if (!typeof(TInterface).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void TypeOf<TType>(object instance, string message)
        {
            if (!(instance is TType))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void IsEqual<TException>(object compare, object instance, string message)
            where TException : Exception
        {
            if (compare != instance)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        public static void IsNotNull(object instance, string parameterName)
        {
            if (ReferenceEquals(instance, null))
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void IsNull(object instance, string message)
        {
            if (!ReferenceEquals(instance, null))
            {
                throw new ArgumentException(message);
            }
        }

        public static void IsNotEmpty<T>(IEnumerable<T> value, string parameterName)
        {
            if (!value.Any())
            {
                throw new ArgumentException($"{nameof(parameterName)} is empty");
            }
        }

        public static void IsNotEmpty(string value, string parameterName)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(parameterName);
            }
            else if (value.Trim().Length == 0)
            {
                throw new ArgumentException(parameterName);
            }

            throw new InvalidOperationException($"{nameof(parameterName)} could not be empty");
        }
    }
}
