﻿using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Seedwork.Rules.Validation
{
	public abstract class EntityValidatorBase<TEntity> : IEntityValidator<TEntity>
		where TEntity : class, IEntity
	{
		private readonly Dictionary<string, IValidationRule<TEntity>> validations = new Dictionary<string, IValidationRule<TEntity>>();

		protected virtual void AddValidation(string ruleName, IValidationRule<TEntity> rule)
		{
			Guard.Against<ArgumentNullException>(rule == null, "Cannot add a null rule instance. Expected a non null reference.");
			Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Cannot add a rule with an empty or null rule name.");
			Guard.Against<ArgumentException>(validations.ContainsKey(ruleName), "Another rule with the same name already exists. Cannot add duplicate rules.");

			validations.Add(ruleName, rule);
		}

		protected virtual void ClearValidations()
		{
			var keys = validations
				.Keys
				.ToList();

			keys.ForEach(key =>
			{
				validations.Remove(key);
			});
		}

		protected virtual void RemoveValidation(string ruleName)
		{
			Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Expected a non empty and non-null rule name.");

			validations.Remove(ruleName);
		}

		public virtual ValidationResult Validate(TEntity entity)
		{
			var result = new ValidationResult();

			validations.Keys.ForEach(key =>
			{
				var ruleResult = Validate(entity, key);

				ruleResult.Errors.ForEach(error =>
				{
					result.AddError(error);
				});
			});

			return result;
		}

		public virtual ValidationResult Validate(TEntity entity, string ruleName)
		{
			Guard.Against<ArgumentException>(validations.ContainsKey(ruleName), $"The rule '{ruleName}' does not exists. Cannot validate.");

			var result = new ValidationResult();
			var rule = validations[ruleName];

			if (!rule.Validate(entity))
			{
				result.AddError(new ValidationError(rule.ValidationMessage, rule.ValidationProperty));
			}

			return result;
		}

		protected IValidationRule<TEntity> GetValidationRule(string ruleName)
		{
			IValidationRule<TEntity> rule;
			validations.TryGetValue(ruleName, out rule);

			return rule;
		}
	}

}