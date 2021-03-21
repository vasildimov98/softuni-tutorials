using System;
using System.IO;

namespace _01._Odd_Lines
{
    class StartUp
    {
        static void Main()
        {
            var reader = new StreamReader("Input.txt");

            var counter = 0;

            using var writer = new StreamWriter("Output.txt");
            while (true)
            {
                var line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (counter % 2 != 0)
                {
                    writer.WriteLine(line);
                    Console.WriteLine(line);
                }

                counter++;
            }
        }
    }
}
