using System;
using System.Text;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                StringBuilder name = new StringBuilder();
                StringBuilder age = new StringBuilder();
               
                for (int index = 0; index < input.Length; index++)
                {
                    if (input[index] == '@')
                    {
                        index++;
                        while (input[index] != '|')
                        {
                            name.Append(input[index]);
                            index++;
                        }
                    }

                    if (input[index] == '#')
                    {
                        index++;
                        while (input[index] != '*')
                        {
                            age.Append(input[index]);
                            index++;
                        }
                    }

                    if (name.Length > 0 && age.Length > 0)
                    {
                        Console.WriteLine($"{name} is { age } years old.");
                        name.Clear();
                        age.Clear();
                    }
                }
                
            }
        }
    }
}
