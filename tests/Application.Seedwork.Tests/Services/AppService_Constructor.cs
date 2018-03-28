using FluentAssertions;

namespace Application.Seedwork.Tests.Services
{
    public class AppService_Constructor
    {
        public void CreateAnInstanceOfAppService()
        {
            var appService = new TestAppService(null);
            appService.Should().NotBeNull();
        }
    }
}
