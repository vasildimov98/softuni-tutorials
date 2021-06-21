namespace Demo
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var sqr = new SquareRoot(int.Parse(Console.ReadLine()));

                Console.WriteLine(sqr.CalculateSqrRoot());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
