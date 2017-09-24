using FluentAssertions;
using Ritter.Domain.Seedwork.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Entity
{
    public class Entity_GetHashCode
    {
        [Fact]
        public void ReturnNewHashGivenIntransient()
        {
            //Given
            IEntity entity = new EntityTest();

            //When
            int hash = entity.GetHashCode();

            //Then
            hash.Should().BeGreaterThan(1);
        }

        [Fact]
        public void ReturnCurrentHashGivenIntransient()
        {
            //Given
            EntityTest entity = new EntityTest();

            //When
            int newHash = entity.GetHashCode();
            entity.SetId(4);
            int currentHash = entity.GetHashCode();

            //Then
            newHash.Should().Be(currentHash);
        }

        [Fact]
        public void ReturnNewHashGivenTransient()
        {
            //Given
            EntityTest entity = new EntityTest(3);

            //When
            int newHash = entity.GetHashCode();

            //Then
            newHash.Should().NotBe(0).And.BeInRange(int.MinValue, int.MaxValue);
        }
    }
}
