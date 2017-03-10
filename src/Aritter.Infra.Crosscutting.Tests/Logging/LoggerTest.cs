using Aritter.Infra.Crosscutting.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aritter.Infra.Crosscutting.Tests.Logging
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void SetLoggerFactorySuccessfully()
        {
            LoggerFactory.SetCurrent(new TestLoggerFactory());
            ILoggerFactory factory = LoggerFactory.Current();

            Assert.IsNotNull(factory);
            Assert.IsInstanceOfType(factory, typeof(TestLoggerFactory));
        }

        [TestMethod]
        public void CreateLoggerSuccessfully()
        {
            LoggerFactory.SetCurrent(new TestLoggerFactory());
            ILoggerFactory factory = LoggerFactory.Current();

            Assert.IsNotNull(factory);
            Assert.IsInstanceOfType(factory, typeof(TestLoggerFactory));

            ILogger logger = LoggerFactory.CreateLogger();

            Assert.IsNotNull(logger);
            Assert.IsInstanceOfType(logger, typeof(TestLogger));
        }

        [TestMethod]
        public void CreateLoggerMustReturnNull()
        {
            LoggerFactory.SetCurrent(null);
            ILoggerFactory factory = LoggerFactory.Current();

            Assert.IsNull(factory);

            ILogger logger = LoggerFactory.CreateLogger();

            Assert.IsNull(logger);
        }
    }
}