using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            int integers = 0;
            double floatingPoint = 0;
            bool boolean;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "END")
                {
                    return;
                }

                bool isBoolean = true;
                try
                {
                    boolean = bool.Parse(command);
                }
                catch (Exception)
                {
                    isBoolean = false;
                }

                bool isInt = true;
                try
                {
                    integers = int.Parse(command);
                }
                catch (Exception)
                {
                    isInt = false;
                }

                bool isDouble = true;
                try
                {
                    floatingPoint = double.Parse(command);
                }
                catch (Exception)
                {

                    isDouble = false;
                }

                if (isInt)
                {
                    Console.WriteLine($"{command} is integer type");
                }
                else if (isDouble)
                {
                    Console.WriteLine($"{command} is floating point type");
                }
                else if (command.Length == 1)
                {
                    Console.WriteLine($"{command} is character type");
                }
                else if (isBoolean)
                {
                    Console.WriteLine($"{command} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{command} is string type");
                }
            }
        }
    }
}
