using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = "";

            while ((number = Console.ReadLine()) != "END")
            {
                bool isPalindrome = IsPalindrome(number);

                if (isPalindrome)
                {
                    Console.WriteLine(isPalindrome.ToString().ToLower());
                }
                else
                {
                    Console.WriteLine(isPalindrome.ToString().ToLower());
                }
            }
        }

        static bool IsPalindrome(string number)
        {
            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] != number[number.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
