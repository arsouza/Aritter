using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ritter.Infra.Crosscutting
{
    [DebuggerStepThrough]
    public static class Ensure
    {
        public static void That(bool condition, string message = "") => That<Exception>(condition, message);

        public static void That<TException>(bool condition, string message = "")
            where TException : Exception
        {
            if (!condition)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void Not<TException>(bool condition, string message = "")
            where TException : Exception
            => That<TException>(!condition, message);

        public static void Not(bool condition, string message = "") => Not<Exception>(condition, message);

        public static void NotNull(object value, string message = "") => That<NullReferenceException>(!value.IsNull(), message);

        public static void NotNullOrEmpty(string value, string message = "String cannot be null or empty")
            => That(!value.IsNullOrEmpty(), message);

        public static void Equal<T>(T left, T right, string message = "Values must be equal")
            => That(left != null && right != null && left.Equals(right), message);

        public static void NotEqual<T>(T left, T right, string message = "Values must not be equal")
            => That(left != null && right != null && !left.Equals(right), message);

        public static void Items<T>(IEnumerable<T> collection, Func<T, bool> predicate, string message = "")
            => That(!collection.IsNull() && !collection.Any(x => !predicate(x)), message);

        [DebuggerStepThrough]
        public static class Argument
        {
            public static void Is(bool condition, string message = "") => That<ArgumentException>(condition, message);

            public static void IsNot(bool condition, string message = "") => Is(!condition, message);

            public static void NotNull(object value) => NotNull(value, null, null);

            public static void NotNull(object value, string paramName) => NotNull(value, paramName, null);

            public static void NotNull(object value, string paramName, string message)
            {
                if (value.IsNull())
                    throw new ArgumentNullException(paramName, message ?? "Object value cannot be null");
            }

            public static void NotNullOrEmpty(string value) => NotNullOrEmpty(value, null, null);

            public static void NotNullOrEmpty(string value, string paramName) => NotNullOrEmpty(value, paramName, null);

            public static void NotNullOrEmpty(string value, string paramName, string message)
            {
                if (value.IsNull())
                    throw new ArgumentNullException(paramName, message ?? "String value cannot be null");

                if (string.Empty.Equals(value))
                    throw new ArgumentException(message ?? "String value cannot be empty", paramName);
            }
        }
    }
}
