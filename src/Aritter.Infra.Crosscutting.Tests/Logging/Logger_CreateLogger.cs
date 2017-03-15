using Aritter.Infra.Crosscutting.Logging;
using Moq;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Logging
{
    public class Logger_CreateLogger
    {
        [Fact]
        public void ReturnAnyLoggerGivenAnyLoggerFactory()
        {
            Mock<ILogger> moqLogger = new Mock<ILogger>();

            Mock<ILoggerFactory> moqLoggerFactory = new Mock<ILoggerFactory>();
            moqLoggerFactory.Setup(p => p.Create()).Returns(moqLogger.Object);

            LoggerFactory.SetCurrent(moqLoggerFactory.Object);
            ILogger logger = LoggerFactory.CreateLogger();

            Assert.NotNull(logger);
            Assert.Equal(logger, moqLogger.Object);
        }

        [Fact]
        public void CallGivenNull()
        {
            LoggerFactory.SetCurrent(null);
            ILogger logger = LoggerFactory.CreateLogger();

            Assert.Null(logger);
        }
    }
}
