namespace Aritter.Domain.Seedwork.Rules.Business
{
	public interface IBusinessRule<TEntity>
	{
		void Evaluate(TEntity entity);
	}
}
