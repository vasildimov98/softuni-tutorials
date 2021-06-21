namespace FixItPrtOne
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var weekends = new string[7];

            GetArrFull(weekends);

            try
            {
                PrintDaysOfTheWeek(weekends);
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine(ioore.Message);
            }
        }

        private static void GetArrFull(string[] weekends)
        {
            weekends[0] = "Sunday";
            weekends[1] = "Monday";
            weekends[2] = "Tuesday";
            weekends[3] = "Wednesday";
            weekends[4] = "Thursday";
            weekends[5] = "Friday";
            weekends[6] = "Saturday";
        }

        private static void PrintDaysOfTheWeek(string[] weekends)
        {
            for (int i = 0; i <= 7; i++)
            {
                Console.WriteLine(weekends[i]);
            }
        }
    }
}
