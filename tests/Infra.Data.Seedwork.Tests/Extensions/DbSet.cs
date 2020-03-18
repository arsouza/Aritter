using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain;
using Ritter.Infra.Data.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Tests.Extensions
{
    public static class DbSetExtensions
    {
        public static void SetupAsQueryable<T>(this Mock<DbSet<T>> mockSet, IList<T> source) where T : class, IEntity
        {
            IQueryable<T> data = source.AsQueryable();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(d => d.Add(It.IsAny<T>()))
                .Callback<T>((s) => source.Add(s));

            mockSet.Setup(m => m.Find(It.IsAny<object[]>()))
                .Returns<object[]>(key => source.FirstOrDefault(d => d.Id == (long)key[0]));
        }

        public static void SetupAsQueryableAsync<T>(this Mock<DbSet<T>> mockSet, IList<T> source) where T : class, IEntity
        {
            IQueryable<T> data = source.AsQueryable();

            mockSet.As<IAsyncEnumerable<T>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<T>(data.Provider));
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>()))
                .Returns<object[]>(async key =>
                {
                    return await Task.FromResult(source.FirstOrDefault(d => d.Id == (long)key[0]));
                });
        }
    }
}
