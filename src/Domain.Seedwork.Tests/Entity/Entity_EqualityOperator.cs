using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Entity
{
    public class Entity_EqualityOperator
    {
        [Fact]
        public void ReturnFalseGivenNotNullObjects()
        {
            //Given
            EntityTest obj1 = new EntityTest(3);
            EntityTest obj2 = new EntityTest(4);

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenNotNullObjects()
        {
            //Given
            EntityTest obj1 = new EntityTest(3);
            EntityTest obj2 = new EntityTest(3);

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenNullLeftObjects()
        {
            //Given
            EntityTest obj1 = null;
            EntityTest obj2 = new EntityTest(3);

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenNullRightObjects()
        {
            //Given
            EntityTest obj1 = new EntityTest(3);
            EntityTest obj2 = null;

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenNullBothObjects()
        {
            //Given
            EntityTest obj1 = null;
            EntityTest obj2 = null;

            //When
            bool areEquals = obj1 == obj2;

            //Then
            Assert.True(areEquals);
        }
    }
}
