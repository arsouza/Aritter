using System.IO;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        #region Methods

        public static byte[] ToByteArray(this Stream stream)
        {
            var buffer = new byte[(int)stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        #endregion Methods
    }
}