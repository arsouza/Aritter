using Aritter.Infra.Crosscutting.Logging;
using Moq;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Logging
{
    
    public class Logger_SetCurrent
    {
        [Fact]
        public void NotThrowExceptionGivenAnyLoggerFactory()
        {
            Mock<ILoggerFactory> moqLoggerFactory = new Mock<ILoggerFactory>();
            LoggerFactory.SetCurrent(moqLoggerFactory.Object);
        }

        [Fact]
        public void NotThrowExceptionGivenNull()
        {
            LoggerFactory.SetCurrent(null);
        }
    }
}