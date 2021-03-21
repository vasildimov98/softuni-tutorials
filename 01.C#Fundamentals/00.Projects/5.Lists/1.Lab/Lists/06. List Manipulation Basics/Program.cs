using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
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

            GetNewList(list);
            Console.WriteLine(string.Join(" ", list));
        }

        static List<int> GetNewList(List<int> list)
        {
            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arr = command.Split();

                if (arr[0] == "Add")
                {
                    list.Add(int.Parse(arr[1]));
                }
                else if (arr[0] == "Remove")
                {
                    list.Remove(int.Parse(arr[1]));
                }
                else if (arr[0] == "RemoveAt")
                {
                    list.RemoveAt(int.Parse(arr[1]));
                }
                else if (arr[0] == "Insert")
                {
                    list.Insert(int.Parse(arr[2]), int.Parse(arr[1]));
                }
            }

            return list;
        }
    }
}
