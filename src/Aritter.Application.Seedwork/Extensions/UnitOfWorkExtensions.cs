using Aritter.Domain.Seedwork;
using System;

namespace Aritter.Application.Seedwork.Extensions
{
    public static class UnitOfWorkExtensions
    {
        public static TResult TransactScope<TResult>(this IUnitOfWork unitOfWork, Func<TResult> scope)
        {
            try
            {
                TResult result = default(TResult);
                unitOfWork.BeginTransaction();

                result = scope();

                unitOfWork.Commit();

                return result;
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public static void TransactScope(this IUnitOfWork unitOfWork, Action scope)
        {
            try
            {
                unitOfWork.BeginTransaction();
                scope();
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }
    }
}
