namespace P05.SliceAFile
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var sourceFile = "sliceMe.txt";

            using var fileReader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);

            var parts = 10;

            var fileReaderLength = fileReader.Length;

            while (fileReaderLength % parts != 0)
            {
                fileReaderLength++;
            }

            var onePartLength = fileReaderLength / parts;

            var buffer = new byte[onePartLength];

            SliceFileOnNParts(fileReader, parts, onePartLength, buffer);
        }

        private static void SliceFileOnNParts(FileStream fileReader,
            int parts,
            long onePartLength,
            byte[] buffer)
        {
            for (int i = 0; i < parts; i++)
            {
                var bytesRead = fileReader.Read(buffer, 0, (int)onePartLength);

                if (bytesRead < onePartLength)
                {
                    buffer = buffer
                        .Take(bytesRead)
                        .ToArray();
                }

                using var fileWriter = new FileStream($"Part-{i + 1}.txt", FileMode.Create, FileAccess.Write);

                fileWriter.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
