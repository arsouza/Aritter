using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Ordering_OrderByDescending
    {
        [Fact]
        public void ReturnOrderByDescendingGivenSimpleProperty()
        {
            IQueryable<TestObject1> query = GetQuery();
            var result = query.OrderByDescending("Id");

            result.Should().NotBeNull().And.BeAssignableTo<IOrderedQueryable<TestObject1>>().And.NotBeEmpty().And.HaveSameCount(query);
            result.First().Id.Should().Be(query.Last().Id);
            result.Last().Id.Should().Be(query.First().Id);
        }

        [Fact]
        public void ReturnOrderByDescendingGivenComplexProperty()
        {
            IQueryable<TestObject1> query = GetQuery();
            var result = query.OrderByDescending("TestObject2.Id");

            result.Should().NotBeNull().And.BeAssignableTo<IOrderedQueryable<TestObject1>>().And.NotBeEmpty().And.HaveSameCount(query);
            result.First().Id.Should().Be(query.Last().Id);
            result.Last().Id.Should().Be(query.First().Id);
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
