using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ritter.Domain.Specifications
{
    public static class ExpressionBuilder
    {
        internal static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters
                .Select((parameterExpression, index) => new
                {
                    FirstParameter = parameterExpression,
                    SecondParameter = second.Parameters[index]
                })
                .ToDictionary(p => p.SecondParameter, p => p.FirstParameter);

            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
            => first.Compose(second, Expression.AndAlso);

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
            => first.Compose(second, Expression.OrElse);
    }
}
