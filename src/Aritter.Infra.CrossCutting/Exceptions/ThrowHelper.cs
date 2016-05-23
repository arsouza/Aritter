using System;

namespace Aritter.Infras.Crosscutting.Exceptions
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

        public static void ThrowBusinessException(string message)
        {
            ThrowBusinessException(true, message);
        }

        public static void ThrowBusinessException(bool condition, string message)
        {
            if (condition)
            {
                throw new BusinessException(message);
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