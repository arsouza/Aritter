using System.Collections.Generic;
using Aritter.Infra.Crosscutting.Extensions;
using Aritter.Infra.Crosscutting.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class ObjectTest
    {
        [TestMethod]
        public void CallToDictionaryMustReturnSuccess()
        {
            TestObject1 object1 = new TestObject1 { Id = 1 };
            IDictionary<string, object> dictionary = object1.ToDictionary();

            Assert.IsNotNull(dictionary);
            Assert.IsTrue(dictionary.ContainsKey("Id"));
            Assert.IsTrue(dictionary.ContainsKey("Value"));
            Assert.AreEqual(1, dictionary["Id"]);
            Assert.IsNull(dictionary["Value"]);
        }

        [TestMethod]
        public void CallToDictionarySendNullMustReturnEmptyDictionary()
        {
            TestObject1 object1 = null;
            IDictionary<string, object> dictionary = object1.ToDictionary();

            Assert.IsNotNull(dictionary);
            Assert.AreEqual(0, dictionary.Count);
            Assert.IsFalse(dictionary.ContainsKey("Id"));
            Assert.IsFalse(dictionary.ContainsKey("Value"));
        }

        [TestMethod]
        public void CallToDictionaryLikeGenericsMustReturnSuccess()
        {
            TestObject1 object1 = new TestObject1 { Id = 1 };
            IDictionary<string, string> dictionary = object1.ToDictionary<string>();

            Assert.IsNotNull(dictionary);
            Assert.IsTrue(dictionary.ContainsKey("Id"));
            Assert.IsTrue(dictionary.ContainsKey("Value"));
            Assert.AreEqual("1", dictionary["Id"]);
            Assert.IsNull(dictionary["Value"]);
        }

        [TestMethod]
        public void CallToDictionaryyLikeGenericsSendNullMustReturnEmptyDictionary()
        {
            TestObject1 object1 = null;
            IDictionary<string, string> dictionary = object1.ToDictionary<string>();

            Assert.IsNotNull(dictionary);
            Assert.AreEqual(0, dictionary.Count);
            Assert.IsFalse(dictionary.ContainsKey("Id"));
            Assert.IsFalse(dictionary.ContainsKey("Value"));
        }

        [TestMethod]
        public void CallToDictionaryOfInvalidTypesMustReturnSuccessWithNullValues()
        {
            TestObject1 object1 = new TestObject1 { Id = 1, Value = "Test" };
            IDictionary<string, int> dictionary = object1.ToDictionary<int>();

            Assert.IsNotNull(dictionary);
            Assert.IsTrue(dictionary.ContainsKey("Id"));
            Assert.IsTrue(dictionary.ContainsKey("Value"));
            Assert.AreEqual(1, dictionary["Id"]);
            Assert.AreEqual(0, dictionary["Value"]);
        }
    }
}