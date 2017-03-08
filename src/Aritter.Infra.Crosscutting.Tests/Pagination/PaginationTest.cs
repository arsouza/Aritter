using Aritter.Infra.Cosscutting.Extensions;
using Aritter.Infra.Crosscutting.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Tests.Pagination
{
    [TestClass]
    public class PaginationTest
    {
        private class TestObject
        {
            public int Id { get; set; }
        }

        [TestMethod]
        public void Paginate()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10);

            var paginateResult = values.Paginate(pagination).ToList();

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 1);
        }

        [TestMethod]
        public void PaginateWithOrderAscending()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", true);

            var paginateResult = values.Paginate(pagination).ToList();

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 1);
        }

        [TestMethod]
        public void PaginateWithOrderDescending()
        {
            IEnumerable<TestObject> values = GetTestObjectList();
            Crosscutting.Pagination.Pagination pagination = new Crosscutting.Pagination.Pagination(0, 10, "Id", false);

            var paginateResult = values.Paginate(pagination).ToList();

            Assert.IsTrue(paginateResult.Count == 10);
            Assert.IsTrue(paginateResult[0].Id == 100);
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
    }
}
