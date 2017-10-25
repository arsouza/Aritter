namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationError
    {
        public string Message { get; private set; }
        public string Property { get; private set; }

        public ValidationError(string property, string message)
            : this(message)
        {
            Property = property;
        }

        public ValidationError(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Property) && string.IsNullOrEmpty(Message))
                return "Unknown error";

            if (string.IsNullOrEmpty(Property))
                return Message ?? "Unknown error";

            return $"{Property}: {Message ?? "This field is invalid."}";
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
