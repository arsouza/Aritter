using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ritter.Infra.Crosscutting.Collections;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Paginng
{
    public class Pagination_Paginate
    {
        [Fact]
        public void ReturnPaginatedGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 10);

            var paginateResult = values.Paginate(pagination).ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }

        [Fact]
        public void ReturnPaginatedAsyncGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 10);

            var paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }

        [Fact]
        public void ReturnPaginatedGivenPageSizeZero()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 0);

            var paginateResult = values.Paginate(pagination).ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(100);
        }

        [Fact]
        public void ReturnPaginatedAsyncGivenPageSizeZero()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 0);

            var paginateResult = values.PaginateAsync(pagination)
                .GetAwaiter()
                .GetResult()
                .ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(100);
        }

        [Fact]
        public void ThrowExceptionGivenNull()
        {
            Action act = () =>
            {
                IEnumerable<TestObject1> values = GetQuery();
                values.Paginate(null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("page");
        }

        [Fact]
        public void ReturnPaginatedOrderingAscendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 10, "Id", true);

            var paginateResult = values.Paginate(pagination).ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }

        [Fact]
        public void ReturnPaginatedAsyncOrderingAscendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 10, "Id", true);

            var paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }

        [Fact]
        public void ReturnPaginatedOrderingDescendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 10, "Id", false);

            var paginateResult = values.Paginate(pagination).ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(99));
        }

        [Fact]
        public void ReturnPaginatedAsyncOrderingDescendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            var pagination = new Pagination(0, 10, "Id", false);

            var paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(99));
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
