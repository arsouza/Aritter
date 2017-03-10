using Aritter.Infra.Crosscutting.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aritter.Infra.Crosscutting.Tests.Logging
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void SetTypeAdpterFactorySuccessfully()
        {
            LoggerFactory.SetCurrent(new TestLoggerFactory());
            ILoggerFactory factory = LoggerFactory.Current();

            Assert.IsNotNull(factory);
            Assert.IsInstanceOfType(factory, typeof(TestLoggerFactory));

            ILogger logger = LoggerFactory.CreateLogger();

            Assert.IsNotNull(logger);
            Assert.IsInstanceOfType(logger, typeof(TestLogger));
        }
    }
}