using System;

namespace P05._Date_Modifier
{
    class StartUp
    {
        static void Main()
        {
            string date1 = Console
                 .ReadLine();

            string date2 = Console
                .ReadLine();

            var dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.DifferenceBetweenTwoDates(date1, date2));
        }
    }
}
