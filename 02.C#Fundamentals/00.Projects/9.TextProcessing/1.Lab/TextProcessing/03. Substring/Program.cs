using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string line = Console.ReadLine();

            while (line.Contains(word))
            {
                int index = line.IndexOf(word);

                line = line.Remove(index, word.Length);
            }

            Console.WriteLine(line);
        }
    }
}
