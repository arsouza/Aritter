using Aritter.Domain.Seedwork.Tests.ValueObjects.Mock;
using Xunit;

namespace Aritter.Domain.Seedwork.Tests.ValueObjects
{
    public class ValueObject_Equals
    {
        [Fact]
        public void ReturnFalseGivenNullObject()
        {
            ValueObject1 obj1 = new ValueObject1();
            object obj2 = null;

            bool areEquals = obj1.Equals(obj2);

            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenObjectWithSameReference()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            object obj2 = obj1;

            bool areEquals = obj1.Equals(obj2);

            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenOtherObjectType()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            object obj2 = "Test";

            bool areEquals = obj1.Equals(obj2);

            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenObjectAsValueObjectType()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            object obj2 = new ValueObject1 { Id = 2, Value = "value2" };

            bool areEquals = obj1.Equals(obj2);

            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenNullValueObject()
        {
            ValueObject1 obj1 = new ValueObject1();
            ValueObject1 obj2 = null;

            bool areEquals = obj1.Equals(obj2);

            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenValueObjectWithDifferentPropertyValues()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = new ValueObject1 { Id = 2, Value = "value1" };

            bool areEquals = obj1.Equals(obj2);

            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenValueObjectWithSameReference()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = obj1;

            bool areEquals = obj1.Equals(obj2);

            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenValueObjectWithoutProperties()
        {
            ValueObject2 obj1 = new ValueObject2();
            ValueObject2 obj2 = new ValueObject2();

            bool areEquals = obj1.Equals(obj2);

            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenValueObjectWithEqualsPropertyValues()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = new ValueObject1 { Id = 1, Value = "value" };

            bool areEquals = obj1.Equals(obj2);

            Assert.True(areEquals);
        }
    }
}