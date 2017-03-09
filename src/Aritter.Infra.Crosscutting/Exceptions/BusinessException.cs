using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Exceptions
{
    public class BusinessException : Exception
    {
        #region Fields

        private const string defaultMessage = "One or more errors occurs. Check internal errors.";

        #endregion

        #region Properties

        public ICollection<string> Errors { get; private set; } = new List<string>();

        #endregion

        #region Constructor

        public BusinessException(params string[] errors)
            : this(errors.AsEnumerable())
        {
        }

        public BusinessException(Exception exception, params string[] errors)
            : this(exception, errors.AsEnumerable())
        {
        }

        public BusinessException(IEnumerable<string> errors)
            : this(null, errors)
        {
        }

        public BusinessException(Exception exception, IEnumerable<string> errors)
            : base(defaultMessage, exception)
        {
            Errors = new List<string>(errors);
        }

        public BusinessException(Exception exception)
           : this(exception, exception.ToString())
        {
        }

        #endregion
    }
}