using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string result = "";
            for (int i = 0; i < n; i++)
            {
                char character = char.Parse(Console.ReadLine());
                int charAddKey = (int)character + key;
                result += ((char)charAddKey);
            }

            Console.WriteLine(result);
        }
    }
}
