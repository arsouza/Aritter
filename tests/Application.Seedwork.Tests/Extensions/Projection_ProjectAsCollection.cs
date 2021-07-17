using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Ritter.Application.Extensions;
using Ritter.Infra.Crosscutting.Adapters;
using Xunit;

namespace Application.Seedwork.Tests.Extensions
{
    public class Projection_ProjectAsCollection
    {
        [Fact]
        public void AdaptCollectionGivenSourceAndTarget()
        {
            var mockAdapter = new Mock<ITypeAdapter>();
            mockAdapter.Setup(p => p.Adapt<List<TestMapClass>>(It.IsAny<IEnumerable<TestClass>>())).Returns(new List<TestMapClass> { new TestMapClass() });

            ICollection<TestMapClass> adapted = mockAdapter.Object.ProjectAsCollection<TestClass, TestMapClass>(It.IsAny<IEnumerable<TestClass>>());

            mockAdapter.Verify(x => x.Adapt<List<TestMapClass>>(It.IsAny<IEnumerable<TestClass>>()), Times.Once);
            adapted.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void AdaptCollectionGivenTarget()
        {
            var mockAdapter = new Mock<ITypeAdapter>();
            mockAdapter.Setup(p => p.Adapt<List<TestMapClass>>(It.IsAny<IEnumerable<TestClass>>())).Returns(new List<TestMapClass> { new TestMapClass() });

            ICollection<TestMapClass> adapted = mockAdapter.Object.ProjectAsCollection<TestMapClass>(It.IsAny<IEnumerable<TestClass>>());

            mockAdapter.Verify(x => x.Adapt<List<TestMapClass>>(It.IsAny<IEnumerable<TestClass>>()), Times.Once);
            adapted.Should().NotBeNullOrEmpty();
        }

        internal class TestClass
        {
            public string Test { get; set; }
        }

        internal class TestMapClass
        {
            public string Test { get; set; }
        }
    }
}
