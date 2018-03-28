using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Caching
{
    public class CachingProvider_RemoveItem
    {
        [Fact]
        public void RemoveAnObjectFromCache()
        {
            var cacheProvider = new TestCachingProvider();
            var obj = new TestObject1();

            cacheProvider.GetItem().Should().BeNull();
            cacheProvider.AddItem(obj);
            cacheProvider.GetItem().Should().Be(obj);

            cacheProvider.RemoveItem();
            cacheProvider.GetItem().Should().BeNull();
        }
    }
}
