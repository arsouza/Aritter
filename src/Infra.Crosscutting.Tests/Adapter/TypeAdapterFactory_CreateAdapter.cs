using Moq;
using Ritter.Infra.Crosscutting.Adapter;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Adapter
{
    public class TypeAdapterFactory_CreateAdapter
    {
        [Fact]
        public void ReturnAnyTypeAdapterGivenAnyTypeAdapterFactory()
        {
            Mock<ITypeAdapter> moqTypeAdapter = new Mock<ITypeAdapter>();

            Mock<ITypeAdapterFactory> moqTypeAdapterFactory = new Mock<ITypeAdapterFactory>();
            moqTypeAdapterFactory.Setup(p => p.Create()).Returns(moqTypeAdapter.Object);

            TypeAdapterFactory.SetCurrent(moqTypeAdapterFactory.Object);
            ITypeAdapter typeAdapter = TypeAdapterFactory.CreateAdapter();

            Assert.NotNull(typeAdapter);
            Assert.Equal(typeAdapter, moqTypeAdapter.Object);
        }

        [Fact]
        public void NotThrowExceptionGivenNull()
        {
            TypeAdapterFactory.SetCurrent(null);
            ITypeAdapter typeAdapter = TypeAdapterFactory.CreateAdapter();

            Assert.Null(typeAdapter);
        }
    }
}
