using System;
using System.IO;

namespace _02._Line_Numbers
{
    class StartUp
    {
        static void Main()
        {
            var filePath = @".\text.txt";
            var reader = File.ReadAllLines(filePath);

            var count = 0;
            var writePath = @".\output.txt";
            var contents = new string[reader.Length];
            foreach (var line in reader)
            {
                var lettersCount = 0;
                var punctuationsCount = 0;
                foreach (var chr in line)
                {
                    if (char.IsLetter(chr))
                    {
                        lettersCount++;
                    }
                    else if (char.IsPunctuation(chr))
                    {
                        punctuationsCount++;
                    }
                }

                contents[count++] = $"Line {count}: {line} ({lettersCount})({punctuationsCount})";
            }

            File.WriteAllLines(writePath, contents);
        }
    }
}
