namespace P01.EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var sourceFileName = "text.txt";

            using var streamReader = new StreamReader(sourceFileName);

            var chars = new[] { '-', ',', '.', '!', '?' };

            PrintEvenLines(streamReader, chars);
        }

        private static void PrintEvenLines(StreamReader streamReader, char[] chars)
        {
            var count = 0;
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();

                if (count % 2 == 0)
                {
                    var newLine = string
                        .Join(' ', chars.Aggregate(line, (str, chr) => str.Replace(chr, '@'))
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Reverse());

                    Console.WriteLine(newLine);
                }

                count++;
            }
        }
    }
}
