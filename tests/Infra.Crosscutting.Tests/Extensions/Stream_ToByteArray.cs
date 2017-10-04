using FluentAssertions;
using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.IO;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Stream_ToByteArray
    {
        [Fact]
        public void ReturnValidByteArrayGivenNotNullStream()
        {
            using (var stream = new MemoryStream())
            {
                byte[] byteArray = stream.ToByteArray();

                byteArray.Should().NotBeNull();
                byteArray.Length.Should().Be(0);
            }
        }

        [Fact]
        public void ThrowExceptionGivenNullStream()
        {
            Action act = () =>
            {
                MemoryStream stream = null;
                byte[] byteArray = stream.ToByteArray();
            };

            act.ShouldThrow<NullReferenceException>();
        }
    }
}
