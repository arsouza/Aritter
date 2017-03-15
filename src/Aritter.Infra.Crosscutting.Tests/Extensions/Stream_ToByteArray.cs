using Aritter.Infra.Crosscutting.Extensions;
using System;
using System.IO;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{

    public class Stream_ToByteArray
    {
        [Fact]
        public void ReturnValidByteArrayGivenNotNullStream()
        {
            using (var stream = new MemoryStream())
            {
                byte[] byteArray = stream.ToByteArray();

                Assert.NotNull(byteArray);
                Assert.Equal(0, byteArray.Length);
            }
        }

        [Fact]
        public void ThrowExceptionGivenNullStream()
        {
            MemoryStream stream = null;

            NullReferenceException exception = Assert.Throws<NullReferenceException>(() =>
            {
                byte[] byteArray = stream.ToByteArray();
            });
        }
    }
}
