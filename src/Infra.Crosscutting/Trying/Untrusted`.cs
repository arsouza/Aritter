using System;

namespace Ritter.Infra.Crosscutting.Trying
{
    public struct Untrusted<T>
    {
        private readonly T _value;

        private Untrusted(T value)
        {
            _value = value;
        }

        public static implicit operator Untrusted<T>(T value)
        {
            return new Untrusted<T>(value);
        }

        public Try<TFailure, TSuccess> Validate<TFailure, TSuccess>(Func<T, bool> validation, Func<T, TFailure> failure, Func<T, TSuccess> success)
        {
            if (!validation(_value))
            {
                return failure(_value);
            }
            return success(_value);
        }

        public void Validate(Func<T, bool> validation, Action<T> failure, Action<T> success)
        {
            if (validation(_value))
            {
                success(_value);
            }
            else
            {
                failure(_value);
            }
        }

        public Option<TSuccess> Validate<TSuccess>(Func<T, bool> validation, Func<T, TSuccess> success)
        {
            if (!validation(_value))
            {
                return Helpers.None;
            }
            return Helpers.Some(success(_value));
        }

        public Option<T> Validate(Func<T, bool> validation)
        {
            if (!validation(_value))
            {
                return Helpers.None;
            }
            return Helpers.Some(_value);
        }

        public Try<TFailure, TSuccess> Validate<TFailure, TSuccess>(Func<T, bool> predicate, Func<T, TFailure> failure, Func<T, Try<TFailure, TSuccess>> success)
        {
            if (!predicate(_value))
            {
                return failure(_value);
            }
            return success(_value);
        }
    }
}
