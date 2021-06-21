namespace FixItPrt2
{
    using System;
    

    public class StartUp
    {
        public static void Main()
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} * {num2} = {result}");
            }
            catch (OverflowException oex)
            {
                Console.WriteLine(oex.Message);
            }
        }
    }
}
