using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int successfulRegistrationsCount = 0;

            string pattern = @"(U\$)(?<username>[A-Z][a-z]{2,})\1(P@\$)(?<password>[A-Za-z]{5,}[0-9]+)\2";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine("Registration was successful");

                    string username = match.Groups["username"].Value;
                    string password = match.Groups["password"].Value;

                    Console.WriteLine($"Username: {username}, Password: {password}");
                    successfulRegistrationsCount++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
