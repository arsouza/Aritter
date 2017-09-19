using Xunit;

namespace Ritter.Domain.Seedwork.Tests.ValueObject
{
    public class Entity_EqualityOperator
    {
        [Fact]
        public void ReturnFalseGivenNotNullObjects()
        {
            //Given
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = new ValueObject1 { Id = 2, Value = "value1" };

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenNotNullObjects()
        {
            //Given
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = new ValueObject1 { Id = 1, Value = "value" };

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenNullLeftObjects()
        {
            //Given
            ValueObject1 obj1 = null;
            ValueObject1 obj2 = new ValueObject1 { Id = 2, Value = "value1" };

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenNullRightObjects()
        {
            //Given
            ValueObject1 obj1 = new ValueObject1 { Id = 1, Value = "value" };
            ValueObject1 obj2 = null;

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenNullBothObjects()
        {
            //Given
            ValueObject1 obj1 = null;
            ValueObject1 obj2 = null;

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.True(areEquals);
        }
    }
}
