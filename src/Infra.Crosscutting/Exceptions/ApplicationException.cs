using System;
using System.Runtime.Serialization;

namespace Ritter.Infra.Crosscutting.Exceptions
{
    [Serializable]
    public abstract class ApplicationException : Exception
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

        protected ApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public virtual bool IsBusiness() => false;
        public virtual bool IsNotFound() => false;
    }
}
