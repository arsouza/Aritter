using FluentAssertions;
using Ritter.Domain.Seedwork.Tests.ValueObject.Mocks;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.ValueObject
{
    public class ValueObject_Equals
    {
        [Fact]
        public void ReturnFalseGivenNullObject()
        {
            ValueObject1 obj1 = new ValueObject1();
            object obj2 = null;

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeFalse();
        }

        [Fact]
        public void ReturnTrueGivenObjectWithSameReference()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            object obj2 = obj1;

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeTrue();
        }

        [Fact]
        public void ReturnFalseGivenOtherObjectType()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            object obj2 = "Test";

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseGivenOtherPropertyType()
        {
            ValueObject3 obj1 = new ValueObject3 { Id = 1, Value = "value", ValueObject = new ValueObject3() };
            ValueObject3 obj2 = new ValueObject3 { Id = 1, Value = "value", ValueObject = new ValueObject3() };

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseGivenObjectAsValueObjectType()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            object obj2 = new ValueObject1 { Id = 2, Value = "value2" };

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseGivenNullValueObject()
        {
            ValueObject1 obj1 = new ValueObject1();
            ValueObject1 obj2 = null;

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseGivenValueObjectWithDifferentPropertyValues()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = new ValueObject1 { Id = 2, Value = "value1" };

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeFalse();
        }

        [Fact]
        public void ReturnTrueGivenValueObjectWithSameReference()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = obj1;

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeTrue();
        }

        [Fact]
        public void ReturnTrueGivenValueObjectWithoutProperties()
        {
            ValueObject2 obj1 = new ValueObject2();
            ValueObject2 obj2 = new ValueObject2();

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeTrue();
        }

        [Fact]
        public void ReturnTrueGivenValueObjectWithEqualsPropertyValues()
        {
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = new ValueObject1 { Id = 1, Value = "value" };

            bool areEquals = obj1.Equals(obj2);

            areEquals.Should().BeTrue();
        }
    }
}
