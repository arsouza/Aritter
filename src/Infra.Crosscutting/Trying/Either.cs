using System;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class Either
    {
        public static Either<TLeft, TResult> Map<TLeft, TRight, TResult>(this Either<TLeft, TRight> @this, Func<TRight, TResult> func)
        {
            if (!@this.IsRight)
            {
                return @this.Left;
            }
            return func(@this.Right);
        }

        public static Either<TLeft, TResult> Bind<TLeft, TRight, TResult>(this Either<TLeft, TRight> @this, Func<TRight, Either<TLeft, TResult>> func)
        {
            if (!@this.IsRight)
            {
                return @this.Left;
            }
            return func(@this.Right);
        }
    }
}
