using FluentAssertions;
using Ritter.Domain.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Tests.Entity
{
    public class Entity_InequalityOperator
    {
        [Fact]
        public void ReturnTrueGivenNotNullObjects()
        {
            //Given
            EntityTest obj1 = new EntityTest(3);
            EntityTest obj2 = new EntityTest(4);

            //When
            bool areEquals = obj1 != obj2;

            //Then
            areEquals.Should().BeTrue();
        }

        [Fact]
        public void ReturnFalseGivenNotNullObjects()
        {
            //Given
            EntityTest obj1 = new EntityTest(3);
            EntityTest obj2 = new EntityTest(3);

            //When
            bool areEquals = obj1 != obj2;

            //Then
            areEquals.Should().BeFalse();
        }

        [Fact]
        public void ReturnTrueGivenNullLeftObjects()
        {
            //Given
            EntityTest obj1 = null;
            EntityTest obj2 = new EntityTest(3);

            //When
            bool areEquals = obj1 != obj2;

            //Then
            areEquals.Should().BeTrue();
        }

        [Fact]
        public void ReturnTrueGivenNullRightObjects()
        {
            //Given
            EntityTest obj1 = new EntityTest(3);
            EntityTest obj2 = null;

            //When
            bool areEquals = obj1 != obj2;

            //Then
            areEquals.Should().BeTrue();
        }

        [Fact]
        public void ReturnFalseGivenNullBothObjects()
        {
            //Given
            EntityTest obj1 = null;
            EntityTest obj2 = null;

            //When
            bool areEquals = obj1 != obj2;

            //Then
            areEquals.Should().BeFalse();
        }
    }
}
