using Ritter.Infra.Crosscutting.Extensions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ritter.Infra.Crosscutting.Tests.Pagination
{
    public class Pagination_Paginate
    {
        [Fact]
        public void ReturnPaginatedGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);

            List<TestObject1> paginateResult = values.Paginate(pagination).ToList();

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(1, paginateResult[0].Id);
        }

        [Fact]
        public void ReturnPaginatedAsyncGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);

            List<TestObject1> paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(1, paginateResult[0].Id);
        }

        [Fact]
        public void ReturnPaginatedGivenPageSizeZero()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 0);

            List<TestObject1> paginateResult = values.Paginate(pagination).ToList();

            Assert.Equal(0, paginateResult.Count);
        }

        [Fact]
        public void ReturnPaginatedAsyncGivenPageSizeZero()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 0);

            List<TestObject1> paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            Assert.Equal(0, paginateResult.Count);
        }

        [Fact]
        public void ThrowExceptionGivenNull()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                IEnumerable<TestObject1> values = GetQuery();
                values.Paginate(null).ToList();
            });

            Assert.NotNull(exception);
            Assert.Equal("page", exception.ParamName);
        }

        [Fact]
        public void ThrowExceptionGivenInvalidIndex()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                IEnumerable<TestObject1> values = GetQuery();
                Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(-1, 10);

                values.Paginate(pagination).ToList();
            });

            Assert.NotNull(exception);
            Assert.Equal("PageIndex", exception.ParamName);
        }

        [Fact]
        public void ThrowExceptionGivenInvalidSize()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                IEnumerable<TestObject1> values = GetQuery();
                Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, -1);

                values.Paginate(pagination).ToList();
            });

            Assert.NotNull(exception);
            Assert.Equal("PageSize", exception.ParamName);
        }

        [Fact]
        public void ReturnPaginatedOrderingAscendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);

            List<TestObject1> paginateResult = values.Paginate(pagination).ToList();

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(1, paginateResult[0].Id);
        }

        [Fact]
        public void ReturnPaginatedAsyncOrderingAscendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);

            List<TestObject1> paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(1, paginateResult[0].Id);
        }

        [Fact]
        public void ReturnPaginatedOrderingDescendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);

            List<TestObject1> paginateResult = values.Paginate(pagination).ToList();

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(100, paginateResult[0].Id);
        }

        [Fact]
        public void ReturnPaginatedAsyncOrderingDescendingGivenIndexAndSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);

            List<TestObject1> paginateResult = values.PaginateAsync(pagination).GetAwaiter().GetResult().ToList();

            Assert.Equal(10, paginateResult.Count);
            Assert.Equal(100, paginateResult[0].Id);
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
