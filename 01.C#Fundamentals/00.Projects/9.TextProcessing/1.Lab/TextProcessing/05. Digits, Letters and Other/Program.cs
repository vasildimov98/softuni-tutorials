using System;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digit = "";
            string letter = "";
            string other = "";
            foreach (var ch in input)
            {
                if (char.IsDigit(ch))
                {
                    digit += ch;
                }
                else if (char.IsLetter(ch))
                {
                    letter += ch;
                }
                else
                {
                    other += ch;
                }
            }

            Console.WriteLine(digit);
            Console.WriteLine(letter);
            Console.WriteLine(other);
        }
    }
}
