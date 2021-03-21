namespace CustomStack
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new List<string> { "1", "2", "3" });
            stack.AddRange(new string[] { "4", "5", "6" });

            foreach (var elem in stack)
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine(stack.IsEmpty());

            var hashSet = new HashSet<string>();
            var list = new List<int>();
            var arr = new char[12];

            Console.WriteLine(hashSet.IsEmpty());
            Console.WriteLine(list.IsEmpty());
            Console.WriteLine(arr.IsEmpty());

            var rangetoAdd1 = new List<string>();
            var rangetoAdd2 = new List<int>();
            var rangetoAdd3 = new List<char>();
            for (int i = 0; i < 10; i++)
            {
                rangetoAdd1.Add($"{i}");
                rangetoAdd2.Add(i);
                rangetoAdd3.Add((char)i);
            }


            hashSet.AddRange(rangetoAdd1);
            list.AddRange(rangetoAdd2);

            hashSet.ToList().ForEach(Console.WriteLine);
            list.ForEach(Console.WriteLine);

            Console.WriteLine(hashSet.IsEmpty());
            Console.WriteLine(list.IsEmpty());
        }
    }
}
