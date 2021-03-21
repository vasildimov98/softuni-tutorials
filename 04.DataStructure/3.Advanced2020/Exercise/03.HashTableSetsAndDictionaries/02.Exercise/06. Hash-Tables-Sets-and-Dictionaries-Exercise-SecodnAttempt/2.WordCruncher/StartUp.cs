namespace _2.WordCruncher
{
    using System;
    using System.Linq;

    public class StartUp
    {
        const string INPUT_SEPARATOR = ", ";
        public static void Main()
        {
            var wordsInput = Console
                 .ReadLine()
                 .Split(INPUT_SEPARATOR)
                 .ToList();

            var targetText = Console
                .ReadLine();

            var wordCruncher = new WordCruncher(wordsInput, targetText);
        }
    }
}
