using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ritter.Domain
{
    public interface INoSqlRepository<TEntity> : IRepository
    {
        Task<TEntity> QueryById(string id);
        Task<IEnumerable<TEntity>> QueryAll(int pageNumber, int pageSize = 100);
        Task InsertOrUpdate(TEntity element, int? expirationTimeInHour = null);
        Task InsertOrUpdate(TEntity element, string id, int? expirationTimeInHour = null, string checkConcorrencia = null);
        Task Delete(string id);
        Task Delete(TEntity element);
        Task<IEnumerable<TEntity>> Query(Func<TEntity, bool> predicate);
        Task<TEntity> FirstOrDefault(Func<TEntity, bool> predicate);
    }
}
