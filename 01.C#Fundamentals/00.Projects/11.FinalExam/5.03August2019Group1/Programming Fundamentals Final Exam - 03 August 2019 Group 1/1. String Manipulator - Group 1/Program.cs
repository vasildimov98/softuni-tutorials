using System;

namespace _1._String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            string input = Console.ReadLine();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Translate")
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
                else if (action == "Start")
                {
                    string word = data[1];

                    if (input.StartsWith(word))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "Lowercase")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (action == "FindIndex")
                {
                    string word = data[1];
                    int index = input.LastIndexOf(word);
                    Console.WriteLine(index);
                }
                else if (action == "Remove")
                {
                    int startIndex = int.Parse(data[1]);
                    int count = int.Parse(data[2]);
                    input = input.Remove(startIndex, count);
                    Console.WriteLine(input);
                }
            }
        }
    }
}
