using Aritter.Infra.Crosscutting.Exceptions;
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
			try
			{
				using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
				{
					TReturn tReturn = func();
					transaction.Complete();

					return tReturn;
				}
			}
			catch (ApplicationErrorException)
			{
				throw;
			}
			catch (Exception ex)
			{
				LogException(ex);
				throw new ApplicationErrorException(ex);
			}
		}

		protected void WithTransaction(Action func)
		{
			try
			{
				using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
				{
					func();
					transaction.Complete();
				}
			}
			catch (ApplicationErrorException)
			{
				throw;
			}
			catch (Exception ex)
			{
				LogException(ex);
				throw new ApplicationErrorException(ex);
			}
		}

		protected void LogException(Exception ex)
		{
			logger.Error($"===== Begin Service Exception =====");
			logger.Error($"TransactionAbortedException Message: {ex.Message}", ex);

			Exception current = ex;

			while (current != null)
			{
				logger.Error($"TransactionAbortedException Message: {current.Message}", current);
				current = current.InnerException;
			}

			logger.Error($"===== End Service Exception =====");
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