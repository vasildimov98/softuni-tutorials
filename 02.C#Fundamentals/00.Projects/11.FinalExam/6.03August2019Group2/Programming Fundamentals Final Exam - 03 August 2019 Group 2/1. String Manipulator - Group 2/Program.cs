using System;

namespace _1._String_Manipulator___Group_2
{
    class Program
    {
        static void Main()
        {
            string command;
            string input = Console.ReadLine();
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] data = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Change")
                {
                    string symbol = data[1];
                    string replacement = data[2];
                    input = input.Replace(symbol, replacement);

                    Console.WriteLine(input);
                }
                else if (action == "Includes")
                {
                    string word = data[1];

                    if (input.Contains(word))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "End")
                {
                    string word = data[1];

                    if (input.EndsWith(word))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (action == "FindIndex")
                {
                    string word = data[1];
                    int index = input.IndexOf(word);
                    Console.WriteLine(index);
                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(data[1]);
                    int count = int.Parse(data[2]);
                    input = input.Substring(startIndex, count);
                    Console.WriteLine(input);
                }
            }
        }
    }
}
