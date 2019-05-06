using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        public ApiResult(ModelStateDictionary modelState) : base(modelState)
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

        public ApiResult(ModelStateDictionary modelState) : this(GetModelStateErrors(modelState)) { }

        public ApiResult(Exception ex) : this(ex.Message) { }

        protected ApiResult(bool success)
        {
            Success = success;
        }

        private static ICollection<string> GetModelStateErrors(ModelStateDictionary modelState)
        {
            return modelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
        }
    }
}
