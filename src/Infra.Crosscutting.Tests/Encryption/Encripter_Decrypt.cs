using Ritter.Infra.Crosscutting.Encryption;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests
{

    public class Encrypter_Decrypt
    {
        [Fact]
        public void ReturnDecryptedGivenAnyString()
        {
            string value = "VALUE_TO_ENCRYPT";

            string encrytedValue = Encrypter.Encrypt(value);
            Assert.NotNull(encrytedValue);
            Assert.NotEqual("", encrytedValue);

            string decryptedValue = Encrypter.Decrypt(encrytedValue);
            Assert.NotNull(decryptedValue);
            Assert.NotEqual("", decryptedValue);
            Assert.Equal(value, decryptedValue);
        }

        [Fact]
        public void ReturnNullGivenNull()
        {
            string decrytedValue = Encrypter.Decrypt(null);
            Assert.Null(decrytedValue);
        }

        [Fact]
        public void ReturnNullGivenEmpty()
        {
            string decrytedValue = Encrypter.Decrypt("");
            Assert.Null(decrytedValue);
        }
    }
}
