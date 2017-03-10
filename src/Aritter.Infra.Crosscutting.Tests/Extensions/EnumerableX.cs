using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class EnumerableX
    {
        [TestMethod]
        public void CallOrderBySimpleSuccessfully()
        {
            IQueryable<Object1> query = GetQuery();
            var result = query.OrderBy("Id");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<Object1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.First().Id);
            Assert.AreEqual(result.Last().Id, query.Last().Id);
        }

        [TestMethod]
        public void CallOrderByDescendingSimpleSuccessfully()
        {
            IQueryable<Object1> query = GetQuery();
            var result = query.OrderByDescending("Id");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<Object1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.Last().Id);
            Assert.AreEqual(result.Last().Id, query.First().Id);
        }

        [TestMethod]
        public void CallThenBySuccessfully()
        {
            IQueryable<Object1> query = GetQuery();
            var result = query.OrderBy("Id").ThenBy("Object2.Id");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<Object1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.First().Id);
            Assert.AreEqual(result.Last().Id, query.Last().Id);
        }

        [TestMethod]
        public void CallThenByDescendingSuccessfully()
        {
            IQueryable<Object1> query = GetQuery();
            var result = query.OrderByDescending("Id").ThenByDescending("Object2.Id");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<Object1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.Last().Id);
            Assert.AreEqual(result.Last().Id, query.First().Id);
        }

        [TestMethod]
        public void CallOrderBySendAscendingSimpleSuccessfully()
        {
            IQueryable<Object1> query = GetQuery();
            var result = query.OrderBy("Id", true);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<Object1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.First().Id);
            Assert.AreEqual(result.Last().Id, query.Last().Id);
        }

        [TestMethod]
        public void CallOrderBySendDescendingSimpleSuccessfully()
        {
            IQueryable<Object1> query = GetQuery();
            var result = query.OrderBy("Id", false);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<Object1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.Last().Id);
            Assert.AreEqual(result.Last().Id, query.First().Id);
        }

        [TestMethod]
        public void CallOrderByAscendingComplexSuccessfully()
        {
            IQueryable<Object1> query = GetQuery();
            var result = query.OrderBy("Object2.Id", true);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<Object1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.First().Id);
            Assert.AreEqual(result.Last().Id, query.Last().Id);
        }

        [TestMethod]
        public void CallOrderByDescendingComplexSuccessfully()
        {
            IQueryable<Object1> query = GetQuery();
            var result = query.OrderBy("Object2.Id", false);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IOrderedQueryable<Object1>));
            Assert.AreEqual(result.Count(), query.Count());
            Assert.AreEqual(result.First().Id, query.Last().Id);
            Assert.AreEqual(result.Last().Id, query.First().Id);
        }

        private IQueryable<Object1> GetQuery()
        {
            int id = 0;

            IQueryable<Object1> query = new List<Object1>
            {
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } },
                new Object1 { Id = ++id, Object2Id = ++id, Object2 = new Object2 { Id = ++id } }
            }
            .AsQueryable();

            return query;
        }
    }

    internal class Object1
    {
        public int Id { get; set; }
        public int Object2Id { get; set; }
        public Object2 Object2 { get; set; }
    }

    internal class Object2
    {
        public int Id { get; set; }
    }
}
