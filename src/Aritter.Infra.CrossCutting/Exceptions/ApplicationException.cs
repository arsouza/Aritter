using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Exceptions
{
	public class ApplicationException : Exception
	{
		#region Fields

		private readonly HashSet<string> errors;

		#endregion

		#region Constructor

		public ApplicationException(params string[] errors)
			: this(errors.AsEnumerable())
		{
		}

		public ApplicationException(Exception exception, params string[] errors)
			: this(exception, errors.AsEnumerable())
		{
		}

		public ApplicationException(IEnumerable<string> errors)
			: this(null, errors)
		{
		}

		public ApplicationException(Exception exception, IEnumerable<string> errors)
			: base("One or more errors occurs. Check internal errors.", exception)
		{
			this.errors = new HashSet<string>();

			foreach (var error in errors)
			{
				this.errors.Add(error);
			}
		}

		public ApplicationException(Exception exception)
		   : this(exception, exception.ToString())
		{
		}

		#endregion

		#region Properties

		public IReadOnlyCollection<string> Errors { get { return errors; } }

		#endregion
	}
}