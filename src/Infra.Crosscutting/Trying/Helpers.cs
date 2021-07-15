using System;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Helpers
    {
        public static readonly NoneType None;

        public static Func<TA, Func<TB, TResult>> Curry<TA, TB, TResult>(this Func<TA, TB, TResult> func) => (TA a) => (TB b) => func(a, b);

        public static Option<T> Some<T>(T value) => Option.Of(value);

        public static PromiseOfTry<T> PromiseOfTry<T>(Func<T> func) => func as PromiseOfTry<T>;
    }
}
