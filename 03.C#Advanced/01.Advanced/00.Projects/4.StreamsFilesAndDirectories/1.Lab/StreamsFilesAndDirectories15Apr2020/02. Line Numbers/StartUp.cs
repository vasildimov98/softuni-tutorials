using System;
using System.IO;

namespace _02._Line_Numbers
{
    class StartUp
    {
        static void Main()
        {
            var reader = new StreamReader("Input.txt");

            var count = 1;
            using var writer = new StreamWriter("Output.txt");
            while (true)
            {
                var line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                writer.WriteLine($"{count++}. {line}");
            }
        }
    }
}
