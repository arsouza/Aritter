using Ritter.Domain.Seedwork.Tests.Mocks;
using System;
using Xunit;
using FluentAssertions;

namespace Ritter.Domain.Seedwork.Tests.Entity
{
    public class Entity_ChangeUID
    {
        [Fact]
        public void ReturnOriginalGuidGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest();
            Guid originalGuid = entity.UID;
            Guid newGuid = Guid.NewGuid();

            //When
            entity.ChangeUID(newGuid);

            //Then
            entity.UID.Should().Be(originalGuid);
            entity.Id.Should().Be(0);
            entity.IsTransient().Should().BeTrue();
        }

        [Fact]
        public void ReturnNewGuidGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest(3);
            Guid originalGuid = entity.UID;
            Guid newGuid = Guid.NewGuid();

            //When
            entity.ChangeUID(newGuid);

            //Then
            entity.UID.Should().Be(newGuid);
            entity.Id.Should().Be(3);
            entity.IsTransient().Should().BeFalse();
        }
    }
}
