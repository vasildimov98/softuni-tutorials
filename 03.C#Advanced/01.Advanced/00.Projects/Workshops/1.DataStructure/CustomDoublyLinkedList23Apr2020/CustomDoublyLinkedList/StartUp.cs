using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            var doubleLinkedList = new DoubleLinkedList<int>();

            doubleLinkedList.AddFirst(10);
            doubleLinkedList.AddFirst(20);
            doubleLinkedList.AddFirst(30);

            doubleLinkedList.AddLast(30);
            doubleLinkedList.AddLast(20);
            doubleLinkedList.AddLast(10);

            //removes head and checks invalid operation exeption
            //for (int i = 0; i < 8; i++)
            //{
            //    Console.WriteLine(doubleLinkedList.RemoveFirst());
            //}

            //removes tail and checks invalid operation exeption
            //for (int i = 0; i < 8; i++)
            //{
            //    Console.WriteLine(doubleLinkedList.RemoveLast());
            //}

            doubleLinkedList.ForEach(elem => Console.Write(elem + " "));

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine(string.Join(" ", doubleLinkedList.ToArray()));

            Console.WriteLine();

            Console.WriteLine(doubleLinkedList[3]);

            Console.WriteLine();

            foreach (var item in doubleLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
