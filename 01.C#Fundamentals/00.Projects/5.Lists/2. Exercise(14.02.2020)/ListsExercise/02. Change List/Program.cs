using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = "";
            while (true)
            {
                command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine(string.Join(" ", list));
                    return;
                }

                List<string> allCommand = command
                    .Split()
                    .ToList();

                string action = allCommand[0];
                int elem = int.Parse(allCommand[1]);

                NewMethod(list, allCommand, action, elem);
            }
        }

        private static void NewMethod(List<int> list, List<string> allCommand, string action, int elem)
        {
            if (action == "Delete")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == elem)
                    {
                        list.Remove(elem);
                    }
                }
            }
            else
            {
                int position = int.Parse(allCommand[2]);
                list.Insert(position, elem);
            }
        }
    }
}
