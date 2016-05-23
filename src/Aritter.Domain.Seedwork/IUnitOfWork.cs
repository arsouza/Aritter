using System;

namespace Aritter.Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void CommitAndRefreshChanges();

        void RollbackChanges();
    }
}