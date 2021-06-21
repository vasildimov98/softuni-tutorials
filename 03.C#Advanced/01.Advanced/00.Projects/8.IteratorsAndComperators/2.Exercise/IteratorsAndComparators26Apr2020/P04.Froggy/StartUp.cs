using System;
using System.Linq;

namespace P04.Froggy
{
    public class StartUp
    {
        static void Main()
        {
            var stones = Console
                 .ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
