using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Infra.Data.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace Ritter.Infra.Data.Tests.Extensions
{
    public static class DbSetExtensions
    {
        public static void SetupAsQueryable<T>(this Mock<DbSet<T>> mockSet, IList<T> source) where T : class
        {
            var data = source.AsQueryable();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => source.Add(s));
        }

        public static void SetupAsQueryableAsync<T>(this Mock<DbSet<T>> mockSet, IList<T> source) where T : class
        {
            var data = source.AsQueryable();

            mockSet.As<IAsyncEnumerable<T>>().Setup(m => m.GetEnumerator()).Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<T>(data.Provider));
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
        }
    }
}
