using System;
using System.Threading.Tasks;

namespace Ritter.Infra.Crosscutting.Trying
{
    public struct Try<TFailure, TSuccess>
    {
        internal TFailure Failure { get; }

        internal TSuccess Success { get; }

        public bool IsFailure { get; }

        public bool IsSuccess => !IsFailure;

        public Option<TFailure> OptionalFailure
        {
            get
            {
                if (!IsFailure)
                {
                    return Helpers.None;
                }

                return Helpers.Some(Failure);
            }
        }

        public Option<TSuccess> OptionalSuccess
        {
            get
            {
                if (!IsSuccess)
                {
                    return Helpers.None;
                }

                return Helpers.Some(Success);
            }
        }

        public TSuccess GetSuccess() => Success;

        public TFailure GetFailure() => Failure;

        internal Try(TFailure failure)
        {
            IsFailure = true;
            Failure = failure;
            Success = default(TSuccess);
        }

        internal Try(TSuccess success)
        {
            IsFailure = false;
            Failure = default(TFailure);
            Success = success;
        }

        public TResult Match<TResult>(Func<TFailure, TResult> failure, Func<TSuccess, TResult> success)
        {
            if (!IsFailure)
            {
                return success(Success);
            }

            return failure(Failure);
        }

        public Task<TResult> MatchAsync<TResult>(Func<TFailure, Task<TResult>> failure, Func<TSuccess, Task<TResult>> success)
        {
            if (!IsFailure)
            {
                return success(Success);
            }

            return failure(Failure);
        }

        public static implicit operator Try<TFailure, TSuccess>(TFailure failure) => new(failure);

        public static implicit operator Try<TFailure, TSuccess>(TSuccess success) => new(success);

        public static Try<TFailure, TSuccess> Of(TSuccess obj) => obj;

        public static Try<TFailure, TSuccess> Of(TFailure obj) => obj;
    }
}
