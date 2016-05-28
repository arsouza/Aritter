using Aritter.Domain.Seedwork.Rules.Validation;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork
{
	public interface IValidatableEntity : IEntity
	{
		void OnValidate();
		Dictionary<string, IValidationRule<IValidatableEntity>> ValidationRules { get; }
	}
}
