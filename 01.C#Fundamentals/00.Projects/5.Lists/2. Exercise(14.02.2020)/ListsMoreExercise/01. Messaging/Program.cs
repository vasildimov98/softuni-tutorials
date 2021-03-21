using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    class Program
    {
        static void Main()
        {
            List<int> numbs = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            string text = Console.ReadLine();
            List<char> chars = new List<char>();

            chars.AddRange(text);

            string result = "";
            for (int i = 0; i < numbs.Count; i++)
            {
                int index = 0;
                int currNum = numbs[i];

                while (currNum != 0)
                {
                    int digit = currNum % 10;
                    index += digit;
                    currNum /= 10;
                }

                if (index >= chars.Count)
                {
                    index /= chars.Count;
                }

                result += chars[index];
                chars.RemoveAt(index);
            }

            Console.WriteLine(result);
        }
    }
}
