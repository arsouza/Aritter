using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Data.Seedwork.Tests.Repositories.Mock
{
    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;

        public TestAsyncEnumerator(IEnumerator<T> enumerator)
        {
            this.enumerator = enumerator;
        }

        public void Dispose()
        {
            enumerator.Dispose();
        }

        public T Current
        {
            get
            {
                return enumerator.Current;
            }
        }

        public Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            return Task.FromResult(enumerator.MoveNext());
        }
    }
}
