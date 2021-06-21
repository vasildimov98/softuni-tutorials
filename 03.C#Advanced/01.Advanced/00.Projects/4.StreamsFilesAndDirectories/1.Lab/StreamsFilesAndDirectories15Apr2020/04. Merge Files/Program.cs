using System;
using System.IO;

namespace _04._Merge_Files
{
    class Program
    {
        static void Main()
        {
            var file1Reader = new StreamReader("FileOne.txt");
            var file2Reader = new StreamReader("FileTwo.txt");

            using var writer = new StreamWriter("Output.txt");
            string line;
            while ((line = file1Reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
                line = file2Reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                writer.WriteLine(line);
            }
        }
    }
}
