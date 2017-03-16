using Aritter.Infra.Crosscutting.Encryption;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests
{

    public class Encrypter_Encrypt
    {
        [Fact]
        public void ReturnEncryptedGivenAnyString()
        {
            string value = "VALUE_TO_ENCRYPT";

            string encrytedValue = Encrypter.Encrypt(value);
            Assert.NotNull(encrytedValue);
            Assert.NotEqual("", encrytedValue);
        }

        [Fact]
        public void ReturnNullGivenNull()
        {
            string encrytedValue = Encrypter.Encrypt(null);
            Assert.Null(encrytedValue);
        }

        [Fact]
        public void EncryptNullGivenEmpty()
        {
            string encrytedValue = Encrypter.Encrypt("");
            Assert.Null(encrytedValue);
        }
    }
}