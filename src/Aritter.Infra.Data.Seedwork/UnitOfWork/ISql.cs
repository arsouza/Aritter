using System.Collections.Generic;

namespace Aritter.Infra.Data.SeedWork.UnitOfWork
{
    public interface ISql
    {
        #region Methods

        int ExecuteSqlCommand(string sqlCommand, params object[] parameters);
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        #endregion Methods
    }
}