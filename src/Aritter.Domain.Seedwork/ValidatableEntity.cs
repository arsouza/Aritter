using Aritter.Domain.Seedwork.Rules.Validation;
using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork
{
	public class ValidatableEntity : Entity, IValidatableEntity
	{
		public Dictionary<string, IValidationRule<IValidatableEntity>> ValidationRules { get; private set; }

		public void OnValidate()
		{
			if (ShouldConfigure())
			{
				OnAddValidations();
			}
		}

		protected virtual void OnAddValidations()
		{
		}

		protected void AddValidation(string ruleName, IValidationRule<IValidatableEntity> rule)
		{
			Guard.Against<InvalidOperationException>(ValidationRules == null, $"'ValidationRules' cannot be null. Cannot validate.");
			Guard.Against<ArgumentNullException>(rule == null, "Cannot add a null rule instance. Expected a non null reference.");
			Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Cannot add a rule with an empty or null rule name.");
			Guard.Against<ArgumentException>(ValidationRules.ContainsKey(ruleName), "Another rule with the same name already exists. Cannot add duplicate rules.");

			ValidationRules.Add(ruleName, rule);
		}

		protected void RemoveValidation(string ruleName)
		{
			Guard.Against<InvalidOperationException>(ValidationRules == null, $"'ValidationRules' cannot be null. Cannot validate.");
			Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Expected a non empty and non-null rule name.");

			ValidationRules.Remove(ruleName);
		}

		private bool ShouldConfigure()
		{
			if (ValidationRules == null)
			{
				IDictionary cache;
				Type key = GetType();

				if (ValidationRuleCache.TryGetCache(key, out cache))
				{
					ValidationRules = cache as Dictionary<string, IValidationRule<IValidatableEntity>>;
					return cache.Count == 0;
				}
				else
				{
					ValidationRules = new Dictionary<string, IValidationRule<IValidatableEntity>>();
					ValidationRuleCache.AddCache(key, ValidationRules);
					return true;
				}
			}
			return false;
		}
	}
}
