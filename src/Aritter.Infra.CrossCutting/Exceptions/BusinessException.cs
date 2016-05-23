using System;

namespace Aritter.Infras.Crosscutting.Exceptions
{
    public class BusinessException : Exception
    {
        private string message = "Default message not implemented";

        public override string Message
        {
            get
            {
                return message ?? base.Message;
            }
        }

        public BusinessException()
            : base()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
            this.message = message;
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.message = message;
        }
    }
}
