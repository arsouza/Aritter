using System;

namespace Ritter.Infra.Crosscutting.Trying
{
    public struct Option<T>
    {
        public static readonly Option<T> None;

        internal T Value { get; }

        public bool IsSome { get; }

        public bool IsNone => !IsSome;

        internal Option(T value, bool isSome)
        {
            Value = value;
            IsSome = isSome;
        }

        public T GetValue() => Value;

        public TR Match<TR>(Func<T, TR> some, Func<TR> none)
        {
            if (!IsSome)
            {
                return none();
            }
            return some(Value);
        }

        public static implicit operator Option<T>(T value) => Helpers.Some(value);

        public static implicit operator Option<T>(NoneType _) => None;
    }
}
