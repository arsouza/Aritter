using FluentAssertions;
using Ritter.Domain.Tests.Mocks;
using Xunit;

namespace Ritter.Domain.Tests.Entity
{
    public class Entity_IsTransient
    {
        [Fact]
        public void ReturnFalseGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest(3);

            //When
            bool isTransient = entity.IsTransient();

            //Then
            isTransient.Should().BeFalse();
            entity.Id.Should().Be(3);
        }

        [Fact]
        public void ReturnTrueGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest();

            //When
            bool isTransient = entity.IsTransient();

            //Then
            isTransient.Should().BeTrue();
            entity.Id.Should().Be(0);
        }
    }
}
