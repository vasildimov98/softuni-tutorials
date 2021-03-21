namespace P04.CopyBinaryFile
{
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            const string PNG_NAME = "copyMe.png";
            const string COPIED_PNG_NAME = "copied.png";
            const string ONE_FOLDER_UP_SYMBOL = "..";

            var path = Path.Combine(ONE_FOLDER_UP_SYMBOL, ONE_FOLDER_UP_SYMBOL, ONE_FOLDER_UP_SYMBOL, PNG_NAME);

            using var fileReader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

            using var fileWriter = new FileStream(COPIED_PNG_NAME, FileMode.Create, FileAccess.Write, FileShare.None);

            CopyFileInCurrentDirectory(fileReader, fileWriter);
        }

        private static void CopyFileInCurrentDirectory(Stream reader, Stream writer)
        {
            var buffer = new byte[4096];

            int readBytes;
            while ((readBytes = reader.Read(buffer, 0, buffer.Length)) != 0)
            {
                if (readBytes < buffer.Length)
                {
                    buffer = buffer
                        .Take(readBytes)
                        .ToArray();
                }

                writer.Write(buffer);
            }
        }
    }
}
