using System;
using System.Linq;

namespace GenericCountMethodDouble
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var value = double.Parse(Console.ReadLine());

                box.List.Add(value);
            }

            var element = double.Parse(Console.ReadLine());

            var count = box.CountOfElementsGreaterThanElement(element);

            Console.WriteLine(count);
        }
    }
}
