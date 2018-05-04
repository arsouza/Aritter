namespace System.IO
{
    public static class StreamExtensions
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            var buffer = new byte[(int)stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}
