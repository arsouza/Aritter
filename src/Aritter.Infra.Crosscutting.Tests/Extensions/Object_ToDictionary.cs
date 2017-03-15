using System.Collections.Generic;
using Aritter.Infra.Crosscutting.Extensions;
using Aritter.Infra.Crosscutting.Tests.Mock;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{

    public class Object_ToDictionary
    {
        [Fact]
        public void ReturnDictionaryGivenNotNullObject()
        {
            TestObject1 object1 = new TestObject1 { Id = 1 };
            IDictionary<string, object> dictionary = object1.ToDictionary();

            Assert.NotNull(dictionary);
            Assert.True(dictionary.ContainsKey("Id"));
            Assert.True(dictionary.ContainsKey("Value"));
            Assert.Equal(1, dictionary["Id"]);
            Assert.Null(dictionary["Value"]);
        }

        [Fact]
        public void ReturnEmptyGivenNullObject()
        {
            TestObject1 object1 = null;
            IDictionary<string, object> dictionary = object1.ToDictionary();

            Assert.NotNull(dictionary);
            Assert.Empty(dictionary);
            Assert.False(dictionary.ContainsKey("Id"));
            Assert.False(dictionary.ContainsKey("Value"));
        }

        [Fact]
        public void ReturnGenericDictonaryGivenNotNullObject()
        {
            TestObject1 object1 = new TestObject1 { Id = 1 };
            IDictionary<string, string> dictionary = object1.ToDictionary<string>();

            Assert.NotNull(dictionary);
            Assert.True(dictionary.ContainsKey("Id"));
            Assert.True(dictionary.ContainsKey("Value"));
            Assert.Equal("1", dictionary["Id"]);
            Assert.Null(dictionary["Value"]);
        }

        [Fact]
        public void ReturnEmptyGenericDictionaryGivenNullObject()
        {
            TestObject1 object1 = null;
            IDictionary<string, string> dictionary = object1.ToDictionary<string>();

            Assert.NotNull(dictionary);
            Assert.Empty(dictionary);
            Assert.False(dictionary.ContainsKey("Id"));
            Assert.False(dictionary.ContainsKey("Value"));
        }

        [Fact]
        public void ReturnDictionaryWithNullValuesGivenTypeMismatchObject()
        {
            TestObject1 object1 = new TestObject1 { Id = 1, Value = "Test" };
            IDictionary<string, int> dictionary = object1.ToDictionary<int>();

            Assert.NotNull(dictionary);
            Assert.True(dictionary.ContainsKey("Id"));
            Assert.True(dictionary.ContainsKey("Value"));
            Assert.Equal(1, dictionary["Id"]);
            Assert.Equal(0, dictionary["Value"]);
        }
    }
}