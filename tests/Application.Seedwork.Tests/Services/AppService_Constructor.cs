using FluentAssertions;
using Xunit;

namespace Ritter.Application.Tests.Services
{
    public class AppService_Constructor
    {
        [Fact]
        public void CreateAnInstanceOfAppService()
        {
            TestAppService appService = new TestAppService();
            appService.Should().NotBeNull();
        }
    }
}
