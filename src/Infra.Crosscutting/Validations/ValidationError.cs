using System;

namespace Ritter.Infra.Crosscutting.Validations
{
    public sealed class ValidationError : IEquatable<ValidationError>
    {
        public string Property { get; private set; }
        public string Message { get; private set; }

        public ValidationError(string message)
        {
            Ensure.Argument.NotNullOrEmpty(message, nameof(message));
            Message = message;
        }

        public ValidationError(string property, string message)
            : this(message)
        {
            Property = property;
        }

        public bool Equals(ValidationError other)
        {
            return Equals(other.Property, Property) && Equals(other.Message, Message);
        }

        public override string ToString()
        {
            if (!Property.IsNullOrEmpty())
            {
                return $"{Property}: {Message}";
            }

            return Message;
        }

        public override bool Equals(object obj)
        {
            if (obj is ValidationError validationError)
            {
                return Equals(validationError);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Message.GetHashCode()) * 397) ^ Property?.GetHashCode() ?? 1;
            }
        }

        public static bool operator ==(ValidationError left, ValidationError right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValidationError left, ValidationError right)
        {
            return !left.Equals(right);
        }
    }
}
