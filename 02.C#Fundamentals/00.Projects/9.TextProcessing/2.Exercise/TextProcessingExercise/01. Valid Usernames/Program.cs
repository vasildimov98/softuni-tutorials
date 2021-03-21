using System;
using System.Text.RegularExpressions;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var currUsername in usernames)
            {
                if (currUsername.Length >= 3 && currUsername.Length <= 16)
                {
                    Regex regex = new Regex(@"^[A-Za-z0-9-_]*$");

                    if (regex.IsMatch(currUsername))
                    {
                        Console.WriteLine(currUsername);
                    }
                }
            }
        }
    }
}
