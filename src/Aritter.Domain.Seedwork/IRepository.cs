using System;

namespace Aritter.Domain.Seedwork
{
    public interface IRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
