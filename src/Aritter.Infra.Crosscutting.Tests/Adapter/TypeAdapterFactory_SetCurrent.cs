using Aritter.Infra.Crosscutting.Adapter;
using Moq;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Adapter
{
    public class TypeAdapterFactory_SetCurrent
    {
        [Fact]
        public void NotThrowExceptionGivenAnyTypeAdapterFactory()
        {
            Mock<ITypeAdapterFactory> moqTypeAdapterFactory = new Mock<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(moqTypeAdapterFactory.Object);
        }

        [Fact]
        public void NotThrowExceptionGivenNull()
        {
            TypeAdapterFactory.SetCurrent(null);
        }
    }
}