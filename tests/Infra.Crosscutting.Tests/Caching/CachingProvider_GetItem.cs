using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Caching
{
    public class CachingProvider_GetItem
    {
        [Fact]
        public void GetAnObjectFromCache()
        {
            var cacheProvider = new TestCachingProvider();
            var obj = new TestObject1();

            cacheProvider.GetItem().Should().BeNull();
            cacheProvider.AddItem(obj);

            cacheProvider.GetItem().Should().Be(obj);
        }

        [Fact]
        public void GetAnObjectFromCacheThenRemove()
        {
            var cacheProvider = new TestCachingProvider();
            var obj = new TestObject1();

            cacheProvider.GetItem().Should().BeNull();
            cacheProvider.AddItem(obj);
            cacheProvider.GetItemThenRemove().Should().Be(obj);

            cacheProvider.GetItem().Should().BeNull();
        }
    }
}
