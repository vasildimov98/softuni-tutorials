using System;
using System.IO;
using System.Linq;

namespace _05._Slice_File
{
    class StartUp
    {
        static void Main()
        {
            using var stream = new FileStream("sliceMe.txt", FileMode.Open);

            var parts = 4;

            var length = (long)Math.Ceiling((double)stream.Length / parts);

            var buffer = new byte[length];

            for (int i = 0; i < parts; i++)
            {
                var bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead < buffer.Length)
                {
                    buffer = buffer
                        .Take(bytesRead)
                        .ToArray();
                    break;
                }

                using var currentPartsStream = new FileStream($"Part{i + 1}.txt", FileMode.Create);

                currentPartsStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}

