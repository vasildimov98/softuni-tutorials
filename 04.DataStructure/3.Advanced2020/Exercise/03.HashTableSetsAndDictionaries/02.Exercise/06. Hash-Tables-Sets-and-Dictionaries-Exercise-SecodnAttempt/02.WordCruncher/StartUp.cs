namespace _02.WordCruncherGame
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
            var textTargetInput = Console
                .ReadLine();

            var wordCruncher = new WordCruncher(wordsInput, textTargetInput);

            foreach (var wordPath in wordCruncher)
            {
                Console.WriteLine(wordPath);
            }
        }
    }
}
