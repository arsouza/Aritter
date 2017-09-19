using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Seedwork.Tests.Extensions
{
    public static class DbSetExtensions
    {
        public static void SetSource<T>(this Mock<DbSet<T>> mockSet, IEnumerable<T> source) where T : class
        {
            var data = source.AsQueryable();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        }
    }
}
