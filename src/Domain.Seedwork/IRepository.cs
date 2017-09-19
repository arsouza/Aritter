using System;

namespace Ritter.Domain.Seedwork
{
    public interface IRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
