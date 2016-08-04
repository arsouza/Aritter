using System;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Exceptions
{
    public class ApplicationErrorException : Exception
    {
        #region Constructor

        public ApplicationErrorException(params string[] errors)
            : base("Default_Message")
        {
            foreach (var error in errors)
            {
                ApplicationErrors.Add(error);
            }
        }

        public ApplicationErrorException(Exception ex)
           : base("Default_Message", ex)
        {
            ApplicationErrors.Add(ex.ToString());
        }

        #endregion

        #region Properties

        public ICollection<string> ApplicationErrors { get; } = new List<string>();

        #endregion
    }
}