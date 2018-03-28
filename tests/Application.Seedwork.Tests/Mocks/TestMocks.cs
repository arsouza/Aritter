using Moq;
using Ritter.Infra.Crosscutting.Adapter;
using System.Collections.Generic;

namespace Application.Seedwork.Tests.Mocks
{
    internal class TestMocks
    {
        public static void MockTypeAdapter()
        {
            Mock<ITypeAdapter> mockTypeAdapter = new Mock<ITypeAdapter>();
            mockTypeAdapter.Setup(p => p.Adapt<ProjectionTest>(It.IsAny<EntityTest>())).Returns(new ProjectionTest { Id = 1 });
            mockTypeAdapter.Setup(p => p.Adapt<List<ProjectionTest>>(It.IsAny<IEnumerable<EntityTest>>())).Returns(new List<ProjectionTest> { new ProjectionTest { Id = 1 } });

            Mock<ITypeAdapterFactory> mockTypeAdapterFactory = new Mock<ITypeAdapterFactory>();
            mockTypeAdapterFactory.Setup(p => p.Create()).Returns(mockTypeAdapter.Object);

            TypeAdapterFactory.SetCurrent(mockTypeAdapterFactory.Object);
        }
    }
}
