using System;
using System.Collections.Generic;

namespace Ritter.Application.Results
{
    public class ApiResult<T> : ApiResult
    {
        public ApiResult() : base(false)
        {
        }

        public ApiResult(T result) : base(true)
        {
            Result = result;
        }

        public ApiResult(ICollection<string> errors) : base(errors)
        {
        }

        public ApiResult(params string[] errors) : base(errors)
        {
        }

        public ApiResult(Exception ex) : base(ex)
        {
        }

        protected ApiResult(bool success)
        {
            Success = success;
        }

        public T Result { get; set; }
    }
}
