using Ritter.Infra.Crosscutting.Encryption;
using System;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests
{

    public class Encripter_SetPrivateKey
    {
        [Fact]
        public void SetPrivateKeySuccessfully()
        {
            var privateKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
            string value = "VALUE_TO_ENCRYPT";

            Encrypter.SetPrivateKey(privateKey);

            string encrytedValue = Encrypter.Encrypt(value);
            Assert.NotNull(encrytedValue);
            Assert.NotEqual("", encrytedValue);

            string decryptedValue = Encrypter.Decrypt(encrytedValue);
            Assert.NotNull(decryptedValue);
            Assert.NotEqual("", decryptedValue);
            Assert.Equal(value, decryptedValue);
        }

        [Fact]
        public void SetNullPrivateKeyMustThrowsArgumentNullException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Encrypter.SetPrivateKey(null);
            });

            Assert.Equal(exception.ParamName, "key");
        }

        [Fact]
        public void SetEmptyPrivateKeyMustThrowsArgumentNullException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Encrypter.SetPrivateKey("");
            });

            Assert.Equal(exception.ParamName, "key");
        }
    }
}
