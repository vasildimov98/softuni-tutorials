using System;

namespace GenericBoxOfString
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var value = Console.ReadLine();

                var box = new Box<string>(value);

                Console.WriteLine(box);
            }
        }
    }
}
