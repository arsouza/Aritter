using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Tests.Mocks
{
    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;

        public TestAsyncEnumerator(IEnumerator<T> enumerator)
        {
            this.enumerator = enumerator;
        }

        public T Current => enumerator.Current;

        public async ValueTask DisposeAsync()
        {
            await Task.Run(() => enumerator.Dispose());
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.FromResult(enumerator.MoveNext());
        }
    }
}
