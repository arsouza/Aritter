using Ritter.Domain.Seedwork.Tests.Mocks;
using System;
using Xunit;

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
            Assert.NotEqual(Guid.Empty, entity.UID);
            Assert.True(entity.IsTransient());
            Assert.Equal(0, entity.Id);
        }

        [Fact]
        public void ReturnEmptyGuidGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest(3);

            //Then
            Assert.NotEqual(Guid.Empty, entity.UID);
            Assert.False(entity.IsTransient());
            Assert.Equal(3, entity.Id);
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
            Assert.Equal(originalGuid, entity.UID);
            Assert.False(entity.IsTransient());
            Assert.Equal(3, entity.Id);
        }
    }
}
