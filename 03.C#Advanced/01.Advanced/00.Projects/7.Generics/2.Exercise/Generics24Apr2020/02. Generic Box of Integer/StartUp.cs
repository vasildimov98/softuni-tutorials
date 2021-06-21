using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());

                var box = new Box<int>(number);

                Console.WriteLine(box);
            }
        }
    }
}
