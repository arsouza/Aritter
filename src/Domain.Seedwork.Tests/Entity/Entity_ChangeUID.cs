using Ritter.Domain.Seedwork.Tests.Mocks;
using System;
using Xunit;

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
            Assert.NotEqual(Guid.Empty, entity.UID);
            Assert.Equal(originalGuid, entity.UID);
            Assert.True(entity.IsTransient());
            Assert.Equal(0, entity.Id);
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
            Assert.NotEqual(Guid.Empty, entity.UID);
            Assert.Equal(newGuid, entity.UID);
            Assert.False(entity.IsTransient());
            Assert.Equal(3, entity.Id);
        }
    }
}
