using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01._Even_Lines
{
    class StartUp
    {
        static void Main()
        {
            var reader = new StreamReader(@".\text.txt");

            var count = 0;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (count % 2 == 0)
                {
                    line = ChangeSybols('@', line, '-', ',', '.', '!', '?');

                    line = ReverseWord(line);

                    Console.WriteLine(line);
                }

                count++;
            }
        }

        static string ChangeSybols(char symbolToChageWith, string str, params char[] symbols)
        {
            var sb = new StringBuilder();

            foreach (var chr in str)
            {
                if (symbols.Contains(chr))
                {
                    sb.Append(symbolToChageWith);
                }
                else
                {
                    sb.Append(chr);
                }
            }

            return sb.ToString().TrimEnd();
        }

        static string ReverseWord(string str)
        {
            var words = str
                .Split(' ')
                .ToArray();
            var sb = new StringBuilder();
            var wordsLen = words.Length;
            for (int i = 0; i < wordsLen; i++)
            {
                sb.Append(words[wordsLen - 1 - i]);
                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
    }
}
