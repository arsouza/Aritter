using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ritter.Infra.Crosscutting.Encryption
{
    public static class Encrypter
    {
        private static string privateKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";

        private static readonly byte[] arrByte =
        {
            0x50,
            0x08,
            0xF1,
            0xDD,
            0xDE,
            0x3C,
            0xF2,
            0x18,
            0x44,
            0x74,
            0x19,
            0x2C,
            0x53,
            0x49,
            0xAB,
            0xBC
        };

        public static string Decrypt(string value)
        {
            if (value.IsNullOrEmpty())
                return null;

            byte[] key = Convert.FromBase64String(privateKey);
            byte[] text = Convert.FromBase64String(value);

            MemoryStream stream = new MemoryStream();

            using (Aes aes = Aes.Create())
            using (CryptoStream decryptor = new CryptoStream(stream, aes.CreateDecryptor(key, arrByte), CryptoStreamMode.Write))
            {
                decryptor.Write(text, 0, text.Length);
                decryptor.FlushFinalBlock();

                UTF8Encoding utf8 = new UTF8Encoding();

                return utf8.GetString(stream.ToArray());
            }
        }

        public static string Encrypt(string value)
        {
            if (value.IsNullOrEmpty())
                return null;

            byte[] key = Convert.FromBase64String(privateKey);
            byte[] text = new UTF8Encoding().GetBytes(value);

            MemoryStream stream = new MemoryStream();

            using (Aes aes = Aes.Create())
            using (CryptoStream encryptor = new CryptoStream(stream, aes.CreateEncryptor(key, arrByte), CryptoStreamMode.Write))
            {
                encryptor.Write(text, 0, text.Length);
                encryptor.FlushFinalBlock();

                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static void SetPrivateKey(string key)
        {
            Ensure.Argument.NotNullOrEmpty(key, nameof(key));
            privateKey = key;
        }
    }
}
