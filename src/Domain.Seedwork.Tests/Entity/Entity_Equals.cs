using Xunit;

namespace Ritter.Domain.Seedwork.Tests.Entity
{
    public class Entity_Equals
    {
        [Fact]
        public void ReturnFalseGivenNotEntity()
        {
            //Given
            IEntity entity = new EntityTest(3);
            object obj = new object();

            //When
            bool areEquals = entity.Equals(obj);

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenSameReference()
        {
            //Given
            IEntity entity1 = new EntityTest(3);
            IEntity entity2 = entity1;

            //When
            bool areEquals = entity1.Equals(entity2);

            //Then
            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenLeftTransient()
        {
            //Given
            IEntity entity1 = new EntityTest();
            IEntity entity2 = new EntityTest(3);

            //When
            bool areEquals = entity1.Equals(entity2);

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenRightTransient()
        {
            //Given
            IEntity entity1 = new EntityTest(3);
            IEntity entity2 = new EntityTest();

            //When
            bool areEquals = entity1.Equals(entity2);

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenBothNotTransient()
        {
            //Given
            IEntity entity1 = new EntityTest(3);
            IEntity entity2 = new EntityTest(3);

            //When
            bool areEquals = entity1.Equals(entity2);

            //Then
            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenBothNotTransient()
        {
            //Given
            IEntity entity1 = new EntityTest(3);
            IEntity entity2 = new EntityTest(4);

            //When
            bool areEquals = entity1.Equals(entity2);

            //Then
            Assert.False(areEquals);
        }

        [Fact]
        public void ReturnTrueGivenBothTransient()
        {
            //Given
            EntityTest entity1 = new EntityTest();
            EntityTest entity2 = entity1.Clone();

            //When
            bool areEquals = entity1.Equals(entity2);

            //Then
            Assert.True(areEquals);
        }

        [Fact]
        public void ReturnFalseGivenBothTransient()
        {
            //Given
            IEntity entity1 = new EntityTest();
            IEntity entity2 = new EntityTest();

            //When
            bool areEquals = entity1.Equals(entity2);

            //Then
            Assert.False(areEquals);
        }
    }
}
