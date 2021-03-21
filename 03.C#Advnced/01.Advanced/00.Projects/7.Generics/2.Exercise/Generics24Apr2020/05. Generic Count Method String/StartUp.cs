using System;

namespace GenericCountMethodString
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var value = Console.ReadLine();

                box.Values.Add(value);
            }

            var element = Console.ReadLine();

            var count = box.CounterForGreaterElement(element);

            Console.WriteLine(count);
        }
    }
}
