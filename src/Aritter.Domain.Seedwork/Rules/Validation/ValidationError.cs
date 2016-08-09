#region license



#endregion

using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Rules.Validation
{
	[Serializable]
	public class ValidationError
	{
		public string Message { get; set; }

		public string Property { get; set; }

		public ValidationError(string message, string property)
		{
			Check.Against<ArgumentNullException>(string.IsNullOrEmpty(message), "Please provide a valid non null string as the validation error message");
			//Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(property), "Please provide a valid non null string as the validation property name");

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
			{
				return false;
			}

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