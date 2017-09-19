using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Entity
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
            Assert.False(isTransient);
            Assert.Equal(3, entity.Id);
        }

        [Fact]
        public void ReturnTrueGivenNewEntity()
        {
            //Given
            IEntity entity = new EntityTest();

            //When
            bool isTransient = entity.IsTransient();

            //Then
            Assert.True(isTransient);
            Assert.Equal(0, entity.Id);
        }
    }
}
