using FluentAssertions;
using Ritter.Infra.Crosscutting.Extensions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class String_IsValidMailAddress
    {
        [Fact]
        public void ReturnFalseGivenNull()
        {
            string mailAddress = null;
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            isValidMailAddress.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseGivenEmpty()
        {
            string mailAddress = "";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            isValidMailAddress.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseGivenInvalidMailAddress()
        {
            string mailAddress = "test@ff";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            isValidMailAddress.Should().BeFalse();
        }

        [Fact]
        public void ReturnTrueGivenValidMailAddress()
        {
            string mailAddress = "test@ff.com";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            isValidMailAddress.Should().BeTrue();
        }
    }
}
