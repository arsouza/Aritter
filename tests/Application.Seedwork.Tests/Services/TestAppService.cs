using Microsoft.Extensions.Logging;
using Ritter.Application.Seedwork.Services;

namespace Application.Seedwork.Tests.Services
{
    internal class TestAppService : AppService
    {
        public TestAppService(ILogger logger) : base(logger)
        {
        }
    }
}
