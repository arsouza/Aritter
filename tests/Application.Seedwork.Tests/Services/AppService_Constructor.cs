using FluentAssertions;
using Xunit;

namespace Ritter.Application.Tests.Services
{
    public class AppService_Constructor
    {
        [Fact]
        public void CreateAnInstanceOfAppService()
        {
            var appService = new TestAppService(null);
            appService.Should().NotBeNull();
        }
    }
}
