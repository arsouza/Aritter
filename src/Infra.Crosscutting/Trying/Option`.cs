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

        public T GetValue()
        {
            return Value;
        }

        public TR Match<TR>(Func<T, TR> some, Func<TR> none)
        {
            if (!IsSome)
            {
                return none();
            }
            return some(Value);
        }

        public Unit Match(Action<T> some, Action none)
        {
            return Match(Helpers.ToFunc(some), Helpers.ToFunc(none));
        }

        public static implicit operator Option<T>(T value)
        {
            return Helpers.Some(value);
        }

        public static implicit operator Option<T>(NoneType _)
        {
            return None;
        }

        public static implicit operator Unit(Option<T> _)
        {
            return Helpers.Unit();
        }
    }
}
