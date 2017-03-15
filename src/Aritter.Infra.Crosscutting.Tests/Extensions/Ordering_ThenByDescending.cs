using Aritter.Infra.Crosscutting.Tests.Mock;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    public class Ordering_ThenByDescending
    {
        [Fact]
        public void ReturnThenByDescendingGivenSimpleProperty()
        {
            IQueryable<TestObject1> query = GetQuery();
            var result = query.OrderByDescending("Id").ThenByDescending("TestObject2Id");

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IOrderedQueryable<TestObject1>>(result);
            Assert.Equal(result.Count(), query.Count());
            Assert.Equal(result.First().Id, query.Last().Id);
            Assert.Equal(result.Last().Id, query.First().Id);
        }

        [Fact]
        public void ReturnThenByDescendingGivenComplexProperty()
        {
            IQueryable<TestObject1> query = GetQuery();
            var result = query.OrderByDescending("Id").ThenByDescending("TestObject2.Id");

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IOrderedQueryable<TestObject1>>(result);
            Assert.Equal(result.Count(), query.Count());
            Assert.Equal(result.First().Id, query.Last().Id);
            Assert.Equal(result.Last().Id, query.First().Id);
        }

        private IQueryable<TestObject1> GetQuery()
        {
            return GetQuery(100);
        }

        private IQueryable<TestObject1> GetQuery(int length)
        {
            List<TestObject1> query = new List<TestObject1>();

            for (int i = 1; i <= length; i++)
            {
                query.Add(new TestObject1 { Id = i, TestObject2Id = i, TestObject2 = new TestObject2 { Id = i } });
            }

            return query.AsQueryable();
        }
    }
}
