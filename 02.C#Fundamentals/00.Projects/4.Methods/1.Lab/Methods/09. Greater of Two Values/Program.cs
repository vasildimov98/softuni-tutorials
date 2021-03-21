using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            if (command == "int")
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                int result = GreaterInt(num1, num2);
                Console.WriteLine(result);
            }
            else if (command == "char")
            {
                char char1 = char.Parse(Console.ReadLine());
                char char2 = char.Parse(Console.ReadLine());
                int result = GreaterChar(char1, char2);
                Console.WriteLine((char)result);
            }
            else if (command == "string")
            {
                string text1 = Console.ReadLine();
                string text2 = Console.ReadLine();
                string result = GreaterString(text1, text2);
                Console.WriteLine(result);
            }
        }

        static int GreaterInt(int num1, int num2)
        {
            int result = 0;
            result = Math.Max(num1, num2);
            return result;
        }

        static int GreaterChar(char char1, char char2)
        {
            int result = 0;
            result = Math.Max(char1, char2);
            return result;
        }
        static string GreaterString(string text1, string text2)
        {
            string result = "";
            if (text1.CompareTo(text2) >= 0)
            {
                result = text1;
            }
            else
            {
                result = text2;
            }
            return result;
        }

    }
}
