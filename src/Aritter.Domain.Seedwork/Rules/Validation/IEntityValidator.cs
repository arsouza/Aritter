namespace Aritter.Domain.Seedwork.Rules.Validation
{
	public interface IEntityValidator<TEntity>
	{
		ValidationResult Validate(TEntity entity);
		ValidationResult Validate(TEntity entity, string ruleName);
	}
}
