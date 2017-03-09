using Aritter.Infra.Crosscutting.Adapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aritter.Infra.Crosscutting.Tests.Adapter
{
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        public void SetTypeAdpterFactorySuccessfully()
        {
            TypeAdapterFactory.SetCurrent(new TestTypeAdapterFactory());

            ITypeAdapter typeAdapter = TypeAdapterFactory.CreateAdapter();

            Assert.IsNotNull(typeAdapter);
            Assert.IsInstanceOfType(typeAdapter, typeof(TestTypeAdapter));
        }

        [TestMethod]
        public void AdaptTypedTargetSuccessfully()
        {
            TypeAdapterFactory.SetCurrent(new TestTypeAdapterFactory());
            ITypeAdapter typeAdapter = TypeAdapterFactory.CreateAdapter();

            Assert.IsNotNull(typeAdapter);
            Assert.IsInstanceOfType(typeAdapter, typeof(TestTypeAdapter));

            TestObject1 obj1 = new TestObject1 { Value = "Teste" };
            TestObject2 obj2 = typeAdapter.Adapt<TestObject1, TestObject2>(obj1);

            Assert.IsNotNull(obj2);
            Assert.IsInstanceOfType(obj2, typeof(TestObject2));
            Assert.AreEqual(obj1.Value, obj2.Value);
        }

        [TestMethod]
        public void AdaptObjectSuccessfully()
        {
            TypeAdapterFactory.SetCurrent(new TestTypeAdapterFactory());
            ITypeAdapter typeAdapter = TypeAdapterFactory.CreateAdapter();

            Assert.IsNotNull(typeAdapter);
            Assert.IsInstanceOfType(typeAdapter, typeof(TestTypeAdapter));

            TestObject1 obj1 = new TestObject1 { Value = "Teste" };
            TestObject2 obj2 = typeAdapter.Adapt<TestObject2>(obj1);

            Assert.IsNotNull(obj2);
            Assert.IsInstanceOfType(obj2, typeof(TestObject2));
            Assert.AreEqual(obj1.Value, obj2.Value);
        }
    }
}