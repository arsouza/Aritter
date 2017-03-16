using Aritter.Domain.Seedwork.Tests.ValueObjects.Mock;
using Xunit;

namespace Aritter.Domain.Seedwork.Tests.ValueObjects
{
    public class ValueObject_GetHashCode
    {
        [Fact]
        public void GetHashGivenObjectWithNotNullProperties()
        {
            //Given
            ValueObject1 obj1 = new ValueObject1();
            obj1.Id = 1;
            obj1.Value = "test";

            //When
            int hash = obj1.GetHashCode();

            //Then
            Assert.NotEqual(0, hash);
        }

        [Fact]
        public void GetHashGivenObjectWithNullProperties()
        {
            //Given
            ValueObject1 obj1 = new ValueObject1();
            obj1.Id = 1;
            obj1.Value = null;

            //When
            int hash = obj1.GetHashCode();

            //Then
            Assert.NotEqual(0, hash);
        }

        [Fact]
        public void GetHashGivenObjectWithoutProperties()
        {
            //Given
            ValueObject2 obj1 = new ValueObject2();

            //When
            int hash = obj1.GetHashCode();

            //Then
            Assert.NotEqual(0, hash);
        }
    }
}