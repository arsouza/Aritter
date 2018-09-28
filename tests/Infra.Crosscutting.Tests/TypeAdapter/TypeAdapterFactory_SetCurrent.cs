using FluentAssertions;
using Moq;
using Ritter.Infra.Crosscutting.TypeAdapter;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.TypeAdapter
{
    public class TypeAdapterFactory_SetCurrent
    {
        [Fact]
        public void SetCurrentAdapterGivenAnValidFactory()
        {
            Mock<ITypeAdapterFactory> factoryMock = new Mock<ITypeAdapterFactory>();
            Mock<ITypeAdapter> adapterMock = new Mock<ITypeAdapter>();

            factoryMock
                .Setup(p => p.Create())
                .Returns(adapterMock.Object);

            TypeAdapterFactory.SetCurrent(factoryMock.Object);
            var adapter = TypeAdapterFactory.CreateAdapter();

            factoryMock.Verify(x => x.Create(), Times.Once);

            adapter.Should().NotBeNull().And.Be(adapterMock.Object);
        }

        [Fact]
        public void ThrowExceptionGivenNullFactory()
        {
            Action act = () =>
            {
                TypeAdapterFactory.SetCurrent(null);
            };

            act.Should().Throw<NullReferenceException>()
                .And.Message.Should().Be($"The value of typeAdapterFactory cannot be null.");
        }
    }
}
