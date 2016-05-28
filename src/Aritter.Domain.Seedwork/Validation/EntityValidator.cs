using Aritter.Domain.Seedwork.Rules.Validation;
using Aritter.Infra.Crosscutting.Extensions;

namespace Aritter.Domain.Seedwork.Validation
{
	public sealed class EntityValidator : EntityValidatorBase<IValidatableEntity>
	{
		public override ValidationResult Validate(IValidatableEntity entity)
		{
			ConfigureValidation(entity);
			return base.Validate(entity);
		}

		public override ValidationResult Validate(IValidatableEntity entity, string ruleName)
		{
			ConfigureValidation(entity);
			return base.Validate(entity, ruleName);
		}

		private void ConfigureValidation(IValidatableEntity entity)
		{
			OnValidateEntity(entity);
			ClearValidations();
			entity.ValidationRules.ForEach(rule =>
			{
				AddValidation(rule.Key, rule.Value);
			});
		}

		private void OnValidateEntity(IValidatableEntity entity)
		{
			lock (entity)
			{
				entity.OnValidate();
			}
		}

		public static EntityValidator CreateValidator()
		{
			return new EntityValidator();
		}
	}
}
