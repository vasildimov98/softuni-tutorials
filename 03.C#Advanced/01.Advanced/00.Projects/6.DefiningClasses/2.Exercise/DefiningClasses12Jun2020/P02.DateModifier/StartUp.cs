namespace P02.DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            var diff = DateModifier.CalDiffBetweenTwoDates(firstDate, secondDate);

            Console.WriteLine(diff);
        }
    }
}
