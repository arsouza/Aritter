using Ritter.Infra.Crosscutting.Extensions;
using Ritter.Infra.Crosscutting.Pagination;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Pagination
{
    public class Pagination_PaginateList
    {
        [Fact]
        public void PaginateListWithReminderSuccessfully()
        {
            List<TestObject1> values = GetQuery(55).ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);
            int pageCount = MockUtil.GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject1> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject1>;

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(1, paginateResult[0].Id);
            Assert.Equal(values.Count, paginateResult.TotalCount);
            Assert.Equal(pageCount, paginateResult.PageCount);
        }


        [Fact]
        public void PaginateListAsyncWithReminderSuccessfully()
        {
            List<TestObject1> values = GetQuery(55).ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);
            int pageCount = MockUtil.GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject1> paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PaginatedList<TestObject1>;

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(1, paginateResult[0].Id);
            Assert.Equal(values.Count, paginateResult.TotalCount);
            Assert.Equal(pageCount, paginateResult.PageCount);
        }

        [Fact]
        public void ReturnListOrderedAscendingGivenIndexAndSize()
        {
            List<TestObject1> values = GetQuery().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);
            int pageCount = MockUtil.GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject1> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject1>;

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(1, paginateResult[0].Id);
            Assert.Equal(values.Count, paginateResult.TotalCount);
            Assert.Equal(pageCount, paginateResult.PageCount);
        }

        [Fact]
        public void ReturnListOrderedAscendingAsyncGivenIndexAndSize()
        {
            List<TestObject1> values = GetQuery().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);
            int pageCount = MockUtil.GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject1> paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PaginatedList<TestObject1>;

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(1, paginateResult[0].Id);
            Assert.Equal(values.Count, paginateResult.TotalCount);
            Assert.Equal(pageCount, paginateResult.PageCount);
        }

        [Fact]
        public void ReturnListOrderedDescendingGivenIndexAndSize()
        {
            List<TestObject1> values = GetQuery().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);
            int pageCount = MockUtil.GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject1> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject1>;

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(100, paginateResult[0].Id);
            Assert.Equal(values.Count, paginateResult.TotalCount);
            Assert.Equal(pageCount, paginateResult.PageCount);
        }

        [Fact]
        public void ReturnListOrderedDescendingAsyncGivenIndexAndSize()
        {
            List<TestObject1> values = GetQuery().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);
            int pageCount = MockUtil.GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject1> paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PaginatedList<TestObject1>;

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(100, paginateResult[0].Id);
            Assert.Equal(values.Count, paginateResult.TotalCount);
            Assert.Equal(pageCount, paginateResult.PageCount);
        }

        [Fact]
        public void ReturnEmptyListGivenZeroSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 0);

            PaginatedList<TestObject1> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject1>;

            Assert.Equal(0, paginateResult.Count);
            Assert.Equal(0, paginateResult.PageCount);
        }

        [Fact]
        public void ReturnEmptyListGivenZeroSizeAsync()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 0);

            PaginatedList<TestObject1> paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PaginatedList<TestObject1>;

            Assert.Equal(0, paginateResult.Count);
            Assert.Equal(0, paginateResult.PageCount);
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
