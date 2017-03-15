using Aritter.Infra.Crosscutting.Extensions;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    public class String_IsValidMailAddress
    {
        [Fact]
        public void ReturnFalseGivenNull()
        {
            string mailAddress = null;
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            Assert.False(isValidMailAddress);
        }

        [Fact]
        public void ReturnFalseGivenEmpty()
        {
            string mailAddress = "";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            Assert.False(isValidMailAddress);
        }

        [Fact]
        public void ReturnFalseGivenInvalidMailAddress()
        {
            string mailAddress = "test@ff";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            Assert.False(isValidMailAddress);
        }

        [Fact]
        public void ReturnTrueGivenValidMailAddress()
        {
            string mailAddress = "test@ff.com";
            bool isValidMailAddress = mailAddress.IsValidMailAddress();

            Assert.True(isValidMailAddress);
        }
    }
}
