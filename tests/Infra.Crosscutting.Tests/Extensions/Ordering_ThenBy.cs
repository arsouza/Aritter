using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Ordering_ThenBy
    {
        [Fact]
        public void ReturnThenByGivenSimpleProperty()
        {
            IQueryable<TestObject1> query = GetQuery();
            IOrderedQueryable<TestObject1> result = query.OrderBy("Id").ThenBy("TestObject2Id");

            result.Should().NotBeNull().And.BeAssignableTo<IOrderedQueryable<TestObject1>>().And.NotBeEmpty().And.HaveSameCount(query);
            result.First().Id.Should().Be(query.First().Id);
            result.Last().Id.Should().Be(query.Last().Id);
        }

        [Fact]
        public void ReturnThenByGivenComplexProperty()
        {
            IQueryable<TestObject1> query = GetQuery();
            IOrderedQueryable<TestObject1> result = query.OrderBy("Id").ThenBy("TestObject2.Id");

            result.Should().NotBeNull().And.BeAssignableTo<IOrderedQueryable<TestObject1>>().And.NotBeEmpty().And.HaveSameCount(query);
            result.First().Id.Should().Be(query.First().Id);
            result.Last().Id.Should().Be(query.Last().Id);
        }

        private static IQueryable<TestObject1> GetQuery()
        {
            return GetQuery(100);
        }

        private static IQueryable<TestObject1> GetQuery(int length)
        {
            var query = new List<TestObject1>();

            for (int i = 1; i <= length; i++)
            {
                query.Add(new TestObject1 { Id = i, TestObject2Id = i, TestObject2 = new TestObject2 { Id = i } });
            }

            return query.AsQueryable();
        }
    }
}
