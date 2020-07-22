using System;
using System.Runtime.Serialization;

namespace Ritter.Infra.Crosscutting.Exceptions
{
    [Serializable]
    public sealed class ApplicationException : Exception
    {
        public ApplicationException()
        {
        }

        public ApplicationException(string message)
            : base(message)
        {
        }

        public ApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private ApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
