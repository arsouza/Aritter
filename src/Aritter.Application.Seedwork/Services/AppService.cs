using Aritter.Infra.Crosscutting.Logging;
using System;
using System.Transactions;

namespace Aritter.Application.Seedwork.Services
{
    public abstract class AppService : IAppService
    {
        protected readonly ILogger logger;

        public AppService()
        {
            logger = LoggerFactory.CreateLog();
        }

        protected TReturn WithTransaction<TReturn>(Func<TReturn> func)
            where TReturn : class, new()
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                TReturn tReturn = func();
                transaction.Complete();

                return tReturn;
            }
        }

        protected void WithTransaction(Action func)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                func();
                transaction.Complete();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AppService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion
    }
}