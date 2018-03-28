using Application.Seedwork.Tests.Mocks;
using FluentAssertions;
using Moq;
using Ritter.Application.Seedwork.Extensions;
using Xunit;

namespace Application.Seedwork.Tests.Extensions
{
    public class ProjectionsExtension_ProjectedAs
    {
        [Fact]
        public void ProjectValue()
        {
            TestMocks.MockTypeAdapter();

            var entity = new EntityTest(1);
            var projected = entity.ProjectedAs<ProjectionTest>();

            projected.Should().NotBeNull();
            projected.Id.Should().Be(1);
        }
    }
}
