using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aritter.Infra.Crosscutting.Exceptions
{
    public static class Check
    {
        public static void Against<TException>(bool assertion, string message) where TException : Exception
        {
            if (assertion)
            {
                ThrowHelper.ThrowsException<TException>(message);
            }
        }

        public static void Against<TException>(Func<bool> assertion, string message) where TException : Exception
        {
            if (assertion())
            {
                ThrowHelper.ThrowsException<TException>(message);
            }
        }
        public static void Against<TException>(bool assertion, params string[] args) where TException : Exception
        {
            if (assertion)
            {
                ThrowHelper.ThrowsException<TException>(args);
            }
        }

        public static void Against<TException>(Func<bool> assertion, params string[] args) where TException : Exception
        {
            if (assertion())
            {
                ThrowHelper.ThrowsException<TException>(args);
            }
        }

        public static void InheritsFrom<TBase>(object instance, string message) where TBase : Type
        {
            InheritsFrom<TBase>(instance.GetType(), message);
        }

        public static void InheritsFrom<TBase>(Type type, string message)
        {
            if (type.GetTypeInfo().BaseType != typeof(TBase))
            {
                ThrowHelper.ThrowsInvalidOperationException(message);
            }
        }

        public static void Implements<TInterface>(object instance, string message)
        {
            Implements<TInterface>(instance.GetType(), message);
        }

        public static void Implements<TInterface>(Type type, string message)
        {
            if (!typeof(TInterface).IsAssignableFrom(type))
            {
                ThrowHelper.ThrowsInvalidOperationException(message);
            }
        }

        public static void TypeOf<TType>(object instance, string message)
        {
            if (!(instance is TType))
            {
                ThrowHelper.ThrowsInvalidOperationException(message);
            }
        }

        public static void IsEqual<TException>(object compare, object instance, string message)
            where TException : Exception
        {
            if (compare != instance)
            {
                ThrowHelper.ThrowsException<TException>(message);
            }
        }

        public static void IsNotNull(object instance, string parameterName)
        {
            if (ReferenceEquals(instance, null))
            {
                ThrowHelper.ThrowsArgumentNullException(parameterName);
            }
        }

        public static void IsNull(object instance, string message)
        {
            if (!ReferenceEquals(instance, null))
            {
                ThrowHelper.ThrowsArgumentException(message);
            }
        }

        public static void IsNotEmpty<T>(IEnumerable<T> value, string parameterName)
        {
            if (!value.Any())
            {
                ThrowHelper.ThrowsArgumentException(parameterName);
            }
        }

        public static void IsNotEmpty(string value, string parameterName)
        {
            if (ReferenceEquals(value, null))
            {
               ThrowHelper.ThrowsArgumentNullException(parameterName);
            }
            else if (value.Trim().Length == 0)
            {
                ThrowHelper.ThrowsArgumentException(parameterName);
            }

            ThrowHelper.ThrowsInvalidOperationException($"{nameof(parameterName)} could not be empty");
        }
    }
}
