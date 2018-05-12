using System;
using System.Runtime.Serialization;

namespace Ritter.Infra.Crosscutting.Exceptions
{
    [Serializable]
    public sealed class NotFoundObjectException : Exception
    {
        public NotFoundObjectException()
        {
        }

        public NotFoundObjectException(string message)
            : base(message)
        {
        }

        public NotFoundObjectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private NotFoundObjectException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
