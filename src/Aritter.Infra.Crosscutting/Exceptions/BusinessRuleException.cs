using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Exceptions
{
	public class BusinessRuleException : Exception
	{
		#region Fields

		private readonly HashSet<string> errors;

		#endregion

		#region Properties

		public IReadOnlyCollection<string> Errors { get { return errors; } }

		#endregion

		#region Constructor

		public BusinessRuleException(params string[] errors)
			: this(errors.AsEnumerable())
		{
		}

		public BusinessRuleException(Exception exception, params string[] errors)
			: this(exception, errors.AsEnumerable())
		{
		}

		public BusinessRuleException(IEnumerable<string> errors)
			: this(null, errors)
		{
		}

		public BusinessRuleException(Exception exception, IEnumerable<string> errors)
			: base("One or more errors occurs. Check internal errors.", exception)
		{
			this.errors = new HashSet<string>();

			foreach (var error in errors)
			{
				this.errors.Add(error);
			}
		}

		public BusinessRuleException(Exception exception)
		   : this(exception, exception.ToString())
		{
		}

		#endregion
	}
}