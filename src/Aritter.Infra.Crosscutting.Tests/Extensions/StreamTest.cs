using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class StreamTest
    {
        [TestMethod]
        public void CallToByteArrayMustReturnByteArray()
        {
            using (var stream = new MemoryStream())
            {
                byte[] byteArray = stream.ToByteArray();

                Assert.IsNotNull(byteArray);
                Assert.AreEqual(0, byteArray.Length);
            }
        }

        [TestMethod]
        public void CallToByteArrayMustReturnError()
        {
            MemoryStream stream = null;

            NullReferenceException exception = Assert.ThrowsException<NullReferenceException>(() =>
            {
                byte[] byteArray = stream.ToByteArray();
            });
        }
    }
}
