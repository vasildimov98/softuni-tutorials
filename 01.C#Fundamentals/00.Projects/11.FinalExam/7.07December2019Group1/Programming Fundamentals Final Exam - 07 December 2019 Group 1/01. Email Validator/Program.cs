using System;
using System.Text;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string commands;

            while ((commands = Console.ReadLine()) != "Complete")
            {
                string[] data = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Make")
                {
                    string command = data[1];

                    if (command == "Upper")
                    {
                        email = email.ToUpper();
                    }
                    else if (command == "Lower")
                    {
                        email = email.ToLower();
                    }

                    Console.WriteLine(email);
                }
                else if (action == "GetDomain")
                {
                    int count = int.Parse(data[1]);

                    Console.WriteLine(email.Substring(email.Length - count));
                }
                else if (action == "GetUsername")
                {
                    if (email.Contains('@'))
                    {
                        Console.WriteLine(email.Substring(0, email.IndexOf('@')));
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (action == "Replace")
                {
                    string symbol = data[1];
                    email = email.Replace(symbol, "-");
                    Console.WriteLine(email);
                }
                else if (action == "Encrypt")
                {
                    StringBuilder result = new StringBuilder();

                    foreach (int symbol in email)
                    {
                        result.Append(symbol + " ");
                    }

                    Console.WriteLine(result.ToString().TrimEnd());
                }
            }
        }
    }
}
