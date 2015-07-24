using Aritter.Domain.Aggregates;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aritter.Web.Core.Attributes
{
	public class RequiredRuleAttribute : ActionFilterAttribute
	{
		#region Constructors

		public RequiredRuleAttribute(params Rule[] rules)
		{
			Rules = rules.AsEnumerable();
		}

		#endregion Constructors

		#region Properties

		public IEnumerable<Rule> Rules { get; private set; }

		#endregion
	}
}