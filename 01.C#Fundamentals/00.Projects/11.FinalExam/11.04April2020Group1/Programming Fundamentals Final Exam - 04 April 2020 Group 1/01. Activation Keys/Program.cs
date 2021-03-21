using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string command;

            while ((command = Console.ReadLine()) != "Generate")
            {
                var data = command
                    .Split(">>>");

                if (data[0] == "Contains")
                {
                    if (input.Contains(data[1]))
                    {
                        Console.WriteLine($"{input} contains {data[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (data[0] == "Flip")
                {
                    if (data[1] == "Upper")
                    {
                        var startIndex = int.Parse(data[2]);
                        var endIndex = int.Parse(data[3]);

                        string substring1 = input.Substring(startIndex, endIndex - startIndex);
                        string substring2 = input.Substring(startIndex, endIndex - startIndex).ToUpper();

                        input = input.Replace(substring1, substring2);
                        Console.WriteLine(input);
                    }
                    else if (data[1] == "Lower")
                    {
                        var startIndex = int.Parse(data[2]);
                        var endIndex = int.Parse(data[3]);

                        string substring1 = input.Substring(startIndex, endIndex - startIndex);
                        string substring2 = input.Substring(startIndex, endIndex - startIndex).ToLower();

                        input = input.Replace(substring1, substring2);
                        Console.WriteLine(input);
                    }
                }
                else if (data[0] == "Slice")
                {
                    var startIndex = int.Parse(data[1]);
                    var endIndex = int.Parse(data[2]);

                    var substring = input.Substring(startIndex, endIndex - startIndex);
                    input = input.Replace(substring, "");
                    Console.WriteLine(input);
                }
            }

            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
