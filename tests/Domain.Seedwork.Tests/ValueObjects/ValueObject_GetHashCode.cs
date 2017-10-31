using FluentAssertions;
using Ritter.Domain.Seedwork.Tests.ValueObjects.Mocks;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.ValueObjects
{
    public class ValueObject_GetHashCode
    {
        [Fact]
        public void GetHashGivenObjectWithNotNullProperties()
        {
            //Given
            ValueObject1 obj1 = new ValueObject1()
            {
                Id = 1,
                Value = "test"
            };

            //When
            int hash = obj1.GetHashCode();

            //Then
            hash.Should().NotBe(0);
        }

        [Fact]
        public void GetHashGivenObjectWithNullProperties()
        {
            //Given
            ValueObject1 obj1 = new ValueObject1()
            {
                Id = 1,
                Value = null
            };

            //When
            int hash = obj1.GetHashCode();

            //Then
            hash.Should().NotBe(0);
        }

        [Fact]
        public void GetHashGivenObjectWithoutProperties()
        {
            //Given
            ValueObject2 obj1 = new ValueObject2();

            //When
            int hash = obj1.GetHashCode();

            //Then
            hash.Should().NotBe(0);
        }
    }
}
