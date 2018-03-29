using Application.Seedwork.Tests.Mocks;
using FluentAssertions;
using Ritter.Application.Seedwork.Extensions;
using System.Collections.Generic;
using Xunit;

namespace Application.Seedwork.Tests.Extensions
{
    public class ProjectionsExtension_ProjectedAsCollecttion
    {
        [Fact]
        public void ProjectCollection()
        {
            TestMocks.MockTypeAdapter();
            var entities = new List<EntityTest> { new EntityTest(1) };

            var projected = entities.ProjectedAsCollection<ProjectionTest>();

            projected.Should().NotBeNullOrEmpty();
            projected[0].Id.Should().Be(1);
        }
    }
}
