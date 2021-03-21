using System;
using System.Globalization;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();

            DateTime day = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(day.DayOfWeek);
        }
    }
}
