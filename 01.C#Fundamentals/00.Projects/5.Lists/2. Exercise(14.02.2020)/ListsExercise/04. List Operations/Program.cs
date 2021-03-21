using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
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
                if (command == "End")
                {
                    Console.WriteLine(string.Join(" ", list));
                    return;
                }

                List<string> allCommand = command.Split().ToList();

                string action = allCommand[0];

                if (action == "Add")
                {
                    GetNewAddList(list, allCommand);
                }
                else if (action == "Insert")
                {
                    GetNewInsertList(list, allCommand);
                }
                else if (action == "Remove")
                {
                    GetNewRemoveList(list, allCommand);
                }
                else if (action == "Shift")
                {
                    GetNewShiftList(list, allCommand);
                }
            }
        }

        static void GetNewAddList(List<int> list, List<string> allCommand)
        {
            int number = int.Parse(allCommand[1]);

            list.Add(number);
        }

        static void GetNewInsertList(List<int> list, List<string> allCommand)
        {
            int number = int.Parse(allCommand[1]);

            int index = int.Parse(allCommand[2]);

            if (index <= list.Count && index >= 0)
            {
                list.Insert(index, number);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        static void GetNewRemoveList(List<int> list, List<string> allCommand)
        {
            int index = int.Parse(allCommand[1]);

            if (index <= list.Count && index >= 0)
            {
                list.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        static void GetNewShiftList(List<int> list, List<string> allCommand)
        {
            string position = allCommand[1];

            int count = int.Parse(allCommand[2]);

            if (position == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    int firts = list[0];

                    for (int index = 0; index < list.Count - 1; index++)
                    {
                        list[index] = list[index + 1];
                    }

                    list[list.Count - 1] = firts;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    int last = list[list.Count - 1];

                    for (int index = 0; index < list.Count - 1; index++)
                    {
                        list[list.Count - 1 - index] = list[list.Count - (index + 2)];
                    }

                    list[0] = last;
                }
            }
        }
    }
}
