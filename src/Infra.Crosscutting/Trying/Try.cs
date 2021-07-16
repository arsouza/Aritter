using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Try
    {
        public static Try<IEnumerable<TFailure>, Func<TA, Try<IEnumerable<TFailure>, TSuccess>>> Of<TA, TFailure, TSuccess>(Func<TA, Try<IEnumerable<TFailure>, TSuccess>> func) => func;

        public static Try<IEnumerable<TFailure>, Func<TA, TB, Try<IEnumerable<TFailure>, TSuccess>>> Of<TA, TB, TFailure, TSuccess>(Func<TA, TB, Try<IEnumerable<TFailure>, TSuccess>> func) => func;

        public static Try<TFailure, TSuccess> Lift<TFailure, TSuccess>(this Try<TFailure, Try<TFailure, TSuccess>> @try) => @try.Match((TFailure f) => f, (Try<TFailure, TSuccess> s) => s);

        public static Try<TFailure, Func<TB, TResult>> Apply<TFailure, TA, TB, TResult>(this Try<TFailure, Func<TA, TB, TResult>> func, Try<TFailure, TA> arg) => arg.Match((TFailure e) => e, (TA a) => func.Match((TFailure e2) => e2, (Func<TA, TB, TResult> f) => Try<TFailure, Func<TB, TResult>>.Of((TB b) => f(a, b))));

        public static Try<TFailure, TResult> Apply<TFailure, TA, TResult>(this Try<TFailure, Func<TA, TResult>> func, Try<TFailure, TA> arg) => arg.Match((TFailure e) => e, (TA a) => func.Match((TFailure e2) => e2, (Func<TA, TResult> f) => Try<TFailure, TResult>.Of(f(a))));

        public static Try<IEnumerable<TFailure>, Func<TB, TResult>> Apply<TFailure, TA, TB, TResult>(this Try<IEnumerable<TFailure>, Func<TA, TB, TResult>> func, Try<TFailure, TA> arg) => arg.Match((TFailure e) => Try<IEnumerable<TFailure>, Func<TB, TResult>>.Of(func.OptionalFailure.GetOrElse(Enumerable.Empty<TFailure>).Concat(new TFailure[1] { e })), (TA a) => func.Match(Try<IEnumerable<TFailure>, Func<TB, TResult>>.Of, (Func<TA, TB, TResult> f) => Try<IEnumerable<TFailure>, Func<TB, TResult>>.Of((TB b) => f(a, b))));

        public static Try<IEnumerable<TFailure>, TResult> Apply<TFailure, TA, TResult>(this Try<IEnumerable<TFailure>, Func<TA, TResult>> func, Try<TFailure, TA> arg) => arg.Match((TFailure e) => Try<IEnumerable<TFailure>, TResult>.Of(func.OptionalFailure.GetOrElse(Enumerable.Empty<TFailure>).Concat(new TFailure[1] { e })), (TA a) => func.Match(Try<IEnumerable<TFailure>, TResult>.Of, (Func<TA, TResult> f) => Try<IEnumerable<TFailure>, TResult>.Of(f(a))));

        public static Try<TFailure, NewTSuccess> Map<TFailure, TSuccess, NewTSuccess>(this Try<TFailure, TSuccess> @try, Func<TSuccess, NewTSuccess> func)
        {
            if (!@try.IsSuccess)
            {
                return Try<TFailure, NewTSuccess>.Of(@try.Failure);
            }
            return func(@try.Success);
        }

        public static Try<TFailure, Func<TB, NewTSuccess>> Map<TFailure, TSuccess, TB, NewTSuccess>(this Try<TFailure, TSuccess> @this, Func<TSuccess, TB, NewTSuccess> func) => @this.Map(func.Curry());

        public static async Task<Try<TFailure, NewTSuccess>> MapAsync<TFailure, TSuccess, NewTSuccess>(this Try<TFailure, TSuccess> @try, Func<TSuccess, Task<NewTSuccess>> func) => (!@try.IsSuccess) ? Try<TFailure, NewTSuccess>.Of(@try.Failure) : await func(@try.Success);

        public static async Task<Try<TFailure, NewTSuccess>> MapAsync<TFailure, TSuccess, NewTSuccess>(this Task<Try<TFailure, TSuccess>> @try, Func<TSuccess, Task<NewTSuccess>> func)
        {
            Try<TFailure, NewTSuccess> result;
            if ((await @try).IsSuccess)
            {
                result = await func((await @try).Success);
            }
            else
            {
                result = Try<TFailure, NewTSuccess>.Of((await @try).Failure);
            }
            return result;
        }

        public static Try<TFailure, NewTSuccess> Bind<TFailure, TSuccess, NewTSuccess>(this Try<TFailure, TSuccess> @try, Func<TSuccess, Try<TFailure, NewTSuccess>> func)
        {
            if (!@try.IsSuccess)
            {
                return Try<TFailure, NewTSuccess>.Of(@try.Failure);
            }

            return func(@try.Success);
        }

        public static Either<TFailure, TSuccess> ToEither<TFailure, TSuccess>(this Try<TFailure, TSuccess> @try) => @try.Match((TFailure f) => f, (Func<TSuccess, Either<TFailure, TSuccess>>)((TSuccess s) => s));

        public static Try<Exception, TSuccess> Run<TSuccess>(this Func<TSuccess> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static Try<TFailure, TSuccess> Run<TFailure, TSuccess>(this Func<TSuccess> func) where TFailure : Exception
        {
            try
            {
                return func();
            }
            catch (TFailure val)
            {
                return val;
            }
        }

        public static async Task<Try<TFailure, TSuccess>> Run<TFailure, TSuccess>(this Func<Task<TSuccess>> func) where TFailure : Exception
        {
            try
            {
                return await func();
            }
            catch (TFailure val)
            {
                return val;
            }
        }

        public static async Task<Try<TFailure, TSuccess>> Run<TFailure, TSuccess>(this ConfiguredTaskAwaitable<TSuccess> func) where TFailure : Exception
        {
            try
            {
                return await func;
            }
            catch (TFailure val)
            {
                return val;
            }
        }

        public static async Task<Try<TFailure, TSuccess>> RunAsync<TFailure, TSuccess>(this Func<Task<TSuccess>> func) where TFailure : Exception
        {
            try
            {
                return await func();
            }
            catch (TFailure val)
            {
                return val;
            }
        }

        public static Try<TFailure, TSuccess> Flatten<TFailure, TSuccess>(this Try<TFailure, Option<TSuccess>> @try, Func<TFailure> ifNone)
        {
            if (@try.IsFailure)
            {
                return @try.Failure;
            }
            if (!@try.Success.IsSome)
            {
                return ifNone();
            }
            return @try.Success.Value;
        }

        public static Try<TFailure, TSuccess> IfNone<TFailure, TSuccess>(this Try<TFailure, Option<TSuccess>> @try, Func<TFailure> ifNone) => @try.Flatten(ifNone);
    }
}
