using FluentAssertions;
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
            Mock<ITypeAdapter> mockTypeAdapter = new Mock<ITypeAdapter>();

            Mock<ITypeAdapterFactory> mockTypeAdapterFactory = new Mock<ITypeAdapterFactory>();
            mockTypeAdapterFactory.Setup(p => p.Create()).Returns(mockTypeAdapter.Object);

            TypeAdapterFactory.SetCurrent(mockTypeAdapterFactory.Object);
            ITypeAdapter typeAdapter = TypeAdapterFactory.CreateAdapter();

            typeAdapter.Should().NotBeNull().And.Be(mockTypeAdapter.Object);
        }

        [Fact]
        public void NotThrowExceptionGivenNull()
        {
            TypeAdapterFactory.SetCurrent(null);
            ITypeAdapter typeAdapter = TypeAdapterFactory.CreateAdapter();

            typeAdapter.Should().BeNull();
        }
    }
}
