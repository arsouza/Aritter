using FluentAssertions;
using Ritter.Domain.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Tests.Entity
{
    public class Entity_GetHashCode
    {
        [Fact]
        public void ReturnNewHashGivenTransient()
        {
            //Given
            IEntity entity = new EntityTest();

            //When
            int hash = entity.GetHashCode();

            //Then
            hash.Should().Equals(entity.Uid.GetHashCode() ^ 31);
        }

        [Fact]
        public void ReturnNewHashGivenIntransient()
        {
            //Given
            EntityTest entity = new EntityTest();

            //When
            int currentHash = entity.GetHashCode();
            entity.SetId(4);
            int newHash = entity.GetHashCode();

            //Then
            newHash.Should().NotBe(currentHash);
        }
    }
}