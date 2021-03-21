using System;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console
                .ReadLine()
                .Split();

            Random random = new Random();

            for (int i = 0; i < text.Length; i++)
            {
                int index = random.Next(0, text.Length);

                string TemVar = text[i];
                text[i] = text[index];
                text[index] = TemVar;
            }

            Console.WriteLine(string.Join(Environment.NewLine, text));
        }
    }
}
