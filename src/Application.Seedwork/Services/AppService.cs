using System.Transactions;

namespace Ritter.Application.Services
{
    public abstract class AppService : IAppService
    {
        protected TransactionScope CreateTransactionScope()
        {
            return CreateTransactionScope(IsolationLevel.ReadCommitted);
        }

        protected TransactionScope CreateTransactionScope(IsolationLevel isolationLevel)
        {
            return new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = isolationLevel },
                TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}
