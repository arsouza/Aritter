using Aritter.Infra.Crosscutting.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class EnumerableX
    {
        [TestMethod]
        public void CallOrderBySimpleSuccessfully()
        {
            IQueryable<TestComplexObject1> query = GetQuery();
            var result = query.OrderBy("Id");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<TestComplexObject1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.First().Id);
            Assert.AreEqual(result.Last().Id, query.Last().Id);
        }

        [TestMethod]
        public void CallOrderByDescendingSimpleSuccessfully()
        {
            IQueryable<TestComplexObject1> query = GetQuery();
            var result = query.OrderByDescending("Id");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<TestComplexObject1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.Last().Id);
            Assert.AreEqual(result.Last().Id, query.First().Id);
        }

        [TestMethod]
        public void CallThenBySuccessfully()
        {
            IQueryable<TestComplexObject1> query = GetQuery();
            var result = query.OrderBy("Id").ThenBy("TestComplexObject2.Id");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<TestComplexObject1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.First().Id);
            Assert.AreEqual(result.Last().Id, query.Last().Id);
        }

        [TestMethod]
        public void CallThenByDescendingSuccessfully()
        {
            IQueryable<TestComplexObject1> query = GetQuery();
            var result = query.OrderByDescending("Id").ThenByDescending("TestComplexObject2.Id");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<TestComplexObject1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.Last().Id);
            Assert.AreEqual(result.Last().Id, query.First().Id);
        }

        [TestMethod]
        public void CallOrderBySendAscendingSimpleSuccessfully()
        {
            IQueryable<TestComplexObject1> query = GetQuery();
            var result = query.OrderBy("Id", true);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<TestComplexObject1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.First().Id);
            Assert.AreEqual(result.Last().Id, query.Last().Id);
        }

        [TestMethod]
        public void CallOrderBySendDescendingSimpleSuccessfully()
        {
            IQueryable<TestComplexObject1> query = GetQuery();
            var result = query.OrderBy("Id", false);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<TestComplexObject1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.Last().Id);
            Assert.AreEqual(result.Last().Id, query.First().Id);
        }

        [TestMethod]
        public void CallOrderByAscendingComplexSuccessfully()
        {
            IQueryable<TestComplexObject1> query = GetQuery();
            var result = query.OrderBy("TestComplexObject2.Id", true);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<TestComplexObject1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.First().Id);
            Assert.AreEqual(result.Last().Id, query.Last().Id);
        }

        [TestMethod]
        public void CallOrderByDescendingComplexSuccessfully()
        {
            IQueryable<TestComplexObject1> query = GetQuery();
            var result = query.OrderBy("TestComplexObject2.Id", false);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<TestComplexObject1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.Last().Id);
            Assert.AreEqual(result.Last().Id, query.First().Id);
        }

        private IQueryable<TestComplexObject1> GetQuery()
        {
            int id = 0;

            IQueryable<TestComplexObject1> query = new List<TestComplexObject1>
            {
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } },
                new TestComplexObject1 { Id = ++id, TestComplexObject2Id = ++id, TestComplexObject2 = new TestComplexObject2 { Id = ++id } }
            }
            .AsQueryable();

            return query;
        }
    }    
}
