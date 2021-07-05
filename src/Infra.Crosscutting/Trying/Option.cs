using System;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Option
    {
        public static Option<T> Of<T>(T value)
        {
            return new Option<T>(value, value != null);
        }

        public static Option<TResult> Apply<T, TResult>(this Option<Func<T, TResult>> @this, Option<T> arg)
        {
            return @this.Bind((Func<T, TResult> f) => arg.Map(f));
        }

        public static Option<Func<TB, TResult>> Apply<TA, TB, TResult>(this Option<Func<TA, TB, TResult>> @this, Option<TA> arg)
        {
            return @this.Map(Helpers.Curry).Apply(arg);
        }

        public static Option<TR> Map<T, TR>(this Option<T> @this, Func<T, TR> mapfunc)
        {
            if (!@this.IsSome)
            {
                return Helpers.None;
            }
            return Helpers.Some(mapfunc(@this.Value));
        }

        public static Option<Func<TB, TResult>> Map<TA, TB, TResult>(this Option<TA> @this, Func<TA, TB, TResult> func)
        {
            return @this.Map(func.Curry());
        }

        public static Option<TR> Bind<T, TR>(this Option<T> @this, Func<T, Option<TR>> bindfunc)
        {
            if (!@this.IsSome)
            {
                return Helpers.None;
            }
            return bindfunc(@this.Value);
        }

        public static T GetOrElse<T>(this Option<T> @this, Func<T> fallback)
        {
            return @this.Match((T value) => value, fallback);
        }

        public static T GetOrElse<T>(this Option<T> @this, T @else)
        {
            return @this.GetOrElse(() => @else);
        }

        public static Option<T> OrElse<T>(this Option<T> @this, Option<T> @else)
        {
            return @this.Match((T _) => @this, () => @else);
        }

        public static Option<T> OrElse<T>(this Option<T> @this, Func<Option<T>> fallback)
        {
            return @this.Match((T _) => @this, fallback);
        }

        public static Option<T> IfNone<T>(this Option<T> @this, Action action)
        {
            if (@this.IsNone)
            {
                action();
            }
            return @this;
        }
    }
}
