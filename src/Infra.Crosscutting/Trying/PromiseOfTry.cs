using System;

namespace Ritter.Infra.Crosscutting.Trying
{
    public delegate Try<Exception, TResult> PromiseOfTry<TResult>();
    public static class PromiseOfTry
    {
        public static Try<Exception, TResult> Run<TResult>(this PromiseOfTry<TResult> promise)
        {
            try
            {
                return promise();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static PromiseOfTry<TResult> Map<TInput, TResult>(this PromiseOfTry<TInput> promise, Func<TInput, TResult> map)
        {
            return () => promise.Run().Match((Exception exception) => exception, (Func<TInput, Try<Exception, TResult>>)((TInput r) => map(r)));
        }

        public static PromiseOfTry<TResult> Bind<TInput, TResult>(this PromiseOfTry<TInput> promise, Func<TInput, PromiseOfTry<TResult>> f)
        {
            return () => promise.Run().Match((Exception ex) => ex, (TInput t) => f(t).Run());
        }
    }
}
