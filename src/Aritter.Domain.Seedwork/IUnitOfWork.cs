using System;

namespace Aritter.Domain.Seedwork
{
	public interface IUnitOfWork : IDisposable
	{
		void CommitChanges();

		void RollbackChanges();
	}
}