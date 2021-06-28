using System;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Function
    {
        public static Func<TResult> Map<TInput, TResult>(this Func<TInput> that, Func<TInput, TResult> g)
        {
            return () => g(that());
        }

        public static Func<TResult> Bind<TInput, TResult>(this Func<TInput> that, Func<TInput, Func<TResult>> g)
        {
            return () => g(that())();
        }
    }
}
