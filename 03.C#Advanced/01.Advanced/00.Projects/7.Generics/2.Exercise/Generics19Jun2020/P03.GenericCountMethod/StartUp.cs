namespace P03.GenericCountMethod
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var box = new Box<double>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());

                box.AddItem(input);
            }

            var comparer = double.Parse(Console.ReadLine());

            var count = box.Counter(comparer);

            Console.WriteLine(count);
        }
    }
}
