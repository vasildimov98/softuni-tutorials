using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (!IsValidSum(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!IsCorrect(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!Is2Digit(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (Is2Digit(password) && IsCorrect(password) && IsValidSum(password))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool IsValidSum(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }

        static bool IsCorrect(string password)
        {
            bool isTrue = true;

            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }

        static bool Is2Digit(string password)
        {
            int digitCounter = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitCounter++;
                }
            }
            return digitCounter >= 2;
        }
    }
}
