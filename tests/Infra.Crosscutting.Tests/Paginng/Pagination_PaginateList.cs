using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ritter.Infra.Crosscutting.Collections;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Paging
{
    public class Pagination_PaginateList
    {
        [Fact]
        public void PaginateListWithReminderSuccessfully()
        {
            var values = GetQuery(55).ToList();
            var pagination = new Pagination(0, 10);

            var paginateResult = values.PaginateList(pagination) as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }


        [Fact]
        public void PaginateListAsyncWithReminderSuccessfully()
        {
            var values = GetQuery(55).ToList();
            var pagination = new Pagination(0, 10);

            var paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
            paginateResult.TotalCount.Should().Be(values.Count);
        }

        [Fact]
        public void ReturnListOrderedAscendingGivenIndexAndSize()
        {
            var values = GetQuery().ToList();
            var pagination = new Pagination(0, 10, "Id", true);

            var paginateResult = values.PaginateList(pagination) as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
            paginateResult.TotalCount.Should().Be(values.Count);
        }

        [Fact]
        public void ReturnListOrderedAscendingAsyncGivenIndexAndSize()
        {
            var values = GetQuery().ToList();
            var pagination = new Pagination(0, 10, "Id", true);

            var paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
            paginateResult.TotalCount.Should().Be(values.Count);
        }

        [Fact]
        public void ReturnListOrderedDescendingGivenIndexAndSize()
        {
            var values = GetQuery().ToList();
            var pagination = new Pagination(0, 10, "Id", false);

            var paginateResult = values.PaginateList(pagination) as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(99));
            paginateResult.TotalCount.Should().Be(values.Count);
        }

        [Fact]
        public void ReturnListOrderedDescendingAsyncGivenIndexAndSize()
        {
            var values = GetQuery().ToList();
            var pagination = new Pagination(0, 10, "Id", false);

            var paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(99));
            paginateResult.TotalCount.Should().Be(100);
        }

        [Fact]
        public void ReturnPageListGivenZeroSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 0);

            var paginateResult = values.PaginateList(pagination) as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull();
            paginateResult.TotalCount.Should().Be(100);
        }

        [Fact]
        public void ReturnListGivenZeroSizeAsync()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 0);

            var paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull();
            paginateResult.TotalCount.Should().Be(100);
        }

        private IQueryable<TestObject1> GetQuery()
        {
            return GetQuery(100);
        }

        private IQueryable<TestObject1> GetQuery(int length)
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
