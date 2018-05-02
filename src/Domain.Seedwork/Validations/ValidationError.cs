using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Extensions;
using System;

namespace Ritter.Domain.Validations
{
    public sealed class ValidationError : IEquatable<ValidationError>
    {
        public string Property { get; private set; }
        public string Message { get; private set; }

        internal ValidationError(string message)
        {
            Ensure.Argument.NotNullOrEmpty(message, nameof(message));
            Message = message;
        }

        internal ValidationError(string property, string message)
            : this(message)
        {
            Property = property;
        }

        public override bool Equals(object obj)
        {
            if (!obj.Is<ValidationError>())
                return false;

            return Equals((ValidationError)obj);
        }

        public bool Equals(ValidationError other) => Equals(other.Message, Message);

        public override int GetHashCode()
        {
            unchecked
            {
                return (Message.GetHashCode() * 397);
            }
        }

        public static bool operator ==(ValidationError left, ValidationError right) => left.Equals(right);

        public static bool operator !=(ValidationError left, ValidationError right) => !left.Equals(right);
    }
}
