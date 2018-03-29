using FluentAssertions;
using Xunit;

namespace Application.Seedwork.Tests.Services
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
