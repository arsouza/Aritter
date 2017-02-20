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
                ThrowHelper.Throws<TException>(message);
            }
        }

        public static void Against<TException>(Func<bool> assertion, string message) where TException : Exception
        {
            if (assertion())
            {
                ThrowHelper.Throws<TException>(message);
            }
        }
        public static void Against<TException>(bool assertion, params string[] args) where TException : Exception
        {
            if (assertion)
            {
                ThrowHelper.Throws<TException>(args);
            }
        }

        public static void Against<TException>(Func<bool> assertion, params string[] args) where TException : Exception
        {
            if (assertion())
            {
                ThrowHelper.Throws<TException>(args);
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
                ThrowHelper.ThrowInvalidOperationException(message);
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
                ThrowHelper.ThrowInvalidOperationException(message);
            }
        }

        public static void TypeOf<TType>(object instance, string message)
        {
            if (!(instance is TType))
            {
                ThrowHelper.ThrowInvalidOperationException(message);
            }
        }

        public static void IsEqual<TException>(object compare, object instance, string message)
            where TException : Exception
        {
            if (compare != instance)
            {
                ThrowHelper.Throws<TException>(message);
            }
        }

        public static void IsNotNull(object instance, string parameterName)
        {
            if (ReferenceEquals(instance, null))
            {
                ThrowHelper.ThrowArgumentNullException(parameterName);
            }
        }

        public static void IsNull(object instance, string message)
        {
            if (!ReferenceEquals(instance, null))
            {
                ThrowHelper.ThrowArgumentException(message);
            }
        }

        public static void IsNotEmpty<T>(IEnumerable<T> value, string parameterName)
        {
            if (!value.Any())
            {
                ThrowHelper.ThrowArgumentException(parameterName);
            }
        }

        public static void IsNotEmpty(string value, string parameterName)
        {
            Exception e = null;

            if (ReferenceEquals(value, null))
            {
                e = new ArgumentNullException(parameterName);
            }
            else if (value.Trim().Length == 0)
            {
                e = new ArgumentException(parameterName);
            }

            if (e != null)
            {
                IsNotEmpty(parameterName, parameterName);
                ThrowHelper.Throws(e);
            }
        }
    }
}
