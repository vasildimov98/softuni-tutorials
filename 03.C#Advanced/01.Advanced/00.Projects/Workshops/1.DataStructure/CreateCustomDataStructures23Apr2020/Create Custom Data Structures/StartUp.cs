using System;
using System.Collections.Generic;
using System.Linq;

namespace Create_Custom_Data_Structures
{
    public class StartUp
    {
        static void Main()
        {
            List<int> list1 = new List<int>();
;
            var list = new MyList<int>();

            list.Add(20);
            list.Add(30);
            list.Add(40);

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            var removed = list.RemoveAt(0);
            var removed1 = list.RemoveAt(1);
            var removed2 = list.RemoveAt(2);
            var removed3 = list.RemoveAt(1);
            var removed4 = list.RemoveAt(1);
            var removed5 = list.RemoveAt(1);
             list.RemoveAt(1);
             list.RemoveAt(1);
             list.RemoveAt(1);

            Console.WriteLine(removed);
            Console.WriteLine(removed1);
            Console.WriteLine(removed2);
            Console.WriteLine(removed3);
            Console.WriteLine(removed4);
            Console.WriteLine(removed5);

            Console.WriteLine(list.Contains(1));


            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            list.Swap(0, 3);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            list.Clear();

            Console.WriteLine(list.Count);

            var newList = new MyList<int>();

            newList.Add(10);
            newList.Add(20);
            newList.Add(30);

            newList.Insert(2, 15);
            
            Console.WriteLine(newList[1]);
            Console.WriteLine(newList.Remove(10));
            Console.WriteLine(newList.Remove(100));

            MyList<int> list2 = newList
                  .Where(a => a % 2 == 0)
                  .ToMyList();
        }
    }
}
