using Ritter.Infra.Crosscutting.Exceptions;
using System;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationError
    {
        public string Message { get; private set; }

        public string Property { get; private set; }

        public ValidationError(string message, string property)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("Please provide a valid non null value for the validationMessage parameter.");

            Message = message;
            Property = property;
        }

        public override string ToString()
        {
            return string.Format("({0}) - {1}", Property, Message);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ValidationError))
                return false;

            return Equals((ValidationError)obj);
        }

        public bool Equals(ValidationError obj)
        {
            return Equals(obj.Message, Message) && Equals(obj.Property, Property);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Message.GetHashCode() * 397) ^ Property.GetHashCode();
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
