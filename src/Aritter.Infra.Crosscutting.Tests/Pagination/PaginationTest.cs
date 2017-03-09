using Aritter.Infra.Cosscutting.Extensions;
using Aritter.Infra.Crosscutting.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Tests.Pagination
{
    [TestClass]
    public class PaginationTest
    {        
        [TestMethod]
        public void Paginate()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);

            List<TestObject> paginateResult = values.Paginate(pagination).ToList();

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 1);
        }

        [TestMethod]
        public void PaginateWithNullPaginationShouldThrowsArgumentNullExceptions()
        {
            Exception exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                IEnumerable<TestObject> values = GetTestObjectList();

                values.Paginate(null).ToList();
            });

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("page cannot be null."));
        }

        [TestMethod]
        public void PaginateInvalidPageIndexShouldThrowsArgumentExceptions()
        {
            Exception exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                IEnumerable<TestObject> values = GetTestObjectList();
                Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(-1, 10);

                values.Paginate(pagination).ToList();
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "PageIndex must be greater then or equal to 0 (zero).");
        }

        [TestMethod]
        public void PaginateInvalidPageSizeShouldThrowsArgumentExceptions()
        {
            Exception exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                IEnumerable<TestObject> values = GetTestObjectList();
                Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, -1);

                values.Paginate(pagination).ToList();
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "PageSize must be greater then 0 (zero).");
        }

        [TestMethod]
        public void PaginateWithOrderAscending()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);

            List<TestObject> paginateResult = values.Paginate(pagination).ToList();

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 1);
        }

        [TestMethod]
        public void PaginateWithOrderDescending()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);

            List<TestObject> paginateResult = values.Paginate(pagination).ToList();

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 100);
        }

        [TestMethod]
        public void PaginateList()
        {
            List<TestObject> values = GetTestObjectList().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);
            int pageCount = GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject>;

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 1);
            Assert.IsTrue(paginateResult.TotalCount == values.Count);
            Assert.IsTrue(paginateResult.PageCount == pageCount);
        }

        [TestMethod]
        public void PaginateListWithOrderAscending()
        {
            List<TestObject> values = GetTestObjectList().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);
            int pageCount = GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject>;

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 1);
            Assert.IsTrue(paginateResult.TotalCount == values.Count);
            Assert.IsTrue(paginateResult.PageCount == pageCount);
        }

        [TestMethod]
        public void PaginateListWithOrderDescending()
        {
            List<TestObject> values = GetTestObjectList().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);
            int pageCount = GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject>;

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 100);
            Assert.IsTrue(paginateResult.TotalCount == values.Count);
            Assert.IsTrue(paginateResult.PageCount == pageCount);
        }

        private IEnumerable<TestObject> GetTestObjectListWithLength(int length)
        {
            int id = 0;
            List<TestObject> values = new List<TestObject>();

            for (int i = 0; i < length; i++)
            {
                values.Add(new TestObject { Id = ++id });
            }

            return values;
        }

        private IEnumerable<TestObject> GetTestObjectList()
        {
            return GetTestObjectListWithLength(100);
        }

        private static int GetPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
            {
                return 0;
            }

            var remainder = totalCount % pageSize;
            return totalCount / pageSize + (remainder == 0 ? 0 : 1);
        }
    }
}
