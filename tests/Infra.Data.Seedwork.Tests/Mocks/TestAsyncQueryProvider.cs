using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Tests.Mocks
{
    internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider queryProvider;

        internal TestAsyncQueryProvider(IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return queryProvider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return queryProvider.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => Execute<TResult>(expression), cancellationToken).GetAwaiter().GetResult();
        }
    }
}
