namespace EntersNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int LIMIT_NUMBERS = 10;
            const int START_NUMBER = 1;
            const int END_NUMBER = 100;
            var count = 0;

            while (count != LIMIT_NUMBERS)
            {
                try
                {
                    var number = ReadNumber(START_NUMBER, END_NUMBER);
                    count++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    count = 0;
                }
            }
        }

        private static int ReadNumber(int start, int end)
        {
            var number = int.Parse(Console.ReadLine());
            if (number <= start || number >= end)
            {
                throw new ArgumentException("Invalid number!");
            }

            return number;
        }
    }
}
