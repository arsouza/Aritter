using Ritter.Infra.Crosscutting.Caching;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;

namespace Ritter.Infra.Crosscutting.Tests.Caching
{
    internal class TestCachingProvider : CacheProvider
    {
        public void AddItem(TestObject1 value)
        {
            base.AddItem(value.GetType().Name, value);
        }

        public TestObject1 GetItem()
        {
            return base.GetItem(typeof(TestObject1).Name) as TestObject1;
        }

        public TestObject1 GetItemThenRemove()
        {
            return base.GetItem(typeof(TestObject1).Name, true) as TestObject1;
        }

        public void RemoveItem()
        {
            base.RemoveItem(typeof(TestObject1).Name);
        }
    }
}
