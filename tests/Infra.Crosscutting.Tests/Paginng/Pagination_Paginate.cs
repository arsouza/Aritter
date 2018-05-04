using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Paginng
{
    public class Pagination_Paginate
    {
        [Fact]
        public void ReturnPaginatedGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 10);

            List<TestObject1> paginateResult = values.Paginate(pagination).ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }

        [Fact]
        public void ReturnPaginatedAsyncGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 10);

            List<TestObject1> paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }

        [Fact]
        public void ReturnPaginatedGivenPageSizeZero()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 0);

            List<TestObject1> paginateResult = values.Paginate(pagination).ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void ReturnPaginatedAsyncGivenPageSizeZero()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 0);

            List<TestObject1> paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void ThrowExceptionGivenNull()
        {
            Action act = () =>
            {
                IEnumerable<TestObject1> values = GetQuery();
                values.Paginate(null).ToList();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("page");
        }

        [Fact]
        public void ReturnPaginatedOrderingAscendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 10, "Id", true);

            List<TestObject1> paginateResult = values.Paginate(pagination).ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }

        [Fact]
        public void ReturnPaginatedAsyncOrderingAscendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 10, "Id", true);

            List<TestObject1> paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }

        [Fact]
        public void ReturnPaginatedOrderingDescendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 10, "Id", false);

            List<TestObject1> paginateResult = values.Paginate(pagination).ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(99));
        }

        [Fact]
        public void ReturnPaginatedAsyncOrderingDescendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 10, "Id", false);

            List<TestObject1> paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(99));
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
