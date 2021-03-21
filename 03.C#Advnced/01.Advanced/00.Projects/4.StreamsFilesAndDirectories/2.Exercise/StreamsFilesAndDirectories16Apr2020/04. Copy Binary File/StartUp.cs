using System;
using System.IO;
using System.Linq;

namespace _04._Copy_Binary_File
{
    class StartUp
    {
        static void Main()
        {
            const int DEF_SIZE = 4096;

            var inputFilePath = @".\copyMe.png";
            var outputFilePath = @"..\..\..\copied.png";

            var reader = new FileStream(inputFilePath, FileMode.Open);
            var writer = new FileStream(outputFilePath, FileMode.Create);

            var buffer = new byte[DEF_SIZE];

            while (reader.CanRead)
            {
               var byteRead = reader.Read(buffer, 0, buffer.Length);

                if (byteRead == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
