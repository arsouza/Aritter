using FluentAssertions;
using Ritter.Application.Services;
using Xunit;

namespace Ritter.Application.Tests.Services
{
    public class AppService_Constructor
    {
        [Fact]
        public void CreateAnInstanceOfAppService()
        {
            var appService = new TestAppService();
            appService.Should().NotBeNull();
        }

        public class TestAppService : AppService
        {
            public TestAppService() : base()
            {
            }
        }
    }
}
