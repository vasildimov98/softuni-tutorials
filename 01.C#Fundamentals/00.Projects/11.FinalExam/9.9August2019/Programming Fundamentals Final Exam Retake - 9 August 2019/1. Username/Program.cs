using System;
using System.Linq;
using System.Text;

namespace _1._Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string command;

            while ((command = Console.ReadLine()) != "Sign up")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Case")
                {
                    if (data[1] == "lower")
                    {
                        username = username.ToLower();
                    }
                    else if (data[1] == "upper")
                    {
                        username = username.ToUpper();
                    }

                    Console.WriteLine(username);
                }
                else if (action == "Reverse")
                {
                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);

                    if (startIndex <= endIndex && (startIndex >= 0 && startIndex <= username.Length) && (endIndex >= 0 && endIndex <= username.Length))
                    {
                        string sub = username.Substring(startIndex, endIndex - startIndex + 1);
                        StringBuilder reversed = new StringBuilder();

                        for (int i = sub.Length - 1; i >= 0; i--)
                        {
                            reversed.Append(sub[i]);
                        }

                        Console.WriteLine(reversed);
                    }
                }
                else if (action == "Cut")
                {
                    if (username.Contains(data[1]))
                    {
                        username = username.Replace(data[1], "");
                        Console.WriteLine(username);
                    }
                    else if (!username.Contains(data[1]))
                    {
                        Console.WriteLine($"The word {username} doesn't contain {data[1]}.");
                    }
                }
                else if (action == "Replace")
                {
                    username = username.Replace(data[1], "*");
                    Console.WriteLine(username);
                }
                else if (action == "Check")
                {
                    if (username.Contains(data[1]))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {data[1]}.");
                    }
                }
            }
        }
    }
}
