namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public class ValidationError
    {
        public string Message { get; private set; }

        public ValidationError(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return Message ?? base.ToString();
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
