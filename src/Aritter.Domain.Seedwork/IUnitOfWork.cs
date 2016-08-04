using System;

namespace Aritter.Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void CommitChanges();

        void RollbackChanges();
    }
}