using Moq;
using Ritter.Infra.Crosscutting.Adapter;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Adapter
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
