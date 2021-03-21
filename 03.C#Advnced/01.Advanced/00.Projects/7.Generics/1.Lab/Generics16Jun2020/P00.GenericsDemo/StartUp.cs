namespace P00.GenericsDemo
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var myStack1 = new MyStack<decimal>();

            var myStack2 = new MyStack<int>();

            myStack1.Add(12.231m);

            myStack2.Add(1);

            string[] stringArr = CreateArray<string>(5);
            int[] intArr = CreateArray<int>(50);
            Console.WriteLine(stringArr.Length); // 5
            Console.WriteLine(intArr.Length); // 50

            var stringList = CreateList(stringArr);

            var myDict = new MyDict<int, List<string>>();

            var pesho1 = new Person()
            {
                Name = "Pesho1",
                Age = 20
            };

            var pesho2 = new Person()
            {
                Name = "Pesho",
                Age = 20
            }; ;

            Console.WriteLine(pesho1.Equals(pesho2));
        }

        private static T[] CreateArray<T>(int capacity)
        {
            return new T[capacity];
        }

        private static List<T> CreateList<T>(T[] elements)
        {
            return new List<T>(elements);
        }
    }
}
