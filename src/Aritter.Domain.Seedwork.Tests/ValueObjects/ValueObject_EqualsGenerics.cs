using Aritter.Domain.Seedwork.Tests.ValueObjects.Mock;
using Xunit;

namespace Aritter.Domain.Seedwork.Tests.ValueObjects
{
    public class ValueObject_EqualsGenerics
    {
        [Fact]
        public void ReturnFalseGivenNull()
        {
            ValueObject1 obj1 = new ValueObject1();
            ValueObject1 obj2 = null;

            bool areEquals = obj1.Equals(obj2);

            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenWithDifferentPropertyValues()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = new ValueObject1 { Id = 2, Value = "value1" };

            bool areEquals = obj1.Equals(obj2);

            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenWithSameReference()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = obj1;

            bool areEquals = obj1.Equals(obj2);

            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenWithEqualsPropertyValues()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = new ValueObject1 { Id = 1, Value = "value" };

            bool areEquals = obj1.Equals(obj2);

            Assert.True(areEquals);
        }
    }
}
