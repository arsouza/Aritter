using System;

namespace Ritter.Infra.Crosscutting.Trying
{
    public struct Either<TLeft, TRight>
    {
        internal TLeft Left { get; }

        internal TRight Right { get; }

        public Option<TLeft> OptionalLeft
        {
            get
            {
                if (!IsLeft)
                {
                    return Helpers.None;
                }
                return Helpers.Some(Left);
            }
        }

        public Option<TRight> OptionalRight
        {
            get
            {
                if (!IsRight)
                {
                    return Helpers.None;
                }
                return Helpers.Some(Right);
            }
        }

        public bool IsLeft { get; }

        public bool IsRight => !IsLeft;

        private Either(TLeft left)
        {
            IsLeft = true;
            Left = left;
            Right = default(TRight);
        }

        private Either(TRight right)
        {
            IsLeft = false;
            Right = right;
            Left = default(TLeft);
        }

        public TResult Match<TResult>(Func<TLeft, TResult> left, Func<TRight, TResult> right)
        {
            if (!IsLeft)
            {
                return right(Right);
            }
            return left(Left);
        }

        public static implicit operator Either<TLeft, TRight>(TLeft left) => new Either<TLeft, TRight>(left);

        public static implicit operator Either<TLeft, TRight>(TRight right) => new Either<TLeft, TRight>(right);

        public static Either<TLeft, TRight> Of(TLeft left) => left;

        public static Either<TLeft, TRight> Of(TRight right) => right;
    }
}
