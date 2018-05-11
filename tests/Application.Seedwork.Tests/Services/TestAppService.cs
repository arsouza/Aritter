using Microsoft.Extensions.Logging;
using Ritter.Application.Services;

namespace Ritter.Application.Tests.Services
{
    internal class TestAppService : AppService
    {
        public TestAppService(ILogger logger)
            : base(logger)
        {
        }
    }
}
