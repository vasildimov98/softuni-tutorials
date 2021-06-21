namespace P02.LineNumbers
{
    using System.IO;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var inputFileName = "text.txt";
            var outputFileName = "output.txt";

            var fileLines = File.ReadAllLines(inputFileName);

            var result = GetResult(fileLines);

            File.WriteAllText(outputFileName, result.ToString().Trim());
        }

        private static StringBuilder GetResult(string[] fileLines)
        {
            var result = new StringBuilder();

            var numberOfLine = 1;

            foreach (var line in fileLines)
            {
                var countOfLetters = 0;
                var countOfPunctuationMarks = 0;

                foreach (var ch in line)
                {
                    if (char.IsLetter(ch))
                    {
                        countOfLetters++;
                    }
                    else if (char.IsPunctuation(ch))
                    {
                        countOfPunctuationMarks++;
                    }
                }

                result.AppendLine($"Line {numberOfLine++}: {line} ({countOfLetters})({countOfPunctuationMarks})");
            }

            return result;
        }
    }
}
