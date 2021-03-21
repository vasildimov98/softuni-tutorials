using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                char[] arrChar = command.Reverse().ToArray();

                string reversedText = string.Concat(arrChar);

                Console.WriteLine($"{command} = {reversedText}");
            }
        }
    }
}
