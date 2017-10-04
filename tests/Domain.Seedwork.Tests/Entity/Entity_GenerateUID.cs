using Ritter.Domain.Seedwork.Tests.Mocks;
using System;
using Xunit;
using FluentAssertions;

namespace Ritter.Domain.Seedwork.Tests.Entity
{
    public class Entity_GenerateUID
    {
        [Fact]
        public void ReturnValidGuidGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest();

            //Then
            entity.UID.Should().NotBeEmpty();
            entity.IsTransient().Should().BeTrue();
            entity.Id.Should().Be(0);
        }

        [Fact]
        public void ReturnEmptyGuidGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest(3);

            //Then
            entity.UID.Should().NotBeEmpty();
            entity.IsTransient().Should().BeFalse();
            entity.Id.Should().Be(3);
        }

        [Fact]
        public void ReturnOriginalGuidGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest(3);
            Guid originalGuid = entity.UID;

            //When
            entity.GenerateUID();

            //Then
            entity.UID.Should().Be(originalGuid);
            entity.IsTransient().Should().BeFalse();
            entity.Id.Should().Be(3);
        }
    }
}
