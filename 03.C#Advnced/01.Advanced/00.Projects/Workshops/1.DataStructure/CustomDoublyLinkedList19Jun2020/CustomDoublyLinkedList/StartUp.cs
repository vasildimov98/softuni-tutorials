namespace CustomDoublyLinkedList
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static DoublyLinkedList<int> myDoybleLinkedList;
        public static void Main()
        {

            var list = new List<int>()
            {
                10
            };

            myDoybleLinkedList = new DoublyLinkedList<int>(list);

            myDoybleLinkedList.AddAfter(new LinkedNode<int>(10), 20);
            myDoybleLinkedList.AddAfter(new LinkedNode<int>(20), 30);
            myDoybleLinkedList.AddBefore(new LinkedNode<int>(10), 0);
            myDoybleLinkedList.AddBefore(new LinkedNode<int>(30), 25);
            myDoybleLinkedList.AddBefore(new LinkedNode<int>(20), 15);
            myDoybleLinkedList.AddBefore(new LinkedNode<int>(0), -10);

            myDoybleLinkedList.RemoveAfter(new LinkedNode<int>(10));
            myDoybleLinkedList.RemoveAfter(new LinkedNode<int>(20));
            myDoybleLinkedList.RemoveAfter(new LinkedNode<int>(0));

            myDoybleLinkedList.RemoveBefore(new LinkedNode<int>(20));
            myDoybleLinkedList.RemoveBefore(new LinkedNode<int>(20));
            myDoybleLinkedList.RemoveBefore(new LinkedNode<int>(20));
            myDoybleLinkedList.RemoveBefore(new LinkedNode<int>(20));

            foreach (var number in myDoybleLinkedList)
            {
                Console.WriteLine(number);
            }

           // myStringDoubleLinkedList.AddBefore(new LinkedNode<string>("NewNodeTestTwice"), new LinkedNode<string>("TestHahaTwice"));


            //Console.WriteLine();

            //myDoybleLinkedList = new DoublyLinkedList<string>();

            //myDoybleLinkedList.AddLast("Test1");
            //myDoybleLinkedList.AddLast("Test2");

            //Console.WriteLine(myDoybleLinkedList.RemoveFirst());
            //Console.WriteLine(myDoybleLinkedList.RemoveFirst());

            //try
            //{
            //    myDoybleLinkedList.RemoveFirst();
            //}
            //catch (InvalidOperationException ioe)
            //{
            //    Console.WriteLine(ioe.Message);
            //}

            //var elementsToAdd = 10;
            //AddLastElementsToCollection(elementsToAdd);

            //foreach (var element in myDoybleLinkedList)
            //{
            //    Console.WriteLine(element);
            //}

            //myDoybleLinkedList
            //    .ForEach(Console.WriteLine);

            //var arr = myDoybleLinkedList.ToArray();

            //Console.WriteLine(arr[6]);

            //var elementsToRemoved = 11;

            //try
            //{
            //    RemoveElementsFromTheCollection(elementsToRemoved);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }

        private static void RemoveElementsFromTheCollection(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                myDoybleLinkedList.RemoveLast();
            }
        }

        private static void AddFirstElementsToCollection(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                myDoybleLinkedList.AddFirst(i * 10);
            }
        }

        private static void AddLastElementsToCollection(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                myDoybleLinkedList.AddLast(i * 10);
            }
        }
    }
}
