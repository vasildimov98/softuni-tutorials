using System;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Replace")
                {
                    string currChar = data[1];
                    string newChar = data[2];

                    input = input.Replace(currChar, newChar);
                    Console.WriteLine(input);
                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);

                    if ((startIndex >= 0 && startIndex <= input.Length) && (endIndex >= 0 && endIndex <= input.Length) && startIndex <= endIndex)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (action == "Make")
                {
                    if (data[1] == "Upper")
                    {
                        input = input.ToUpper();
                    }
                    else if (data[1] == "Lower")
                    {
                        input = input.ToLower();
                    }

                    Console.WriteLine(input);
                }
                else if (action == "Check")
                {
                    string word = data[1];

                    if (input.Contains(word))
                    {
                        Console.WriteLine($"Message contains {word}");
                    }
                    else if (!input.Contains(word))
                    {
                        Console.WriteLine($"Message doesn't contain {word}");
                    }
                }
                else if (action == "Sum")
                {
                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);

                    if ((startIndex >= 0 && startIndex <= input.Length) && (endIndex >= 0 && endIndex <= input.Length) && startIndex <= endIndex)
                    {
                        string sub = input.Substring(startIndex, endIndex - startIndex + 1);
                        int sum = 0;
                        foreach (char letter in sub)
                        {
                            sum += letter;
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
    }
}
