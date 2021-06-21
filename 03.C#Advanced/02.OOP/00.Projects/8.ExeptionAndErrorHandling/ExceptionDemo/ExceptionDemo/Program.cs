namespace ExceptionDemo
{
    using System;
    public class Program
    {
        public static void Main()
        {
            //TestTryFinally();

            //try
            //{
            //    var result = int.Parse(Console.ReadLine()) / int.Parse(Console.ReadLine());
            //}
            //catch (Exception sqlEx)
            //{
            //    throw new InvalidOperationException("Cannot save invoice.", sqlEx);
            //}

            try
            {
                Sqrt(double.Parse(Console.ReadLine()));
            }
            catch (ArgumentOutOfRangeException aure)
            {
                Console.WriteLine(aure.Message);
            }
        }

        static void TestTryFinally()
        {
            Console.WriteLine("Code executed before try-finally.");
            try
            {
                string str = Console.ReadLine();
                int.Parse(str);
                Console.WriteLine("Parsing was successful.");
                return; // Exit from the current method 
            }
            catch (FormatException)
            {
                Console.WriteLine("Parsing failed!");
            }
            finally
            {
                Console.WriteLine("This cleanup code is always executed.");
            }
            Console.WriteLine("This code is after the try-finally block.");
        }

        public static double Sqrt(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(value.ToString(), "Sqrt for negative numbers is undefined!");
            }
            return Math.Sqrt(value);
        }

    }
}
