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

            List<int> newList = GetNewList(list);
            if (list.Sum() != newList.Sum())
            {
                Console.WriteLine(string.Join(" ", newList));
            }
            else
            {
                return;
            }
        }

        static List<int> GetNewList(List<int> list)
        {
            string command = "";
            List<int> newList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                newList.Add(list[i]);
            }

            while ((command = Console.ReadLine()) != "end")
            {
                string[] arr = command.Split();

                if (arr[0] == "Add")
                {
                    newList.Add(int.Parse(arr[1]));
                }
                else if (arr[0] == "Remove")
                {
                    newList.Remove(int.Parse(arr[1]));
                }
                else if (arr[0] == "RemoveAt")
                {
                    newList.RemoveAt(int.Parse(arr[1]));
                }
                else if (arr[0] == "Insert")
                {
                    newList.Insert(int.Parse(arr[2]), int.Parse(arr[1]));
                }
                else if (arr[0] == "Contains")
                {
                    if (newList.Contains(int.Parse(arr[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (arr[0] == "PrintEven")
                {
                    List<int> evenNumbers = newList.Where(x => x % 2 == 0).ToList();
                    Console.WriteLine(string.Join(" ", evenNumbers));
                }
                else if (arr[0] == "PrintOdd")
                {
                    List<int> oddNumbers = newList.Where(x => x % 2 != 0).ToList();
                    Console.WriteLine(string.Join(" ", oddNumbers));
                }
                else if (arr[0] == "GetSum")
                {
                    Console.WriteLine(newList.Sum());
                }
                else if (arr[0] == "Filter")
                {
                    if (arr[1] == "<")
                    {
                        List<int> lessThanList = newList.Where(x => x < int.Parse(arr[2])).ToList();
                        Console.WriteLine(string.Join(" ", lessThanList));
                    }
                    else if (arr[1] == ">")
                    {
                        List<int> biggerThanList = newList.Where(x => x > int.Parse(arr[2])).ToList();
                        Console.WriteLine(string.Join(" ", biggerThanList));
                    }
                    else if (arr[1] == ">=")
                    {
                        List<int> biggerOrEqualThanList = newList.Where(x => x >= int.Parse(arr[2])).ToList();
                        Console.WriteLine(string.Join(" ", biggerOrEqualThanList));
                    }
                    else if (arr[1] == "<=")
                    {
                        List<int> lessOrEqualThanList = newList.Where(x => x <= int.Parse(arr[2])).ToList();
                        Console.WriteLine(string.Join(" ", lessOrEqualThanList));
                    }
                }
            }

            return newList;
        }
    }
}
