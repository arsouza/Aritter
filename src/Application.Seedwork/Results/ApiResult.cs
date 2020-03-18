using System;
using System.Collections.Generic;

namespace Ritter.Application.Results
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public ICollection<string> Errors { get; set; } = new HashSet<string>();

        public ApiResult() : this(true) { }

        public ApiResult(ICollection<string> errors) : this(false)
        {
            Errors = errors ?? new HashSet<string>();
        }

        public ApiResult(params string[] errors) : this(false)
        {
            Errors = errors ?? new string[] { };
        }

        public ApiResult(Exception ex) : this(ex.Message) { }

        protected ApiResult(bool success)
        {
            Success = success;
        }
    }
}
