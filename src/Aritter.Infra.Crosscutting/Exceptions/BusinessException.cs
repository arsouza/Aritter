using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Exceptions
{
    public class BusinessException : Exception
    {
        private const string defaultMessage = "One or more errors occurs. Check internal errors.";

        public ICollection<string> Errors { get; private set; } = new List<string>();

        public BusinessException()
            : this(defaultMessage)
        {
        }

        public BusinessException(IEnumerable<string> errors)
            : this(defaultMessage, errors)
        {
        }

        public BusinessException(string message, params string[] errors)
            : this(message, errors.AsEnumerable())
        {
        }

        public BusinessException(string message, IEnumerable<string> errors)
            : this(message, null, errors)
        {
        }

        public BusinessException(Exception exception, params string[] errors)
            : this(exception, errors.AsEnumerable())
        {
        }

        public BusinessException(Exception exception, IEnumerable<string> errors)
            : this(defaultMessage, exception, errors)
        {
        }

        private BusinessException(string message, Exception exception, IEnumerable<string> errors)
            : base(message, exception)
        {
            Errors = new List<string>(errors);
        }
    }
}
