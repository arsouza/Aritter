using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Caching
{
    public class CachingProvider_AddItem
    {
        [Fact]
        public void AddAnObjectToCache()
        {
            var cacheProvider = new TestCachingProvider();
            var obj = new TestObject1();

            cacheProvider.GetItem().Should().BeNull();
            cacheProvider.AddItem(obj);

            cacheProvider.GetItem().Should().Be(obj);
        }

        [Fact]
        public void ThrowNullReferenceExceptionGivenNullObject()
        {
            var cacheProvider = new TestCachingProvider();
            TestObject1 obj = null;

            cacheProvider.GetItem().Should().BeNull();
            Action act = () => cacheProvider.AddItem(obj);

            act.Should().Throw<NullReferenceException>();
        }
    }
}
