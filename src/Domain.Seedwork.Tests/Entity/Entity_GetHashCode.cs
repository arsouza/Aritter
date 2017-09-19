using System;
using System.Collections.Generic;
using System.Text;
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
            Assert.InRange(hash, 1, int.MaxValue);
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
            Assert.Equal(newHash, currentHash);
        }

        [Fact]
        public void ReturnNewHashGivenTransient()
        {
            //Given
            EntityTest entity = new EntityTest(3);

            //When
            int newHash = entity.GetHashCode();

            //Then
            Assert.NotEqual(0, newHash);
            Assert.InRange(newHash, int.MinValue, int.MaxValue);
        }
    }
}
