using Ritter.Infra.Crosscutting.Extensions;
using System;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public sealed class ValidationError
    {
        public string Property { get; private set; }
        public string Message { get; private set; }

        public ValidationError(string message)
        {
            if (message.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(message));

            Message = message;
        }

        public ValidationError(string property, string message)
            : this(message)
        {
            Property = property;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ValidationError))
                return false;

            return Equals((ValidationError)obj);
        }

        public bool Equals(ValidationError obj)
        {
            return Equals(obj.Message, Message);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Message.GetHashCode() * 397);
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
