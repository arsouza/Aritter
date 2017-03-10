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
        public void PaginateSuccessfully()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);

            List<TestObject> paginateResult = values.Paginate(pagination).ToList();

            Assert.AreEqual(10, paginateResult.Count);
            Assert.AreEqual(1, paginateResult[0].Id);
        }

        [TestMethod]
        public void PaginatePageSizeEqualsZeroSuccessfully()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 0);

            List<TestObject> paginateResult = values.Paginate(pagination).ToList();

            Assert.AreEqual(0, paginateResult.Count);
        }

        [TestMethod]
        public void PaginateWithNullPaginationShouldThrowsArgumentNullExceptions()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                IEnumerable<TestObject> values = GetTestObjectList();
                values.Paginate(null).ToList();
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual("page", exception.ParamName);
        }

        [TestMethod]
        public void PaginateInvalidPageIndexShouldThrowsArgumentExceptions()
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                IEnumerable<TestObject> values = GetTestObjectList();
                Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(-1, 10);

                values.Paginate(pagination).ToList();
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual("PageIndex", exception.ParamName);
        }

        [TestMethod]
        public void PaginateInvalidPageSizeShouldThrowsArgumentExceptions()
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                IEnumerable<TestObject> values = GetTestObjectList();
                Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, -1);

                values.Paginate(pagination).ToList();
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual("PageSize", exception.ParamName);
        }

        [TestMethod]
        public void PaginateOrderingAscendingSuccessfully()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);

            List<TestObject> paginateResult = values.Paginate(pagination).ToList();

            Assert.AreEqual(10, paginateResult.Count);
            Assert.AreEqual(1, paginateResult[0].Id);
        }

        [TestMethod]
        public void PaginateOrderingDescendingSuccessfully()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);

            List<TestObject> paginateResult = values.Paginate(pagination).ToList();

            Assert.AreEqual(10, paginateResult.Count);
            Assert.AreEqual(100, paginateResult[0].Id);
        }

        [TestMethod]
        public void PaginateListSuccessfully()
        {
            List<TestObject> values = GetTestObjectList().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);
            int pageCount = GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject>;

            Assert.AreEqual(10, paginateResult.Count);
            Assert.AreEqual(1, paginateResult[0].Id);
            Assert.AreEqual(values.Count, paginateResult.TotalCount);
            Assert.AreEqual(pageCount, paginateResult.PageCount);
        }

        [TestMethod]
        public void PaginateListWithReminderSuccessfully()
        {
            List<TestObject> values = GetTestObjectListWithLength(55).ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);
            int pageCount = GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject>;

            Assert.AreEqual(10, paginateResult.Count);
            Assert.AreEqual(1, paginateResult[0].Id);
            Assert.AreEqual(values.Count, paginateResult.TotalCount);
            Assert.AreEqual(pageCount, paginateResult.PageCount);
        }

        [TestMethod]
        public void PaginateListOrderingAscendingSuccessfully()
        {
            List<TestObject> values = GetTestObjectList().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);
            int pageCount = GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject>;

            Assert.AreEqual(10, paginateResult.Count);
            Assert.AreEqual(1, paginateResult[0].Id);
            Assert.AreEqual(values.Count, paginateResult.TotalCount);
            Assert.AreEqual(pageCount, paginateResult.PageCount);
        }

        [TestMethod]
        public void PaginateListOrderingDescendingSuccessfully()
        {
            List<TestObject> values = GetTestObjectList().ToList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);
            int pageCount = GetPageCount(pagination.PageSize, values.Count);

            PaginatedList<TestObject> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject>;

            Assert.AreEqual(10, paginateResult.Count);
            Assert.AreEqual(100, paginateResult[0].Id);
            Assert.AreEqual(values.Count, paginateResult.TotalCount);
            Assert.AreEqual(pageCount, paginateResult.PageCount);
        }

        [TestMethod]
        public void PaginateListPageSizeEqualsZeroSuccessfully()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 0);

            PaginatedList<TestObject> paginateResult = values.PaginateList(pagination) as PaginatedList<TestObject>;

            Assert.AreEqual(0, paginateResult.Count);
            Assert.AreEqual(0, paginateResult.PageCount);
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
