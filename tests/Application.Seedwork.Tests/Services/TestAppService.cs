using Microsoft.Extensions.Logging;
using Ritter.Application.Services;
using Ritter.Infra.Crosscutting.TypeAdapter;

namespace Ritter.Application.Tests.Services
{
    internal class TestAppService : AppService
    {
        public TestAppService(ITypeAdapter adapter, ILogger logger)
            : base(adapter, logger)
        {
        }
    }
}
