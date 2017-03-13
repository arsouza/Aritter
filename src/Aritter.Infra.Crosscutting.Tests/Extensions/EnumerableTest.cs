using Aritter.Infra.Crosscutting.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Aritter.Infra.Crosscutting.Extensions;
using System.Linq;
using System;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class EnumerableTest
    {
        [TestMethod]
        public void CallForEachMustExecuteSuccessfully()
        {
            IEnumerable<TestObject1> source = new List<TestObject1>
            {
                new TestObject1 { Id = 1 },
                new TestObject1 { Id = 2 }
            };

            source.ForEach(p =>
            {
                p.Value = p.Id.ToString();
            });

            Assert.IsNotNull(source);
            Assert.AreEqual("1", source.ElementAt(0).Value);
            Assert.AreEqual("2", source.ElementAt(1).Value);
        }

        [TestMethod]
        public void CallForEachWithNullSourceMustThrowsArgumentNullException()
        {
            IEnumerable<TestObject1> source = null;

            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                source.ForEach(p =>
                {
                    p.Value = p.Id.ToString();
                });
            });
            
            Assert.AreEqual("source", exception.ParamName);
        }

        [TestMethod]
        public void CallForEachWithNullActionMustThrowsArgumentNullException()
        {
            IEnumerable<TestObject1> source = new List<TestObject1>();

            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                source.ForEach(null);
            });
            
            Assert.AreEqual("action", exception.ParamName);
        }
    }
}