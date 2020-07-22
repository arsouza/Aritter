using System;
using System.Runtime.Serialization;

namespace Ritter.Infra.Crosscutting.Exceptions
{
    [Serializable]
    public sealed class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
