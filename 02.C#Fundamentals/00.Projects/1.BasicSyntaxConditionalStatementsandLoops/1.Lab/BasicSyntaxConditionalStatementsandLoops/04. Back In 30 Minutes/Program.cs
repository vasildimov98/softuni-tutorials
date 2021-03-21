using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int hoursInMinutes = hours * 60;

            int hoursPlusMinutesPlus30 = minutes + hoursInMinutes + 30;

            
            int hours1 = (hoursPlusMinutesPlus30 / 60);
            int minutes1 = (hoursPlusMinutesPlus30 % 60);
            if (hours1 > 23)
            {
                hours1 = 0;
            }
            Console.WriteLine($"{hours1}:{minutes1:D2}");

        }
    }
}
